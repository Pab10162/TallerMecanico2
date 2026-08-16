namespace UI
{
    partial class Form_ABMUsuario
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
            this.btnDesbloquear = new System.Windows.Forms.Button();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnActivarDesactivar = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbRol = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAplicar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnCrear = new System.Windows.Forms.Button();
            this.dgvUsuarios = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDNI = new System.Windows.Forms.TextBox();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.ckbActivo = new System.Windows.Forms.CheckBox();
            this.ckbBloqueado = new System.Windows.Forms.CheckBox();
            this.panelCampos = new System.Windows.Forms.Panel();
            this.labelModo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).BeginInit();
            this.panelCampos.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnDesbloquear
            // 
            this.btnDesbloquear.Location = new System.Drawing.Point(553, 181);
            this.btnDesbloquear.Name = "btnDesbloquear";
            this.btnDesbloquear.Size = new System.Drawing.Size(75, 38);
            this.btnDesbloquear.TabIndex = 54;
            this.btnDesbloquear.Tag = "CancelarButton";
            this.btnDesbloquear.Text = "Desbloquear";
            this.btnDesbloquear.UseVisualStyleBackColor = true;
            this.btnDesbloquear.Click += new System.EventHandler(this.btnDesbloquear_Click);
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(398, 25);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(81, 17);
            this.radioButton3.TabIndex = 53;
            this.radioButton3.Tag = "ActivosCheckBox";
            this.radioButton3.Text = "Bloqueados";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(713, 359);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 23);
            this.btnSalir.TabIndex = 52;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnActivarDesactivar
            // 
            this.btnActivarDesactivar.Location = new System.Drawing.Point(553, 137);
            this.btnActivarDesactivar.Name = "btnActivarDesactivar";
            this.btnActivarDesactivar.Size = new System.Drawing.Size(75, 38);
            this.btnActivarDesactivar.TabIndex = 50;
            this.btnActivarDesactivar.Tag = "CancelarButton";
            this.btnActivarDesactivar.Text = "Act. / Desact.";
            this.btnActivarDesactivar.UseVisualStyleBackColor = true;
            this.btnActivarDesactivar.Click += new System.EventHandler(this.btnActivarDesactivar_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(171, 11);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(23, 13);
            this.label7.TabIndex = 49;
            this.label7.Tag = "labelRol";
            this.label7.Text = "Rol";
            // 
            // cmbRol
            // 
            this.cmbRol.FormattingEnabled = true;
            this.cmbRol.Items.AddRange(new object[] {
            "Recepcionista",
            "Jefe de Taller",
            "Mecanico",
            "Cajero ",
            "Administrador"});
            this.cmbRol.Location = new System.Drawing.Point(200, 10);
            this.cmbRol.Name = "cmbRol";
            this.cmbRol.Size = new System.Drawing.Size(121, 21);
            this.cmbRol.TabIndex = 48;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(561, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 13);
            this.label2.TabIndex = 46;
            this.label2.Tag = "NumeroDeUsuariosCheckBox";
            this.label2.Text = "Numero de usuarios: ";
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(481, 25);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(55, 17);
            this.radioButton2.TabIndex = 45;
            this.radioButton2.TabStop = true;
            this.radioButton2.Tag = "TodosCheckBox";
            this.radioButton2.Text = "Todos";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(332, 25);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(60, 17);
            this.radioButton1.TabIndex = 44;
            this.radioButton1.Tag = "ActivosCheckBox";
            this.radioButton1.Text = "Activos";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(713, 120);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 37);
            this.btnCancelar.TabIndex = 43;
            this.btnCancelar.Tag = "CancelarButton";
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAplicar
            // 
            this.btnAplicar.Location = new System.Drawing.Point(713, 68);
            this.btnAplicar.Name = "btnAplicar";
            this.btnAplicar.Size = new System.Drawing.Size(75, 37);
            this.btnAplicar.TabIndex = 42;
            this.btnAplicar.Tag = "AplicarButton";
            this.btnAplicar.Text = "Aplicar";
            this.btnAplicar.UseVisualStyleBackColor = true;
            this.btnAplicar.Click += new System.EventHandler(this.btnAplicar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(553, 108);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(75, 23);
            this.btnModificar.TabIndex = 41;
            this.btnModificar.Tag = "ModificarButton";
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnCrear
            // 
            this.btnCrear.Location = new System.Drawing.Point(553, 79);
            this.btnCrear.Name = "btnCrear";
            this.btnCrear.Size = new System.Drawing.Size(75, 23);
            this.btnCrear.TabIndex = 40;
            this.btnCrear.Tag = "CrearButton";
            this.btnCrear.Text = "Crear";
            this.btnCrear.UseVisualStyleBackColor = true;
            this.btnCrear.Click += new System.EventHandler(this.btnCrear_Click);
            // 
            // dgvUsuarios
            // 
            this.dgvUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsuarios.Location = new System.Drawing.Point(33, 81);
            this.dgvUsuarios.Name = "dgvUsuarios";
            this.dgvUsuarios.ReadOnly = true;
            this.dgvUsuarios.Size = new System.Drawing.Size(514, 138);
            this.dgvUsuarios.TabIndex = 39;
            this.dgvUsuarios.SelectionChanged += new System.EventHandler(this.dgvUsuarios_SelectionChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F);
            this.label1.Location = new System.Drawing.Point(28, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 29);
            this.label1.TabIndex = 38;
            this.label1.Tag = "UsuariosLabel";
            this.label1.Text = "Usuarios";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 13);
            this.label3.TabIndex = 0;
            this.label3.Tag = "DniLabel2";
            this.label3.Text = "DNI";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 1;
            this.label4.Tag = "ApellidoLabel2";
            this.label4.Text = "Apellido";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 68);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 2;
            this.label5.Tag = "NombreLabel2";
            this.label5.Text = "Nombre";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 93);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 13);
            this.label6.TabIndex = 3;
            this.label6.Tag = "EmailLabel2";
            this.label6.Text = "Email";
            // 
            // txtDNI
            // 
            this.txtDNI.Location = new System.Drawing.Point(56, 11);
            this.txtDNI.Name = "txtDNI";
            this.txtDNI.Size = new System.Drawing.Size(100, 20);
            this.txtDNI.TabIndex = 8;
            // 
            // txtApellido
            // 
            this.txtApellido.Location = new System.Drawing.Point(56, 36);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(100, 20);
            this.txtApellido.TabIndex = 9;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(56, 61);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(100, 20);
            this.txtNombre.TabIndex = 10;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(56, 86);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(100, 20);
            this.txtEmail.TabIndex = 11;
            // 
            // ckbActivo
            // 
            this.ckbActivo.AutoSize = true;
            this.ckbActivo.Checked = true;
            this.ckbActivo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbActivo.Location = new System.Drawing.Point(56, 108);
            this.ckbActivo.Name = "ckbActivo";
            this.ckbActivo.Size = new System.Drawing.Size(56, 17);
            this.ckbActivo.TabIndex = 14;
            this.ckbActivo.Tag = "ActivoCheckBox";
            this.ckbActivo.Text = "Activo";
            this.ckbActivo.UseVisualStyleBackColor = true;
            // 
            // ckbBloqueado
            // 
            this.ckbBloqueado.AutoSize = true;
            this.ckbBloqueado.Location = new System.Drawing.Point(56, 131);
            this.ckbBloqueado.Name = "ckbBloqueado";
            this.ckbBloqueado.Size = new System.Drawing.Size(77, 17);
            this.ckbBloqueado.TabIndex = 15;
            this.ckbBloqueado.Tag = "BloqueadoCheckBox";
            this.ckbBloqueado.Text = "Bloqueado";
            this.ckbBloqueado.UseVisualStyleBackColor = true;
            // 
            // panelCampos
            // 
            this.panelCampos.Controls.Add(this.txtApellido);
            this.panelCampos.Controls.Add(this.ckbBloqueado);
            this.panelCampos.Controls.Add(this.label3);
            this.panelCampos.Controls.Add(this.ckbActivo);
            this.panelCampos.Controls.Add(this.label4);
            this.panelCampos.Controls.Add(this.label5);
            this.panelCampos.Controls.Add(this.cmbRol);
            this.panelCampos.Controls.Add(this.txtEmail);
            this.panelCampos.Controls.Add(this.label6);
            this.panelCampos.Controls.Add(this.label7);
            this.panelCampos.Controls.Add(this.txtNombre);
            this.panelCampos.Controls.Add(this.txtDNI);
            this.panelCampos.Location = new System.Drawing.Point(33, 225);
            this.panelCampos.Name = "panelCampos";
            this.panelCampos.Size = new System.Drawing.Size(326, 151);
            this.panelCampos.TabIndex = 55;
            // 
            // labelModo
            // 
            this.labelModo.AutoSize = true;
            this.labelModo.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F);
            this.labelModo.Location = new System.Drawing.Point(476, 227);
            this.labelModo.Name = "labelModo";
            this.labelModo.Size = new System.Drawing.Size(76, 29);
            this.labelModo.TabIndex = 56;
            this.labelModo.Tag = "UsuariosLabel";
            this.labelModo.Text = "Modo";
            // 
            // Form_ABMUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 393);
            this.Controls.Add(this.labelModo);
            this.Controls.Add(this.panelCampos);
            this.Controls.Add(this.btnDesbloquear);
            this.Controls.Add(this.radioButton3);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnActivarDesactivar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAplicar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnCrear);
            this.Controls.Add(this.dgvUsuarios);
            this.Controls.Add(this.label1);
            this.Name = "Form_ABMUsuario";
            this.Text = "Form_ABMUsuario";
            this.Load += new System.EventHandler(this.Form_ABMUsuario_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).EndInit();
            this.panelCampos.ResumeLayout(false);
            this.panelCampos.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDesbloquear;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnActivarDesactivar;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbRol;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAplicar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnCrear;
        private System.Windows.Forms.DataGridView dgvUsuarios;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDNI;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.CheckBox ckbActivo;
        private System.Windows.Forms.CheckBox ckbBloqueado;
        private System.Windows.Forms.Panel panelCampos;
        private System.Windows.Forms.Label labelModo;
    }
}