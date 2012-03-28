namespace GestionARBA
{
    partial class frmPadronArba
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
            this.btnCerrar = new System.Windows.Forms.Button();
            this.txtURL = new System.Windows.Forms.TextBox();
            this.txtUsr = new System.Windows.Forms.TextBox();
            this.txtPwd = new System.Windows.Forms.TextBox();
            this.btnEnviar = new System.Windows.Forms.Button();
            this.txtFile = new System.Windows.Forms.TextBox();
            this.lblURL = new System.Windows.Forms.Label();
            this.lblUsr = new System.Windows.Forms.Label();
            this.lblPwd = new System.Windows.Forms.Label();
            this.lblArchivo = new System.Windows.Forms.Label();
            this.ofdAbrirArchivo = new System.Windows.Forms.OpenFileDialog();
            this.btnSeleccionaArchivo = new System.Windows.Forms.Button();
            this.lblEstado = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(563, 234);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(88, 22);
            this.btnCerrar.TabIndex = 0;
            this.btnCerrar.Text = "&Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // txtURL
            // 
            this.txtURL.Location = new System.Drawing.Point(196, 81);
            this.txtURL.Name = "txtURL";
            this.txtURL.Size = new System.Drawing.Size(455, 20);
            this.txtURL.TabIndex = 1;
            this.txtURL.Text = "http://dfe.ec.gba.gov.ar/DomicilioElectronico/SeguridadCliente/dfeServicioDescarg" +
                "aPadron.do";
            this.txtURL.TextChanged += new System.EventHandler(this.txtURL_TextChanged);
            // 
            // txtUsr
            // 
            this.txtUsr.Location = new System.Drawing.Point(196, 117);
            this.txtUsr.Name = "txtUsr";
            this.txtUsr.Size = new System.Drawing.Size(83, 20);
            this.txtUsr.TabIndex = 2;
            this.txtUsr.Text = "11111111111";
            this.txtUsr.TextChanged += new System.EventHandler(this.txtUsr_TextChanged);
            // 
            // txtPwd
            // 
            this.txtPwd.Location = new System.Drawing.Point(196, 153);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.Size = new System.Drawing.Size(83, 20);
            this.txtPwd.TabIndex = 3;
            this.txtPwd.Text = "123412";
            this.txtPwd.TextChanged += new System.EventHandler(this.txtPwd_TextChanged);
            // 
            // btnEnviar
            // 
            this.btnEnviar.Location = new System.Drawing.Point(196, 234);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(100, 22);
            this.btnEnviar.TabIndex = 4;
            this.btnEnviar.Text = "&Enviar";
            this.btnEnviar.UseVisualStyleBackColor = true;
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            // 
            // txtFile
            // 
            this.txtFile.Location = new System.Drawing.Point(196, 188);
            this.txtFile.Name = "txtFile";
            this.txtFile.Size = new System.Drawing.Size(371, 20);
            this.txtFile.TabIndex = 5;
            this.txtFile.Text = "C:\\arba\\DFEServicioDescargaPadron.xml";
            this.txtFile.TextChanged += new System.EventHandler(this.txtFile_TextChanged);
            // 
            // lblURL
            // 
            this.lblURL.AutoSize = true;
            this.lblURL.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblURL.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblURL.Location = new System.Drawing.Point(122, 88);
            this.lblURL.Name = "lblURL";
            this.lblURL.Size = new System.Drawing.Size(68, 13);
            this.lblURL.TabIndex = 7;
            this.lblURL.Text = "Url Server:";
            // 
            // lblUsr
            // 
            this.lblUsr.AutoSize = true;
            this.lblUsr.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsr.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblUsr.Location = new System.Drawing.Point(122, 120);
            this.lblUsr.Name = "lblUsr";
            this.lblUsr.Size = new System.Drawing.Size(54, 13);
            this.lblUsr.TabIndex = 8;
            this.lblUsr.Text = "Usuario:";
            // 
            // lblPwd
            // 
            this.lblPwd.AutoSize = true;
            this.lblPwd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPwd.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblPwd.Location = new System.Drawing.Point(122, 156);
            this.lblPwd.Name = "lblPwd";
            this.lblPwd.Size = new System.Drawing.Size(65, 13);
            this.lblPwd.TabIndex = 9;
            this.lblPwd.Text = "Password:";
            // 
            // lblArchivo
            // 
            this.lblArchivo.AutoSize = true;
            this.lblArchivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblArchivo.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblArchivo.Location = new System.Drawing.Point(122, 191);
            this.lblArchivo.Name = "lblArchivo";
            this.lblArchivo.Size = new System.Drawing.Size(54, 13);
            this.lblArchivo.TabIndex = 10;
            this.lblArchivo.Text = "Archivo:";
            // 
            // ofdAbrirArchivo
            // 
            this.ofdAbrirArchivo.FileName = "openFileDialog1";
            // 
            // btnSeleccionaArchivo
            // 
            this.btnSeleccionaArchivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSeleccionaArchivo.Location = new System.Drawing.Point(573, 186);
            this.btnSeleccionaArchivo.Name = "btnSeleccionaArchivo";
            this.btnSeleccionaArchivo.Size = new System.Drawing.Size(28, 22);
            this.btnSeleccionaArchivo.TabIndex = 11;
            this.btnSeleccionaArchivo.Text = "...";
            this.btnSeleccionaArchivo.UseVisualStyleBackColor = true;
            this.btnSeleccionaArchivo.Click += new System.EventHandler(this.btnSeleccionaArchivo_Click);
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstado.ForeColor = System.Drawing.Color.Blue;
            this.lblEstado.Location = new System.Drawing.Point(122, 275);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(59, 13);
            this.lblEstado.TabIndex = 14;
            this.lblEstado.Text = "lblEstado";
            // 
            // frmPadronArba
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(702, 337);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.btnSeleccionaArchivo);
            this.Controls.Add(this.lblArchivo);
            this.Controls.Add(this.lblPwd);
            this.Controls.Add(this.lblUsr);
            this.Controls.Add(this.lblURL);
            this.Controls.Add(this.txtFile);
            this.Controls.Add(this.btnEnviar);
            this.Controls.Add(this.txtPwd);
            this.Controls.Add(this.txtUsr);
            this.Controls.Add(this.txtURL);
            this.Controls.Add(this.btnCerrar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmPadronArba";
            this.Opacity = 0.9;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Padrón Arba";
            this.Load += new System.EventHandler(this.frm4SCOT_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.TextBox txtURL;
        private System.Windows.Forms.TextBox txtUsr;
        private System.Windows.Forms.TextBox txtPwd;
        private System.Windows.Forms.Button btnEnviar;
        private System.Windows.Forms.TextBox txtFile;
        private System.Windows.Forms.Label lblURL;
        private System.Windows.Forms.Label lblUsr;
        private System.Windows.Forms.Label lblPwd;
        private System.Windows.Forms.Label lblArchivo;
        private System.Windows.Forms.OpenFileDialog ofdAbrirArchivo;
        private System.Windows.Forms.Button btnSeleccionaArchivo;
        private System.Windows.Forms.Label lblEstado;
    }
}

