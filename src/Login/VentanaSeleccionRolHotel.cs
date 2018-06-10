﻿using FrbaHotel.Menus;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FrbaHotel.Clases;

namespace FrbaHotel.Login 
{
    public partial class VentanaSeleccionRolHotel : VentanaBase
    {
        //-------------------------------------- Atributos -------------------------------------

        Sesion sesion { get; set; }

        //-------------------------------------- Constructores -------------------------------------

        public VentanaSeleccionRolHotel(Sesion sesion)
        {
            InitializeComponent();
            this.sesion = sesion;  
            ventanaConfigurar();
        }

        //-------------------------------------- Metodos para Eventos -------------------------------------

        private void VentanaSeleccionRolHotel_Load(object sender, EventArgs e)
        {
            this.AcceptButton = btnIngresarRol;
            lblErrorRol.Hide();
        }

        private void VentanaSeleccionRol_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void ventanaConfigurar()
        {
            ventanaCargarRolesYHoteles();
            if (sesion.usuarioTrabajaEnUnSoloHotel() && sesion.usuarioTieneUnSoloRol())
                ventanaAbrirMenuPrincipal();
            else if (sesion.usuarioTrabajaEnUnSoloHotel() && sesion.usuarioTieneVariosRoles())
                ventanaConfigurarParaRol();
            else if (sesion.usuarioTrabajaEnVariosHoteles() && sesion.usuarioTieneUnSoloRol())
                ventanaConfigurarParaHotel();
            else
                ventanaConfigurarParaRolYHotel();
        }

        private void ventanaCargarRolesYHoteles()
        {
            comboBoxCargar(cbxHoteles, sesion.hoteles);
            comboBoxCargar(cbxRoles, sesion.roles);
        }

        private void ventanaConfigurarParaRol()
        {
            lblHotel.Hide();
            cbxHoteles.Hide();
            this.Show();
        }

        private void ventanaConfigurarParaHotel()
        {
            cbxRoles.Hide();
            lblRol.Hide();
            this.Show();
        }

        private void ventanaConfigurarParaRolYHotel()
        {
            this.Show();
        }

        public void ventanaConfigurarSesion()
        {
            sesion.rol = new Rol(cbxRoles.SelectedItem.ToString());
            //sesion.hotel = new Hotel(cbxHoteles.SelectedItem.ToString());
            sesion.funcionalidades = Database.rolObtenerFuncionalidades(sesion.rol);
        }

        private void btnIngresarRol_Click(object sender, EventArgs e)
        {
            this.Hide();
            ventanaAbrirMenuPrincipal();
        }

        private void ventanaAbrirMenuPrincipal()
        {
            ventanaConfigurarSesion();
            VentanaMenuPrincipal ventanaMenuPrincipal = new VentanaMenuPrincipal(sesion);
            ventanaMenuPrincipal.Show();
        }
    }
}
