namespace Cliente
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.Conectar = new System.Windows.Forms.Button();
            this.Desconectar = new System.Windows.Forms.Button();
            this.Nombre_txtbox = new System.Windows.Forms.TextBox();
            this.Enviar_Nombre = new System.Windows.Forms.Button();
            this.Ingresar_enviar = new System.Windows.Forms.Button();
            this.Ingreso_txtbox = new System.Windows.Forms.TextBox();
            this.Saldo = new System.Windows.Forms.Button();
            this.Saldo_txtbox = new System.Windows.Forms.TextBox();
            this.Notilabel = new System.Windows.Forms.Label();
            this.Comision = new System.Windows.Forms.Button();
            this.Cantidad_txtbox = new System.Windows.Forms.TextBox();
            this.Cargo = new System.Windows.Forms.Button();
            this.Quien_txtbox = new System.Windows.Forms.TextBox();
            this.Comision_txtbox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Conectar
            // 
            this.Conectar.Location = new System.Drawing.Point(12, 12);
            this.Conectar.Name = "Conectar";
            this.Conectar.Size = new System.Drawing.Size(104, 23);
            this.Conectar.TabIndex = 0;
            this.Conectar.Text = "Conectar";
            this.Conectar.UseVisualStyleBackColor = true;
            this.Conectar.Click += new System.EventHandler(this.Conectar_Click);
            // 
            // Desconectar
            // 
            this.Desconectar.Location = new System.Drawing.Point(146, 12);
            this.Desconectar.Name = "Desconectar";
            this.Desconectar.Size = new System.Drawing.Size(104, 23);
            this.Desconectar.TabIndex = 1;
            this.Desconectar.Text = "Desconectar";
            this.Desconectar.UseVisualStyleBackColor = true;
            this.Desconectar.Click += new System.EventHandler(this.Desconectar_Click);
            // 
            // Nombre_txtbox
            // 
            this.Nombre_txtbox.Location = new System.Drawing.Point(12, 52);
            this.Nombre_txtbox.Name = "Nombre_txtbox";
            this.Nombre_txtbox.Size = new System.Drawing.Size(100, 22);
            this.Nombre_txtbox.TabIndex = 2;
            // 
            // Enviar_Nombre
            // 
            this.Enviar_Nombre.Location = new System.Drawing.Point(146, 52);
            this.Enviar_Nombre.Name = "Enviar_Nombre";
            this.Enviar_Nombre.Size = new System.Drawing.Size(116, 23);
            this.Enviar_Nombre.TabIndex = 3;
            this.Enviar_Nombre.Text = "Enviar_nombre";
            this.Enviar_Nombre.UseVisualStyleBackColor = true;
            this.Enviar_Nombre.Click += new System.EventHandler(this.Enviar_Nombre_Click);
            // 
            // Ingresar_enviar
            // 
            this.Ingresar_enviar.Location = new System.Drawing.Point(146, 92);
            this.Ingresar_enviar.Name = "Ingresar_enviar";
            this.Ingresar_enviar.Size = new System.Drawing.Size(116, 23);
            this.Ingresar_enviar.TabIndex = 5;
            this.Ingresar_enviar.Text = "Ingresar cantidad";
            this.Ingresar_enviar.UseVisualStyleBackColor = true;
            // 
            // Ingreso_txtbox
            // 
            this.Ingreso_txtbox.Location = new System.Drawing.Point(12, 92);
            this.Ingreso_txtbox.Name = "Ingreso_txtbox";
            this.Ingreso_txtbox.Size = new System.Drawing.Size(100, 22);
            this.Ingreso_txtbox.TabIndex = 4;
            // 
            // Saldo
            // 
            this.Saldo.Location = new System.Drawing.Point(16, 132);
            this.Saldo.Name = "Saldo";
            this.Saldo.Size = new System.Drawing.Size(116, 23);
            this.Saldo.TabIndex = 7;
            this.Saldo.Text = "Consultar saldo";
            this.Saldo.UseVisualStyleBackColor = true;
            this.Saldo.Click += new System.EventHandler(this.Saldo_Click);
            // 
            // Saldo_txtbox
            // 
            this.Saldo_txtbox.Location = new System.Drawing.Point(162, 133);
            this.Saldo_txtbox.Name = "Saldo_txtbox";
            this.Saldo_txtbox.Size = new System.Drawing.Size(100, 22);
            this.Saldo_txtbox.TabIndex = 6;
            // 
            // Notilabel
            // 
            this.Notilabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Notilabel.Location = new System.Drawing.Point(16, 181);
            this.Notilabel.Name = "Notilabel";
            this.Notilabel.Size = new System.Drawing.Size(347, 95);
            this.Notilabel.TabIndex = 8;
            this.Notilabel.Text = "label1";
            // 
            // Comision
            // 
            this.Comision.Location = new System.Drawing.Point(635, 52);
            this.Comision.Name = "Comision";
            this.Comision.Size = new System.Drawing.Size(116, 23);
            this.Comision.TabIndex = 12;
            this.Comision.Text = "Cargar comision";
            this.Comision.UseVisualStyleBackColor = true;
            this.Comision.Click += new System.EventHandler(this.Comision_Click);
            // 
            // Cantidad_txtbox
            // 
            this.Cantidad_txtbox.Location = new System.Drawing.Point(373, 13);
            this.Cantidad_txtbox.Name = "Cantidad_txtbox";
            this.Cantidad_txtbox.Size = new System.Drawing.Size(100, 22);
            this.Cantidad_txtbox.TabIndex = 11;
            // 
            // Cargo
            // 
            this.Cargo.Location = new System.Drawing.Point(635, 12);
            this.Cargo.Name = "Cargo";
            this.Cargo.Size = new System.Drawing.Size(116, 23);
            this.Cargo.TabIndex = 10;
            this.Cargo.Text = "Hacer cargo";
            this.Cargo.UseVisualStyleBackColor = true;
            this.Cargo.Click += new System.EventHandler(this.Cargo_Click);
            // 
            // Quien_txtbox
            // 
            this.Quien_txtbox.Location = new System.Drawing.Point(503, 12);
            this.Quien_txtbox.Name = "Quien_txtbox";
            this.Quien_txtbox.Size = new System.Drawing.Size(100, 22);
            this.Quien_txtbox.TabIndex = 9;
            // 
            // Comision_txtbox
            // 
            this.Comision_txtbox.Location = new System.Drawing.Point(503, 53);
            this.Comision_txtbox.Name = "Comision_txtbox";
            this.Comision_txtbox.Size = new System.Drawing.Size(100, 22);
            this.Comision_txtbox.TabIndex = 13;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 289);
            this.Controls.Add(this.Comision_txtbox);
            this.Controls.Add(this.Comision);
            this.Controls.Add(this.Cantidad_txtbox);
            this.Controls.Add(this.Cargo);
            this.Controls.Add(this.Quien_txtbox);
            this.Controls.Add(this.Notilabel);
            this.Controls.Add(this.Saldo);
            this.Controls.Add(this.Saldo_txtbox);
            this.Controls.Add(this.Ingresar_enviar);
            this.Controls.Add(this.Ingreso_txtbox);
            this.Controls.Add(this.Enviar_Nombre);
            this.Controls.Add(this.Nombre_txtbox);
            this.Controls.Add(this.Desconectar);
            this.Controls.Add(this.Conectar);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Conectar;
        private System.Windows.Forms.Button Desconectar;
        private System.Windows.Forms.TextBox Nombre_txtbox;
        private System.Windows.Forms.Button Enviar_Nombre;
        private System.Windows.Forms.Button Ingresar_enviar;
        private System.Windows.Forms.TextBox Ingreso_txtbox;
        private System.Windows.Forms.Button Saldo;
        private System.Windows.Forms.TextBox Saldo_txtbox;
        private System.Windows.Forms.Label Notilabel;
        private System.Windows.Forms.Button Comision;
        private System.Windows.Forms.TextBox Cantidad_txtbox;
        private System.Windows.Forms.Button Cargo;
        private System.Windows.Forms.TextBox Quien_txtbox;
        private System.Windows.Forms.TextBox Comision_txtbox;
    }
}

