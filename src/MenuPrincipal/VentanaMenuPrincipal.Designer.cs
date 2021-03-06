﻿namespace FrbaHotel.Menus
{
    partial class VentanaMenuPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuAdministracion = new System.Windows.Forms.ToolStripMenuItem();
            this.menuUsuarios = new System.Windows.Forms.ToolStripMenuItem();
            this.menuHoteles = new System.Windows.Forms.ToolStripMenuItem();
            this.menuHabitaciones = new System.Windows.Forms.ToolStripMenuItem();
            this.menuRoles = new System.Windows.Forms.ToolStripMenuItem();
            this.menuRegimenes = new System.Windows.Forms.ToolStripMenuItem();
            this.menuRecepcion = new System.Windows.Forms.ToolStripMenuItem();
            this.menuReservas = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFacturas = new System.Windows.Forms.ToolStripMenuItem();
            this.menuClientes = new System.Windows.Forms.ToolStripMenuItem();
            this.menuConsumibles = new System.Windows.Forms.ToolStripMenuItem();
            this.menuEstadias = new System.Windows.Forms.ToolStripMenuItem();
            this.menuEstadisticas = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCuenta = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDetallesDeSesion = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCambiarContrasenia = new System.Windows.Forms.ToolStripMenuItem();
            this.nenuCerrarSesion = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevaReservaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modificarReservaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cancelarResrvaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.logo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.controladorError)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // logo
            // 
            this.logo.BackgroundImage = global::FrbaHotel.Properties.Resources.Logo_TP;
            this.logo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.logo.Image = null;
            this.logo.Location = new System.Drawing.Point(56, 65);
            this.logo.Size = new System.Drawing.Size(245, 196);
            this.logo.Visible = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuAdministracion,
            this.menuRecepcion,
            this.menuEstadisticas,
            this.menuCuenta});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(448, 24);
            this.menuStrip1.TabIndex = 27;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuAdministracion
            // 
            this.menuAdministracion.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuUsuarios,
            this.menuHoteles,
            this.menuHabitaciones,
            this.menuRoles,
            this.menuRegimenes});
            this.menuAdministracion.Name = "menuAdministracion";
            this.menuAdministracion.Size = new System.Drawing.Size(100, 20);
            this.menuAdministracion.Text = "Administracion";
            // 
            // menuUsuarios
            // 
            this.menuUsuarios.Name = "menuUsuarios";
            this.menuUsuarios.Size = new System.Drawing.Size(143, 22);
            this.menuUsuarios.Text = "Usuarios";
            this.menuUsuarios.Visible = false;
            this.menuUsuarios.Click += new System.EventHandler(this.menuUsuarios_Click);
            // 
            // menuHoteles
            // 
            this.menuHoteles.Name = "menuHoteles";
            this.menuHoteles.Size = new System.Drawing.Size(143, 22);
            this.menuHoteles.Text = "Hoteles";
            this.menuHoteles.Visible = false;
            this.menuHoteles.Click += new System.EventHandler(this.menuHoteles_Click);
            // 
            // menuHabitaciones
            // 
            this.menuHabitaciones.Name = "menuHabitaciones";
            this.menuHabitaciones.Size = new System.Drawing.Size(143, 22);
            this.menuHabitaciones.Text = "Habitaciones";
            this.menuHabitaciones.Visible = false;
            this.menuHabitaciones.Click += new System.EventHandler(this.menuHabitaciones_Click);
            // 
            // menuRoles
            // 
            this.menuRoles.Name = "menuRoles";
            this.menuRoles.Size = new System.Drawing.Size(143, 22);
            this.menuRoles.Text = "Roles";
            this.menuRoles.Visible = false;
            this.menuRoles.Click += new System.EventHandler(this.menuRoles_Click);
            // 
            // menuRegimenes
            // 
            this.menuRegimenes.Name = "menuRegimenes";
            this.menuRegimenes.Size = new System.Drawing.Size(143, 22);
            this.menuRegimenes.Text = "Regimenes";
            this.menuRegimenes.Visible = false;
            this.menuRegimenes.Click += new System.EventHandler(this.menuRegimenes_Click);
            // 
            // menuRecepcion
            // 
            this.menuRecepcion.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuReservas,
            this.menuFacturas,
            this.menuClientes,
            this.menuConsumibles,
            this.menuEstadias});
            this.menuRecepcion.Name = "menuRecepcion";
            this.menuRecepcion.Size = new System.Drawing.Size(74, 20);
            this.menuRecepcion.Text = "Recepcion";
            // 
            // menuReservas
            // 
            this.menuReservas.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevaReservaToolStripMenuItem,
            this.modificarReservaToolStripMenuItem,
            this.cancelarResrvaToolStripMenuItem});
            this.menuReservas.Name = "menuReservas";
            this.menuReservas.Size = new System.Drawing.Size(152, 22);
            this.menuReservas.Text = "Reservas";
            this.menuReservas.Visible = false;
            // 
            // menuFacturas
            // 
            this.menuFacturas.Name = "menuFacturas";
            this.menuFacturas.Size = new System.Drawing.Size(152, 22);
            this.menuFacturas.Text = "Facturas";
            this.menuFacturas.Visible = false;
            this.menuFacturas.Click += new System.EventHandler(this.menuFacturas_Click);
            // 
            // menuClientes
            // 
            this.menuClientes.Name = "menuClientes";
            this.menuClientes.Size = new System.Drawing.Size(152, 22);
            this.menuClientes.Text = "Clientes";
            this.menuClientes.Visible = false;
            this.menuClientes.Click += new System.EventHandler(this.menuClientes_Click);
            // 
            // menuConsumibles
            // 
            this.menuConsumibles.Name = "menuConsumibles";
            this.menuConsumibles.Size = new System.Drawing.Size(152, 22);
            this.menuConsumibles.Text = "Consumibles";
            this.menuConsumibles.Visible = false;
            this.menuConsumibles.Click += new System.EventHandler(this.menuConsumibles_Click);
            // 
            // menuEstadias
            // 
            this.menuEstadias.Name = "menuEstadias";
            this.menuEstadias.Size = new System.Drawing.Size(152, 22);
            this.menuEstadias.Text = "Estadias";
            this.menuEstadias.Visible = false;
            this.menuEstadias.Click += new System.EventHandler(this.menuEstadias_Click);
            // 
            // menuEstadisticas
            // 
            this.menuEstadisticas.Name = "menuEstadisticas";
            this.menuEstadisticas.Size = new System.Drawing.Size(79, 20);
            this.menuEstadisticas.Text = "Estadisticas";
            this.menuEstadisticas.Click += new System.EventHandler(this.menuEstadisticas_Click);
            // 
            // menuCuenta
            // 
            this.menuCuenta.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuDetallesDeSesion,
            this.menuCambiarContrasenia,
            this.nenuCerrarSesion});
            this.menuCuenta.Name = "menuCuenta";
            this.menuCuenta.Size = new System.Drawing.Size(57, 20);
            this.menuCuenta.Text = "Cuenta";
            // 
            // menuDetallesDeSesion
            // 
            this.menuDetallesDeSesion.Name = "menuDetallesDeSesion";
            this.menuDetallesDeSesion.Size = new System.Drawing.Size(180, 22);
            this.menuDetallesDeSesion.Text = "Detalles de sesion";
            this.menuDetallesDeSesion.Click += new System.EventHandler(this.menuDetallesDeSesion_Click);
            // 
            // menuCambiarContrasenia
            // 
            this.menuCambiarContrasenia.Name = "menuCambiarContrasenia";
            this.menuCambiarContrasenia.Size = new System.Drawing.Size(180, 22);
            this.menuCambiarContrasenia.Text = "Cambiar contraseña";
            this.menuCambiarContrasenia.Click += new System.EventHandler(this.menuCambiarContrasenia_Click);
            // 
            // nenuCerrarSesion
            // 
            this.nenuCerrarSesion.Name = "nenuCerrarSesion";
            this.nenuCerrarSesion.Size = new System.Drawing.Size(180, 22);
            this.nenuCerrarSesion.Text = "Cerrar sesion";
            this.nenuCerrarSesion.Click += new System.EventHandler(this.nenuCerrarSesion_Click);
            // 
            // nuevaReservaToolStripMenuItem
            // 
            this.nuevaReservaToolStripMenuItem.Name = "nuevaReservaToolStripMenuItem";
            this.nuevaReservaToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.nuevaReservaToolStripMenuItem.Text = "Nueva reserva";
            this.nuevaReservaToolStripMenuItem.Click += new System.EventHandler(this.nuevaReservaToolStripMenuItem_Click);
            // 
            // modificarReservaToolStripMenuItem
            // 
            this.modificarReservaToolStripMenuItem.Name = "modificarReservaToolStripMenuItem";
            this.modificarReservaToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.modificarReservaToolStripMenuItem.Text = "Modificar reserva";
            this.modificarReservaToolStripMenuItem.Click += new System.EventHandler(this.modificarReservaToolStripMenuItem_Click);
            // 
            // cancelarResrvaToolStripMenuItem
            // 
            this.cancelarResrvaToolStripMenuItem.Name = "cancelarResrvaToolStripMenuItem";
            this.cancelarResrvaToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.cancelarResrvaToolStripMenuItem.Text = "Cancelar resrva";
            this.cancelarResrvaToolStripMenuItem.Click += new System.EventHandler(this.cancelarResrvaToolStripMenuItem_Click);
            // 
            // VentanaMenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::FrbaHotel.Properties.Resources.Logo_TP;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(448, 436);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.IsMdiContainer = true;
            this.Name = "VentanaMenuPrincipal";
            this.Text = "Menu Principal - FRBA Hotel ©";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.VentanaMenuPrincipal_FormClosed);
            this.Load += new System.EventHandler(this.VentanaMenuPrincipal_Load);
            this.Controls.SetChildIndex(this.menuStrip1, 0);
            this.Controls.SetChildIndex(this.logo, 0);
            ((System.ComponentModel.ISupportInitialize)(this.logo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.controladorError)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuAdministracion;
        private System.Windows.Forms.ToolStripMenuItem menuRoles;
        private System.Windows.Forms.ToolStripMenuItem menuUsuarios;
        private System.Windows.Forms.ToolStripMenuItem menuHoteles;
        private System.Windows.Forms.ToolStripMenuItem menuRecepcion;
        private System.Windows.Forms.ToolStripMenuItem menuClientes;
        private System.Windows.Forms.ToolStripMenuItem menuReservas;
        private System.Windows.Forms.ToolStripMenuItem menuEstadias;
        private System.Windows.Forms.ToolStripMenuItem menuHabitaciones;
        private System.Windows.Forms.ToolStripMenuItem menuRegimenes;
        private System.Windows.Forms.ToolStripMenuItem menuConsumibles;
        private System.Windows.Forms.ToolStripMenuItem menuFacturas;
        private System.Windows.Forms.ToolStripMenuItem menuCuenta;
        private System.Windows.Forms.ToolStripMenuItem menuCambiarContrasenia;
        private System.Windows.Forms.ToolStripMenuItem nenuCerrarSesion;
        private System.Windows.Forms.ToolStripMenuItem menuEstadisticas;
        private System.Windows.Forms.ToolStripMenuItem menuDetallesDeSesion;
        private System.Windows.Forms.ToolStripMenuItem nuevaReservaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modificarReservaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cancelarResrvaToolStripMenuItem;
    }
}