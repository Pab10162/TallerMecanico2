namespace UI.Formularios_Hijos
{
    partial class FormCambioContraseña
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtPasswordActual = new System.Windows.Forms.TextBox();
            this.txtConfirmacionPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNuevaPassword = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnVerActual = new System.Windows.Forms.Button();
            this.btnVerConfirmar = new System.Windows.Forms.Button();
            this.btnVerNueva = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(64, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Contraseña actual";
            // 
            // txtPasswordActual
            // 
            this.txtPasswordActual.Location = new System.Drawing.Point(184, 27);
            this.txtPasswordActual.Name = "txtPasswordActual";
            this.txtPasswordActual.PasswordChar = '*';
            this.txtPasswordActual.Size = new System.Drawing.Size(100, 20);
            this.txtPasswordActual.TabIndex = 1;
            // 
            // txtConfirmacionPassword
            // 
            this.txtConfirmacionPassword.Location = new System.Drawing.Point(184, 79);
            this.txtConfirmacionPassword.Name = "txtConfirmacionPassword";
            this.txtConfirmacionPassword.PasswordChar = '*';
            this.txtConfirmacionPassword.Size = new System.Drawing.Size(100, 20);
            this.txtConfirmacionPassword.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Confirme nueva contraseña";
            // 
            // txtNuevaPassword
            // 
            this.txtNuevaPassword.Location = new System.Drawing.Point(184, 53);
            this.txtNuevaPassword.Name = "txtNuevaPassword";
            this.txtNuevaPassword.PasswordChar = '*';
            this.txtNuevaPassword.Size = new System.Drawing.Size(100, 20);
            this.txtNuevaPassword.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(62, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Nueva contraseña";
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Location = new System.Drawing.Point(184, 117);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(75, 23);
            this.btnConfirmar.TabIndex = 6;
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(184, 146);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 7;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnVerActual
            // 
            this.btnVerActual.Location = new System.Drawing.Point(290, 27);
            this.btnVerActual.Name = "btnVerActual";
            this.btnVerActual.Size = new System.Drawing.Size(25, 20);
            this.btnVerActual.TabIndex = 8;
            this.btnVerActual.Text = "👁";
            this.btnVerActual.UseVisualStyleBackColor = true;
            this.btnVerActual.Click += new System.EventHandler(this.btnVerActual_Click);
            // 
            // btnVerConfirmar
            // 
            this.btnVerConfirmar.Location = new System.Drawing.Point(290, 79);
            this.btnVerConfirmar.Name = "btnVerConfirmar";
            this.btnVerConfirmar.Size = new System.Drawing.Size(25, 20);
            this.btnVerConfirmar.TabIndex = 9;
            this.btnVerConfirmar.Text = "👁";
            this.btnVerConfirmar.UseVisualStyleBackColor = true;
            this.btnVerConfirmar.Click += new System.EventHandler(this.btnVerConfirmar_Click);
            // 
            // btnVerNueva
            // 
            this.btnVerNueva.Location = new System.Drawing.Point(290, 53);
            this.btnVerNueva.Name = "btnVerNueva";
            this.btnVerNueva.Size = new System.Drawing.Size(25, 20);
            this.btnVerNueva.TabIndex = 10;
            this.btnVerNueva.Text = "👁";
            this.btnVerNueva.UseVisualStyleBackColor = true;
            this.btnVerNueva.Click += new System.EventHandler(this.btnVerNueva_Click);
            // 
            // FormCambioContraseña
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnVerNueva);
            this.Controls.Add(this.btnVerConfirmar);
            this.Controls.Add(this.btnVerActual);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.txtNuevaPassword);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtConfirmacionPassword);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPasswordActual);
            this.Controls.Add(this.label1);
            this.Name = "FormCambioContraseña";
            this.Text = "FormCambioContraseña";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPasswordActual;
        private System.Windows.Forms.TextBox txtConfirmacionPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNuevaPassword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnVerActual;
        private System.Windows.Forms.Button btnVerConfirmar;
        private System.Windows.Forms.Button btnVerNueva;
    }
}