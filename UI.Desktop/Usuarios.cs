﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Entities;
using Business.Logic;

namespace UI.Desktop
{
    public partial class Usuarios : Form
    {
        public Usuarios(){
            InitializeComponent();
            this.dgvUsuarios.AutoGenerateColumns = false;
        }

        public void Listar() {
            UsuarioLogic ul = new UsuarioLogic();
            List<Usuario> usuarios = ul.GetAll();
            if (usuarios.Count() == 0)
            {
                MessageBox.Show("No hay usuarios cargados!");
            }
            this.dgvUsuarios.DataSource = usuarios;
        }

        private void Usuarios_Load(object sender, EventArgs e) {
            Listar();
        }


        private void btnSalir_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void tsbNuevo_Click(object sender, EventArgs e) {
            UsuarioDesktop usuarioDesktop = new UsuarioDesktop(ApplicationForm.ModoForm.Alta);
            usuarioDesktop.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e) {
            if (this.dgvUsuarios.SelectedRows.Count != 0) {
                int ID = ((Business.Entities.Usuario)this.dgvUsuarios.SelectedRows[0].DataBoundItem).ID;
                UsuarioDesktop usuarioDesktop = new UsuarioDesktop(ID, ApplicationForm.ModoForm.Modificacion);
                usuarioDesktop.ShowDialog();
                this.Listar();
            }
        }

        private void tsbEliminar_Click(object sender, EventArgs e) {
            if (this.dgvUsuarios.SelectedRows.Count != 0) {
                int ID = ((Business.Entities.Usuario)this.dgvUsuarios.SelectedRows[0].DataBoundItem).ID;
                UsuarioDesktop usuarioDesktop = new UsuarioDesktop(ID, ApplicationForm.ModoForm.Baja);
                usuarioDesktop.ShowDialog();
                this.Listar();
            }
        }

        private void tsbConsultar_Click(object sender, EventArgs e) {
            if (this.dgvUsuarios.SelectedRows.Count != 0) {
                int ID = ((Business.Entities.Usuario)this.dgvUsuarios.SelectedRows[0].DataBoundItem).ID;
                UsuarioDesktop usuarioDesktop = new UsuarioDesktop(ID, ApplicationForm.ModoForm.Consulta);
                usuarioDesktop.ShowDialog();
                this.Listar();
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Listar();
        }
    }
}