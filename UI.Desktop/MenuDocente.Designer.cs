﻿namespace UI.Desktop {
    partial class MenuDocente {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.txtTitle = new System.Windows.Forms.Label();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnComisiones = new System.Windows.Forms.Button();
            this.btnMaterias = new System.Windows.Forms.Button();
            this.btnEspecialidades = new System.Windows.Forms.Button();
            this.btnPlanes = new System.Windows.Forms.Button();
            this.btnUsuarios = new System.Windows.Forms.Button();
            this.btnInscripciones = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtTitle
            // 
            this.txtTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTitle.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTitle.Location = new System.Drawing.Point(62, 9);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(260, 23);
            this.txtTitle.TabIndex = 13;
            this.txtTitle.Text = "Menu Docente";
            this.txtTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(302, 196);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 23);
            this.btnSalir.TabIndex = 12;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // btnComisiones
            // 
            this.btnComisiones.Location = new System.Drawing.Point(11, 167);
            this.btnComisiones.Name = "btnComisiones";
            this.btnComisiones.Size = new System.Drawing.Size(126, 23);
            this.btnComisiones.TabIndex = 11;
            this.btnComisiones.Text = "Comisiones";
            this.btnComisiones.UseVisualStyleBackColor = true;
            // 
            // btnMaterias
            // 
            this.btnMaterias.Location = new System.Drawing.Point(11, 138);
            this.btnMaterias.Name = "btnMaterias";
            this.btnMaterias.Size = new System.Drawing.Size(127, 23);
            this.btnMaterias.TabIndex = 10;
            this.btnMaterias.Text = "Materias";
            this.btnMaterias.UseVisualStyleBackColor = true;
            // 
            // btnEspecialidades
            // 
            this.btnEspecialidades.Location = new System.Drawing.Point(11, 109);
            this.btnEspecialidades.Name = "btnEspecialidades";
            this.btnEspecialidades.Size = new System.Drawing.Size(127, 23);
            this.btnEspecialidades.TabIndex = 9;
            this.btnEspecialidades.Text = "Especialidades";
            this.btnEspecialidades.UseVisualStyleBackColor = true;
            // 
            // btnPlanes
            // 
            this.btnPlanes.Location = new System.Drawing.Point(11, 80);
            this.btnPlanes.Name = "btnPlanes";
            this.btnPlanes.Size = new System.Drawing.Size(127, 23);
            this.btnPlanes.TabIndex = 8;
            this.btnPlanes.Text = "Planes";
            this.btnPlanes.UseVisualStyleBackColor = true;
            // 
            // btnUsuarios
            // 
            this.btnUsuarios.Location = new System.Drawing.Point(11, 51);
            this.btnUsuarios.Name = "btnUsuarios";
            this.btnUsuarios.Size = new System.Drawing.Size(127, 23);
            this.btnUsuarios.TabIndex = 7;
            this.btnUsuarios.Text = "Usuarios";
            this.btnUsuarios.UseVisualStyleBackColor = true;
            // 
            // btnInscripciones
            // 
            this.btnInscripciones.Location = new System.Drawing.Point(12, 196);
            this.btnInscripciones.Name = "btnInscripciones";
            this.btnInscripciones.Size = new System.Drawing.Size(126, 23);
            this.btnInscripciones.TabIndex = 14;
            this.btnInscripciones.Text = "Inscripciones";
            this.btnInscripciones.UseVisualStyleBackColor = true;
            // 
            // MenuDocente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(389, 224);
            this.Controls.Add(this.btnInscripciones);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnComisiones);
            this.Controls.Add(this.btnMaterias);
            this.Controls.Add(this.btnEspecialidades);
            this.Controls.Add(this.btnPlanes);
            this.Controls.Add(this.btnUsuarios);
            this.Name = "MenuDocente";
            this.Text = "MenuDocente";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label txtTitle;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnComisiones;
        private System.Windows.Forms.Button btnMaterias;
        private System.Windows.Forms.Button btnEspecialidades;
        private System.Windows.Forms.Button btnPlanes;
        private System.Windows.Forms.Button btnUsuarios;
        private System.Windows.Forms.Button btnInscripciones;
    }
}