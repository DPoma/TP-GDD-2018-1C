﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaHotel.Clases
{
    public class Hotel
    {
        //-------------------------------------- Atributos -------------------------------------

        public string id { get; set; }
        public string nombre { get; set; }
        public string cantidadEstrellas { get; set; }
        public string email { get; set; }
        public string telefono { get; set; }
        public DateTime fechaCreacion { get; set; }
        public string estado { get; set; }
        public Domicilio domicilio { get; set; }
        public List<string> regimenes { get; set; }

        //-------------------------------------- Constructores -------------------------------------

        public Hotel()
        {

        }

        public Hotel(string id)
        {
            this.id = id;
        }
        
        public Hotel(Domicilio domicilio)
        {
            this.domicilio = domicilio;
        }

        public Hotel(string id, string nombre, string cantidadEstrellas, DateTime fechaCreacion, string email, string telefono, Domicilio domicilio, List<string> regimenes, string estado)
        {
            this.id = id;
            this.nombre = nombre;
            this.cantidadEstrellas = cantidadEstrellas;
            this.fechaCreacion = fechaCreacion;
            this.email = email;
            this.telefono = telefono;
            this.domicilio = domicilio;
            this.regimenes = regimenes;
            this.estado = estado;
        }

        public Hotel(string nombre, string cantidadEstrellas, Domicilio domicilio)
        {
            this.nombre = nombre;
            this.cantidadEstrellas = cantidadEstrellas;
            this.domicilio = domicilio;
        }
    }
}
