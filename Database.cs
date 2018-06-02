﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Data.SqlTypes;
using System.Data;
using System.Configuration;
using FrbaHotel.Login;
using System.Windows.Forms;


namespace FrbaHotel
{
    public class Database
    {
        //-------------------------------------- Atributos -------------------------------------

        private static String configuracionConexion = ConfigurationManager.AppSettings["conexionSQL"];
        private static SqlConnection conexion = new SqlConnection(configuracionConexion);

        //-------------------------------------- Metodos para Conexion -------------------------------------

        public static SqlConnection obtenerConexion()
        {
            return conexion;
        }

        public static void conectar()
        {
            conexion.Open();
        }

        public static void desconectar()
        {
            conexion.Close();
        }

        //-------------------------------------- Metodos para Consultas -------------------------------------

        public static SqlCommand consultaCrear(string consulta)
        {
            return new SqlCommand(consulta, Database.obtenerConexion());
        }

        public static void consultaEjecutar(SqlCommand consulta)
        {
            Database.conectar();
            try
            {
                consulta.ExecuteNonQuery();
            }
            catch (Exception excepcion)
            {
                Database.consultaInformarError(excepcion);
            }
            Database.desconectar();
        }

        public static void consultaInformarError(Exception excepcion)
        {
            MessageBox.Show("ERROR EN LA BASE DE DATOS:\n" + excepcion.ToString());
        }

        public static DataSet consultaObtenerDatos(SqlCommand consulta)
        {
            DataSet dataSet = new DataSet();
            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(consulta);
                dataAdapter.Fill(dataSet);
            }
            catch(Exception excepcion)
            {
                Database.consultaInformarError(excepcion);
            }
            return dataSet;
        }

        public static string consultaObtenerValor(SqlCommand consulta)
        {
            DataSet dataSet = consultaObtenerDatos(consulta);
            string valor = dataSet.Tables[0].Rows[0][0].ToString();
            return valor;
        }

        public static List<string> consultaObtenerLista(SqlCommand consulta)
        {
            DataSet dataSet = consultaObtenerDatos(consulta);
            List<string> listaDatos = new List<string>();
            foreach (DataRow fila in dataSet.Tables[0].Rows)
                listaDatos.Add(fila[0].ToString());
            return listaDatos;
        }

        public static DataTable consultaObtenerTabla(SqlCommand consulta)
        {
            DataSet dataSet = consultaObtenerDatos(consulta);
            return dataSet.Tables[0];
        }

        //-------------------------------------- Metodos para Login -------------------------------------

        public static Byte[] Sha256_hash(String value)
        {
            using (SHA256 hash = SHA256Managed.Create())
            {
                Encoding enc = Encoding.UTF8;
                return hash.ComputeHash(enc.GetBytes(value));
            }
        }

        internal static LogueoDTO Autenticar(string user, string pas)
        {
            SqlConnection connection = obtenerConexion();

            SqlCommand logueo = new SqlCommand("SELECT Usuario_User, Usuario_Contrasena, Usuario_CantidadDeIntentos FROM RIP.Usuarios WHERE Usuario_User=@username");
            logueo.Parameters.AddWithValue("username", user);
            logueo.Connection = connection;
            connection.Open();
            SqlDataReader reader = logueo.ExecuteReader();

            String usuario = null;
            byte[] contrasenia = null;
            int intentosFallidos = 0;

            while (reader.Read())
            {
                usuario = reader["Usuario_User"].ToString();
                contrasenia = reader.GetSqlBytes(reader.GetOrdinal("Usuario_Contrasena")).Buffer;
                intentosFallidos = reader.GetInt32(reader.GetOrdinal("Usuario_CantidadDeIntentos"));
            }

            reader.Close();
            connection.Close();

            if (usuario == null)
                return new LogueoDTO(false, "Error al loguearse. Usuario incorrecto.");

            if (intentosFallidos >= 3)
                return new LogueoDTO(false, "El usuario se encuentra bloqueado. Contactese con un administrador.");

            if (!Sha256_hash(pas).SequenceEqual(contrasenia))
            {
                intentosFallidos++;
                LoginActualizarIntentos(user, intentosFallidos);

                if (intentosFallidos >= 3)
                    return new LogueoDTO(false, "El usuario se ha bloqueado por cantidad de intentos fallidos de contranenia.\nContactese con un administrador.");

                return new LogueoDTO(false, "Error al loguearse. Contrasenia incorrecta.");
            }
            else
            {
                LoginActualizarIntentos(user, 0);
                List<string> roles = usuarioObtenerRolesHabilitados(usuario);
                List<string> hoteles = usuarioObtenerHoteles(usuario);
                return new LogueoDTO(true, "Exito!", usuario, roles, hoteles);
            }
        }

        public static void LoginActualizarIntentos(string username, int cantidad)
        {
            SqlCommand query = consultaCrear("UPDATE RIP.Usuarios SET Usuario_CantidadDeIntentos = @cantidad WHERE Usuario_User = @username");
            query.Parameters.AddWithValue("username", username);
            query.Parameters.AddWithValue("cantidad", cantidad);
            Database.consultaEjecutar(query);
        }

        //-------------------------------------- Metodos para Funcionalidades -------------------------------------

        public static List<string> funcionalidadObtenerTodas()
        {
            SqlCommand consulta = consultaCrear("SELECT Funcionalidad_Funcionalidad FROM RIP.Funcionalidades");
            return Database.consultaObtenerLista(consulta);
        }
        
        public static string funcionalidadObtenerId(string nombreFuncionalidad)
        {
            SqlCommand consulta = consultaCrear("SELECT Funcionalidad_Id FROM RIP.Funcionalidades WHERE Funcionalidad_Funcionalidad = @nombreFuncionalidad");
            consulta.Parameters.AddWithValue("@nombreFuncionalidad", nombreFuncionalidad);
            return Database.consultaObtenerValor(consulta);
        }

        //-------------------------------------- Metodos para Roles -------------------------------------

        public static void rolAgregar(string nombreRol, string estado)
        {
            SqlCommand consulta = consultaCrear("INSERT INTO RIP.Roles (Rol_Nombre, Rol_Estado) VALUES (@nombreRol, @estado)");
            consulta.Parameters.AddWithValue("@nombreRol", nombreRol);
            consulta.Parameters.AddWithValue("@estado", estado);
            consultaEjecutar(consulta);
        }

        public static void rolHabilitadoAgregar(string nombreRol)
        {
            Database.rolAgregar(nombreRol, "1");
        }

        public static void rolDeshabilitadoAgregar(string nombreRol)
        {
            Database.rolAgregar(nombreRol, "0");
        }

        public static void rolAgregarFuncionalidad(string idRol, string nombreFuncionalidad)
        {
            string idFuncionalidad = funcionalidadObtenerId(nombreFuncionalidad);
            SqlCommand consulta = consultaCrear("INSERT INTO RIP.Rol_Funcionalidad (RolFunc_IdRol, RolFunc_IdFuncionalidad) VALUES (@idRol, @idFuncionalidad)");
            consulta.Parameters.AddWithValue("@idRol", idRol);
            consulta.Parameters.AddWithValue("@idFuncionalidad", idFuncionalidad);
            consultaEjecutar(consulta);
        }

        public static void rolEliminarFuncionalidades(string nombreRol)
        {
            string idRol = rolObtenerId(nombreRol);
            SqlCommand consulta = consultaCrear("DELETE FROM RIP.Rol_Funcionalidad WHERE RolFunc_IdRol = @idRol");
            consulta.Parameters.AddWithValue("@idRol", idRol);
            consultaEjecutar(consulta);
        }

        public static void rolModificar(string nombreRolActual, string nombreRolNuevo, string estado)
        {
            Database.rolEliminarFuncionalidades(nombreRolActual);
            SqlCommand consulta = consultaCrear("UPDATE RIP.Roles SET Rol_Nombre = @nombreRolNuevo, Rol_Estado = @estado WHERE Rol_Nombre = @nombreRolActual");
            consulta.Parameters.AddWithValue("@nombreRolActual", nombreRolActual);
            consulta.Parameters.AddWithValue("@nombreRolNuevo", nombreRolNuevo);
            consulta.Parameters.AddWithValue("@estado", estado);
            consultaEjecutar(consulta);
        }

        public static void rolHabilitadoModificar(string nombreRolActual, string nombreRolNuevo)
        {
            Database.rolModificar(nombreRolActual, nombreRolNuevo, "1");
        }

        public static void rolDeshabilitadoModificar(string nombreRolActual, string nombreRolNuevo)
        {
            Database.rolModificar(nombreRolActual, nombreRolNuevo, "0");
        }

        public static void rolEliminar(string nombreRol)
        {
            SqlCommand consulta = consultaCrear("UPDATE RIP.Roles SET Rol_Estado = 0 WHERE Rol_Nombre = @nombreRol");
            consulta.Parameters.AddWithValue("@nombreRol", nombreRol);
            consultaEjecutar(consulta);
        }

        public static string rolObtenerId(string nombreRol)
        {
            SqlCommand consulta = consultaCrear("SELECT Rol_ID FROM RIP.Roles WHERE Rol_Nombre = @nombreRol");
            consulta.Parameters.AddWithValue("@nombreRol", nombreRol);
            return Database.consultaObtenerValor(consulta);
        }

        public static List<string> rolObtenerTodos()
        {
            SqlCommand consulta = consultaCrear("SELECT Rol_Nombre FROM RIP.Roles");
            return Database.consultaObtenerLista(consulta);
        }

        public static List<string> rolObtenerHabilitados()
        {
            SqlCommand consulta = consultaCrear("SELECT Rol_Nombre FROM RIP.Roles WHERE Rol_Estado = 1");
            return Database.consultaObtenerLista(consulta);
        }

        public static bool rolNombreYaExiste(string nombreRol)
        {
            SqlCommand consulta = consultaCrear("SELECT count(Rol_Nombre) FROM RIP.Roles WHERE Rol_Nombre = @nombreRol");
            consulta.Parameters.AddWithValue("@nombreRol", nombreRol);
            int resultado = Convert.ToInt32(Database.consultaObtenerValor(consulta));
            return resultado > 0;
        }

        public static bool rolEstaHabilitado(string nombreRol)
        {
            SqlCommand consulta = consultaCrear("SELECT Rol_Estado FROM RIP.Roles WHERE Rol_Nombre = @nombreRol");
            consulta.Parameters.AddWithValue("@nombreRol", nombreRol);
            return bool.Parse(Database.consultaObtenerValor(consulta));
        }

        public static bool rolNoTieneEsaFuncionalidad(string nombreRol, string nombreFuncionalidad)
        {
            string idRol = Database.rolObtenerId(nombreRol);
            string idFuncionalidad = Database.funcionalidadObtenerId(nombreFuncionalidad);
            SqlCommand consulta = consultaCrear("SELECT count(*) FROM RIP.Rol_Funcionalidad WHERE RolFunc_IdRol = @idRol AND RolFunc_IdFuncionalidad = @idFuncionalidad");
            consulta.Parameters.AddWithValue("@idRol", idRol);
            consulta.Parameters.AddWithValue("@idFuncionalidad", idFuncionalidad);
            int resultado = Convert.ToInt32(Database.consultaObtenerValor(consulta));
            return resultado == 0;
        }

        public static List<string> rolObtenerFuncionalidades(string nombreRol)
        {
            SqlCommand consulta = Database.consultaCrear("SELECT f.Funcionalidad_Funcionalidad FROM rip.Funcionalidades f INNER JOIN RIP.Rol_Funcionalidad rf ON f.Funcionalidad_Id = rf.RolFunc_IdFuncionalidad INNER JOIN RIP.Roles r ON rf.RolFunc_IdRol = r.Rol_ID WHERE r.Rol_Nombre = @nombreRol");
            consulta.Parameters.AddWithValue("@nombreRol", nombreRol);
            return Database.consultaObtenerLista(consulta);
        }

        public static List<string> rolObtenerFuncionalidadesFaltantes(string nombreRol)
        {
            SqlCommand consulta = Database.consultaCrear("SELECT Funcionalidad_Funcionalidad FROM RIP.Funcionalidades WHERE Funcionalidad_Id NOT IN (SELECT RolFunc_IdFuncionalidad FROM RIP.Rol_Funcionalidad INNER JOIN RIP.Roles ON RolFunc_IdRol = Rol_ID WHERE Rol_Nombre = @nombreRol)");
            consulta.Parameters.AddWithValue("@nombreRol", nombreRol);
            return Database.consultaObtenerLista(consulta);
        }

        //-------------------------------------- Metodos para Usuarios -------------------------------------

        public static List<string> usuarioObtenerHoteles(string nombreUsuario)
        {
            SqlConnection connection = obtenerConexion();

            SqlCommand hotelesquery = new SqlCommand("SELECT ci.Ciudades_Descripcion, c.Calles_Descripcion, d.Domicilio_Nro_calle FROM rip.Hoteles h JOIN RIP.Hotel_Usuario hu on hu.Hotel_Usuario_IdHotel = h.Hoteles_ID JOIN RIP.Usuarios u on u.Usuario_ID = hu.Hotel_Usuario_IdUsuario JOIN RIP.Domicilio d on d.Domicilio_ID = h.Hoteles_Domicilio_ID JOIN RIP.Calles c on c.Calles_ID = d.Domicilio_Calle_ID JOIN RIP.Ciudades ci on ci.Ciudades_ID = d.Domicilio_Ciudad_ID where u.Usuario_User = @username");
            hotelesquery.Parameters.AddWithValue("username", nombreUsuario);
            hotelesquery.Connection = connection;
            connection.Open();
            SqlDataReader reader = hotelesquery.ExecuteReader();

            List<string> hoteles = new List<string>();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    hoteles.Add(reader[0].ToString().TrimEnd() + " " + reader[1].ToString() + " " + reader[2].ToString());
                }
            }

            reader.Close();
            connection.Close();

            return hoteles;
        }
        
        public static bool usuarioTrabajaEnUnSoloHotel(string nombreUsuario)
        {
            SqlCommand consulta = Database.consultaCrear("SELECT count(Hotel_Usuario_IdHotel) FROM RIP.Hotel_Usuario JOIN RIP.Usuarios ON Hotel_Usuario_IdUsuario = Usuario_ID WHERE Usuario_User = @nombreUsuario");
            consulta.Parameters.AddWithValue("@nombreUsuario", nombreUsuario);
            int cantidadHoteles = Convert.ToInt32(Database.consultaObtenerValor(consulta));
            return cantidadHoteles == 1;
        }

        public static bool usuarioTrabajaEnVariosHoteles(string nombreUsuario)
        {
            return !Database.usuarioTrabajaEnUnSoloHotel(nombreUsuario);
        }

        public static bool usuarioTieneUnSoloRol(string nombreUsuario)
        {
            SqlCommand consulta = Database.consultaCrear("SELECT count(Rol_Nombre) FROM rip.Roles r INNER JOIN RIP.Usuario_Rol ur on r.Rol_ID = ur.Usuario_Rol_Rol_ID INNER JOIN RIP.Usuarios u on ur.Usuario_Rol_Usuario_ID = u.Usuario_ID where u.Usuario_User = @nombreUsuario");
            consulta.Parameters.AddWithValue("@nombreUsuario", nombreUsuario);
            int cantidadRoles = Convert.ToInt32(Database.consultaObtenerValor(consulta));
            return cantidadRoles == 1;
        }

        public static bool usuarioTieneVariosRoles(string nombreUsuario)
        {
            return !Database.usuarioTieneUnSoloRol(nombreUsuario);
        }

        public static List<string> usuarioObtenerRoles(string nombreUsuario)
        {
            SqlCommand consulta = consultaCrear("SELECT r.Rol_Nombre FROM rip.Roles r INNER JOIN RIP.Usuario_Rol ur on r.Rol_ID = ur.Usuario_Rol_Rol_ID INNER JOIN RIP.Usuarios u on ur.Usuario_Rol_Usuario_ID = u.Usuario_ID where u.Usuario_User = @nombreUsuario");
            consulta.Parameters.AddWithValue("@nombreUsuario", nombreUsuario);
            return Database.consultaObtenerLista(consulta);
        }

        public static List<string> usuarioObtenerRolesHabilitados(string nombreUsuario)
        {
            SqlCommand consulta = consultaCrear("SELECT r.Rol_Nombre FROM rip.Roles r INNER JOIN RIP.Usuario_Rol ur on r.Rol_ID = ur.Usuario_Rol_Rol_ID INNER JOIN RIP.Usuarios u on ur.Usuario_Rol_Usuario_ID = u.Usuario_ID where u.Usuario_User = @nombreUsuario and r.Rol_Estado = 1");
            consulta.Parameters.AddWithValue("@nombreUsuario", nombreUsuario);
            return Database.consultaObtenerLista(consulta);
        }

        public static DataTable usuarioObtenerTodos()
        {
            SqlCommand consulta = consultaCrear("SELECT Usuario_User, Persona_Nombre, Persona_Apellido, Persona_Tipo_Documento, Persona_Identificacion_Nro, Persona_Fecha_Nacimiento, Persona_Telefono, Persona_Mail, Ciudades_Descripcion, Calles_Descripcion, Domicilio_Nro_calle FROM RIP.Usuarios JOIN RIP.Persona ON Usuario_Persona_ID = Persona_ID JOIN RIP.Domicilio ON Persona_Domicilio_ID = Domicilio_ID JOIN RIP.Calles ON Domicilio_Calle_ID = Calles_ID JOIN RIP.Ciudades ON Domicilio_Ciudad_ID = Ciudades_ID");
            return Database.consultaObtenerTabla(consulta);
        }

        //-------------------------------------- Metodos para Usuarios -------------------------------------

        public static List<string> documentoObtenerTipos()
        {
            SqlCommand consulta = consultaCrear("SELECT TipoDocumento_Descripcion FROM RIP.TipoDocumento");
            return Database.consultaObtenerLista(consulta);
        }

        //-------------------------------------- Metodos para Hoteles -------------------------------------

        public static List<string> hotelObtenerTodos()
        {
            SqlConnection connection = obtenerConexion();

            SqlCommand hotelesquery = new SqlCommand("SELECT ci.Ciudades_Descripcion, c.Calles_Descripcion, d.Domicilio_Nro_calle FROM rip.Hoteles h JOIN RIP.Hotel_Usuario hu on hu.Hotel_Usuario_IdHotel = h.Hoteles_ID JOIN RIP.Usuarios u on u.Usuario_ID = hu.Hotel_Usuario_IdUsuario JOIN RIP.Domicilio d on d.Domicilio_ID = h.Hoteles_Domicilio_ID JOIN RIP.Calles c on c.Calles_ID = d.Domicilio_Calle_ID JOIN RIP.Ciudades ci on ci.Ciudades_ID = d.Domicilio_Ciudad_ID");
            hotelesquery.Connection = connection;
            connection.Open();
            SqlDataReader reader = hotelesquery.ExecuteReader();

            List<string> hoteles = new List<string>();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    hoteles.Add(reader[0].ToString().TrimEnd() + " " + reader[1].ToString() + " " + reader[2].ToString());
                }
            }

            reader.Close();
            connection.Close();

            return hoteles;
        }
    }
}