﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FrbaHotel.Clases;

namespace FrbaHotel.AbmUsuario
{
    public partial class VentanaModificarUsuario : VentanaBase
    {

        #region Atributos

        VentanaUsuario ventanaUsuario {get; set;}
        Sesion sesion { get; set; }
        Usuario usuario { get; set; }

        #endregion

        #region Constructores

        public VentanaModificarUsuario(VentanaUsuario ventanaUsuario, Sesion sesion, Usuario usuario)
        {
            InitializeComponent();
            this.ventanaUsuario = ventanaUsuario;
            this.sesion = sesion;
            this.usuario = usuario;
        }

        #endregion
        
        #region Modificar

        private void VentanaModificarUsuario_Load(object sender, EventArgs e)
        {
            comboBoxCargar(cbxTipoDocumento, Database.tipoDocumentoObtenerTodosEnLista());
            cbxTipoDocumento.SelectedIndex = cbxTipoDocumento.Items.IndexOf(usuario.persona.tipoDocumento);
            tbxUsuario.Text = usuario.nombre;
            tbxContrasena.Text = usuario.contrasenia;        
            tbxNombre.Text = usuario.persona.nombre;
            tbxApellido.Text = usuario.persona.apellido;
            tbxDocumento.Text = usuario.persona.numeroDocumento;
            tbxFechaNacimiento.Text = usuario.persona.fechaNacimiento;
            tbxPais.Text = usuario.persona.domicilio.pais;
            tbxCiudad.Text = usuario.persona.domicilio.ciudad;
            tbxCalle.Text = usuario.persona.domicilio.calle;
            tbxNumeroCalle.Text = usuario.persona.domicilio.numeroCalle;
            tbxPiso.Text = usuario.persona.domicilio.piso;
            tbxDepartamento.Text = usuario.persona.domicilio.piso;
        }

        private void btnGuardarUsuario_Click(object sender, EventArgs e)
        {
            if (ventanaCamposEstanCompletos(this, controladorError))
            {
                Usuario usuarioModificado = ventanaCrearUsuarioModificado();
                if (true)//Database.usuarioModificadoConExito(usuarioModificado))
                {
                    btnLimpiarUsuario_Click(sender, e);
                    ventanaUsuario.VentanaUsuarios_Load(sender, e);
                }
            }
        }

        private Usuario ventanaCrearUsuarioModificado()
        {
            Domicilio domicilio = new Domicilio(tbxPais.Text, tbxCiudad.Text, tbxCalle.Text, tbxNumeroCalle.Text, tbxPiso.Text, tbxDepartamento.Text);
            Persona persona = new Persona(tbxNombre.Text, tbxApellido.Text, tbxFechaNacimiento.Text, cbxTipoDocumento.SelectedItem.ToString(), tbxDocumento.Text, tbxNacionalidad.Text, tbxTelefono.Text, tbxEmail.Text, domicilio);
            Usuario usuarioModificado = new Usuario(tbxUsuario.Text, tbxContrasena.Text, persona);
            usuarioModificado.id = usuario.id;
            return usuarioModificado;
        }

        #endregion

        #region Eventos 

        private void btnAgregarRol_Click(object sender, EventArgs e)
        {
            botonAgregarComboBoxListBox(cbxRoles, lbxRoles);
        }

        private void btnQuitarRol_Click(object sender, EventArgs e)
        {
            botonQuitarComboBoxListBox(cbxRoles, lbxRoles);
        }

        private void btnAgregarHotel_Click(object sender, EventArgs e)
        {
            botonAgregarComboBoxListBox(cbxHoteles, lbxHoteles);
        }

        private void btnQuitarHotel_Click(object sender, EventArgs e)
        {
            botonQuitarComboBoxListBox(cbxHoteles, lbxHoteles);
        }

        private void tbxUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBoxConfigurarParaCuenta(e);
            controladorError.Clear();
        }

        private void tbxNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBoxConfigurarParaLetras(e);
            controladorError.Clear();
        }

        private void tbxApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBoxConfigurarParaLetras(e);
            controladorError.Clear();
        }

        private void tbxDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBoxConfigurarParaNumeros(e);
            controladorError.Clear();
        }

        private void tbxNacionalidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBoxConfigurarParaLetras(e);
            controladorError.Clear();
        }

        private void tbxEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBoxConfigurarParaCuenta(e);
            controladorError.Clear();
        }

        private void tbxTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBoxConfigurarParaNumeros(e);
            controladorError.Clear();
        }

        private void tbxPais_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBoxConfigurarParaLetras(e);
            controladorError.Clear();
        }

        private void tbxCiudad_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBoxConfigurarParaLetras(e);
            controladorError.Clear();
        }

        private void tbxCalle_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBoxConfigurarParaLetras(e);
            controladorError.Clear();
        }

        private void tbxNumeroCalle_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBoxConfigurarParaNumeros(e);
            controladorError.Clear();
        }

        private void tbxPiso_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBoxConfigurarParaNumeros(e);
            controladorError.Clear();
        }

        private void tbxDepartamento_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBoxConfigurarParaLetras(e);
            controladorError.Clear();
        }

        private void btnLimpiarUsuario_Click(object sender, EventArgs e)
        {
            tbxUsuario.Clear();
            tbxContrasena.Clear();
            comboBoxCargar(cbxRoles, Database.rolObtenerTodosEnLista());
            listBoxLimpiar(lbxRoles);
            comboBoxCargar(cbxHoteles, Database.hotelObtenerTodosLista());
            listBoxLimpiar(lbxHoteles);
            tbxNombre.Clear();
            tbxApellido.Clear();
            tbxDocumento.Clear();
            comboBoxCargar(cbxTipoDocumento, Database.tipoDocumentoObtenerTodosEnLista());
            tbxFechaNacimiento.Clear();
            tbxPais.Clear();
            tbxCiudad.Clear();
            tbxCalle.Clear();
            tbxNumeroCalle.Clear();
            tbxPiso.Clear();
            tbxDepartamento.Clear();
            tbxEmail.Clear();
            tbxTelefono.Clear();
            controladorError.Clear();
        }

        private void btnSeleccionarFecha_Click(object sender, EventArgs e)
        {
            calendario.Show();
            btnGuardarFecha.Show();
            controladorError.Clear();
        }

        private void btnGuardarFecha_Click(object sender, EventArgs e)
        {
            tbxFechaNacimiento.Text = calendario.SelectionStart.ToShortDateString();
            calendario.Hide();
            btnGuardarFecha.Hide();
        }

        private void lbxRoles_SelectedIndexChanged(object sender, EventArgs e)
        {
            controladorError.Clear();
        }

        private void lbxHoteles_SelectedIndexChanged(object sender, EventArgs e)
        {
            controladorError.Clear();
        }

        private void tbxContrasena_TextChanged(object sender, EventArgs e)
        {
            controladorError.Clear();
        }
        #endregion
    }   
}
