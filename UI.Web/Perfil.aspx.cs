﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Entities;
using Business.Logic;
using Util;

namespace UI.Web
{
    public partial class Perfil : System.Web.UI.Page
    {
        private Usuario _UsuarioActual;
        public Usuario UsuarioActual { get => _UsuarioActual; set => _UsuarioActual = value; }

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["username"] != null && Session["tipo"] != null) {
                MapearDeDatos();
            }
            else {
                Response.Redirect("/login.aspx");
            }
            
        }

        private void MapearDeDatos() {
            UsuarioLogic ul = new UsuarioLogic();
            UsuarioActual = ul.GetOne(Session["username"].ToString());

            txtLegajo.Text = UsuarioActual.Legajo.ToString();
            txtNombre.Text = UsuarioActual.Nombre;
            txtApellido.Text = UsuarioActual.Apellido;
            txtUsername.Text = UsuarioActual.NombreUsuario;
            txtDirec.Text = UsuarioActual.Direccion;
            txtEmail.Text = UsuarioActual.Email;
            txtTel.Text = UsuarioActual.Telefono;
            txtFechaNac.Text = UsuarioActual.FechaNacimiento.ToString("dd/MM/yyyy");

        }
        private void MapearADatos() {
            UsuarioActual.Direccion = txtDirec.Text;
            UsuarioActual.Email = txtEmail.Text;
            UsuarioActual.Telefono = txtTel.Text;
            UsuarioActual.State = BusinessEntity.States.Modified;
        }
        protected void btnGuardar_Click(object sender, EventArgs e) {
            if (Validar()) {
                UsuarioLogic ul = new UsuarioLogic();
                UsuarioActual = ul.GetOne(Session["username"].ToString());

                MapearADatos();
                ul.Save(UsuarioActual);
                lblCambios.Visible = true;
                lblPass.Visible = false;
                alertSuccess.Visible = true;
            }
            UpdatePanelDatos.Update();
        }

        protected void btnPass_Click(object sender, EventArgs e) {
            txtNuevaPass1.Text = string.Empty;
            txtNuevaPass2.Text = string.Empty;
            txtViejaPass.Text = string.Empty;
            txtNuevaPass1.CssClass = "form-control";
            txtNuevaPass2.CssClass = "form-control";
            txtViejaPass.CssClass = "form-control";
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Pop", "$('#ModalPass').modal('show');", true);
            UpdatePanelModal.Update();

        }
        private bool Validar() {
            bool isvalid = true;

            if(string.IsNullOrEmpty(txtTel.Text) == true || int.Parse(txtTel.Text) == 0) {
                txtTel.CssClass = "form-control is-invalid";
                isvalid = false;
            }
            else {
                txtTel.CssClass = "form-control";
            }
            if (string.IsNullOrEmpty(txtDirec.Text) == true || string.IsNullOrWhiteSpace(txtDirec.Text)) {
                txtDirec.CssClass = "form-control is-invalid";
                isvalid = false;
            }
            else {
                txtDirec.CssClass = "form-control";
            }
            if(!new EmailAddressAttribute().IsValid(txtEmail.Text)) {
                txtEmail.CssClass = "form-control is-invalid";
                isvalid = false;
            }
            else {
                txtEmail.CssClass = "form-control";
            }
            return isvalid;
        }

        protected void btnAceptar_Click(object sender, EventArgs e) {
            UsuarioLogic ul = new UsuarioLogic();
            UsuarioActual = ul.GetOne(Session["username"].ToString());

            if (txtNuevaPass1.Text.Equals(txtNuevaPass2.Text) && Hashing.ValidatePassword(txtViejaPass.Text, UsuarioActual.Clave)) {
                UsuarioActual.Clave = Hashing.HashPassword(txtNuevaPass1.Text);
                ul.SavePassword(UsuarioActual);
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Pop", "$('#ModalPass').modal('hide');", true);
                lblCambios.Visible = false;
                lblPass.Visible = true;
                alertSuccess.Visible = true;
            }
            else {
                txtViejaPass.CssClass = "form-control is-invalid";
                txtNuevaPass1.CssClass = "form-control is-invalid";
                txtNuevaPass2.CssClass = "form-control is-invalid";
            }
            UpdatePanelModal.Update();
        }
    }
}