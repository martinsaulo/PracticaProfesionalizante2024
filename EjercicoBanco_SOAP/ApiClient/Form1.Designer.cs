namespace ApiClient
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnTransferir = new Button();
            txtMonto = new TextBox();
            listBoxCuentas = new ListBox();
            label1 = new Label();
            label2 = new Label();
            listBoxClientes = new ListBox();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            btnAgregarCliente = new Button();
            txtNombre = new TextBox();
            label6 = new Label();
            txtDNI = new TextBox();
            label7 = new Label();
            comboBox3 = new ComboBox();
            label8 = new Label();
            btnAgregarCuenta = new Button();
            label9 = new Label();
            txtDescrip = new TextBox();
            listBoxDeudores = new ListBox();
            label10 = new Label();
            btnInfo = new Button();
            txtIdOrigen = new TextBox();
            txtIdDestino = new TextBox();
            SuspendLayout();
            // 
            // btnTransferir
            // 
            btnTransferir.Location = new Point(713, 103);
            btnTransferir.Name = "btnTransferir";
            btnTransferir.Size = new Size(75, 23);
            btnTransferir.TabIndex = 0;
            btnTransferir.Text = "Transferir";
            btnTransferir.UseVisualStyleBackColor = true;
            btnTransferir.Click += btnTransferir_Click;
            // 
            // txtMonto
            // 
            txtMonto.Location = new Point(513, 27);
            txtMonto.Name = "txtMonto";
            txtMonto.Size = new Size(148, 23);
            txtMonto.TabIndex = 1;
            // 
            // listBoxCuentas
            // 
            listBoxCuentas.FormattingEnabled = true;
            listBoxCuentas.ItemHeight = 15;
            listBoxCuentas.Location = new Point(12, 30);
            listBoxCuentas.Name = "listBoxCuentas";
            listBoxCuentas.Size = new Size(176, 169);
            listBoxCuentas.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(50, 15);
            label1.TabIndex = 3;
            label1.Text = "Cuentas";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 221);
            label2.Name = "label2";
            label2.Size = new Size(49, 15);
            label2.TabIndex = 5;
            label2.Text = "Clientes";
            // 
            // listBoxClientes
            // 
            listBoxClientes.FormattingEnabled = true;
            listBoxClientes.ItemHeight = 15;
            listBoxClientes.Location = new Point(12, 239);
            listBoxClientes.Name = "listBoxClientes";
            listBoxClientes.Size = new Size(176, 199);
            listBoxClientes.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(386, 9);
            label3.Name = "label3";
            label3.Size = new Size(74, 15);
            label3.TabIndex = 9;
            label3.Text = "Transferir de:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(667, 9);
            label4.Name = "label4";
            label4.Size = new Size(67, 15);
            label4.TabIndex = 10;
            label4.Text = "Transferir a:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(513, 9);
            label5.Name = "label5";
            label5.Size = new Size(46, 15);
            label5.TabIndex = 11;
            label5.Text = "Monto:";
            // 
            // btnAgregarCliente
            // 
            btnAgregarCliente.Location = new Point(267, 330);
            btnAgregarCliente.Name = "btnAgregarCliente";
            btnAgregarCliente.Size = new Size(75, 23);
            btnAgregarCliente.TabIndex = 12;
            btnAgregarCliente.Text = "Agregar";
            btnAgregarCliente.UseVisualStyleBackColor = true;
            btnAgregarCliente.Click += btnAgregarCliente_Click;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(194, 257);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(148, 23);
            txtNombre.TabIndex = 13;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(194, 239);
            label6.Name = "label6";
            label6.Size = new Size(54, 15);
            label6.TabIndex = 14;
            label6.Text = "Nombre:";
            // 
            // txtDNI
            // 
            txtDNI.Location = new Point(194, 301);
            txtDNI.Name = "txtDNI";
            txtDNI.Size = new Size(148, 23);
            txtDNI.TabIndex = 15;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(194, 283);
            label7.Name = "label7";
            label7.Size = new Size(30, 15);
            label7.TabIndex = 16;
            label7.Text = "DNI:";
            // 
            // comboBox3
            // 
            comboBox3.FormattingEnabled = true;
            comboBox3.Location = new Point(194, 48);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(121, 23);
            comboBox3.TabIndex = 17;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(194, 30);
            label8.Name = "label8";
            label8.Size = new Size(47, 15);
            label8.TabIndex = 18;
            label8.Text = "Cliente:";
            // 
            // btnAgregarCuenta
            // 
            btnAgregarCuenta.Location = new Point(240, 77);
            btnAgregarCuenta.Name = "btnAgregarCuenta";
            btnAgregarCuenta.Size = new Size(75, 23);
            btnAgregarCuenta.TabIndex = 19;
            btnAgregarCuenta.Text = "Agregar";
            btnAgregarCuenta.UseVisualStyleBackColor = true;
            btnAgregarCuenta.Click += btnAgregarCuenta_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(386, 56);
            label9.Name = "label9";
            label9.Size = new Size(72, 15);
            label9.TabIndex = 20;
            label9.Text = "Descripción:";
            // 
            // txtDescrip
            // 
            txtDescrip.Location = new Point(386, 74);
            txtDescrip.Name = "txtDescrip";
            txtDescrip.Size = new Size(402, 23);
            txtDescrip.TabIndex = 21;
            // 
            // listBoxDeudores
            // 
            listBoxDeudores.FormattingEnabled = true;
            listBoxDeudores.ItemHeight = 15;
            listBoxDeudores.Location = new Point(383, 239);
            listBoxDeudores.Name = "listBoxDeudores";
            listBoxDeudores.Size = new Size(176, 199);
            listBoxDeudores.TabIndex = 22;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(383, 221);
            label10.Name = "label10";
            label10.Size = new Size(57, 15);
            label10.TabIndex = 23;
            label10.Text = "Deudores";
            // 
            // btnInfo
            // 
            btnInfo.Location = new Point(194, 176);
            btnInfo.Name = "btnInfo";
            btnInfo.Size = new Size(75, 23);
            btnInfo.TabIndex = 24;
            btnInfo.Text = "Info.";
            btnInfo.UseVisualStyleBackColor = true;
            btnInfo.Click += btnInfo_Click;
            // 
            // txtIdOrigen
            // 
            txtIdOrigen.Location = new Point(386, 27);
            txtIdOrigen.Name = "txtIdOrigen";
            txtIdOrigen.Size = new Size(121, 23);
            txtIdOrigen.TabIndex = 25;
            // 
            // txtIdDestino
            // 
            txtIdDestino.Location = new Point(667, 27);
            txtIdDestino.Name = "txtIdDestino";
            txtIdDestino.Size = new Size(121, 23);
            txtIdDestino.TabIndex = 26;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(txtIdDestino);
            Controls.Add(txtIdOrigen);
            Controls.Add(btnInfo);
            Controls.Add(label10);
            Controls.Add(listBoxDeudores);
            Controls.Add(txtDescrip);
            Controls.Add(label9);
            Controls.Add(btnAgregarCuenta);
            Controls.Add(label8);
            Controls.Add(comboBox3);
            Controls.Add(label7);
            Controls.Add(txtDNI);
            Controls.Add(label6);
            Controls.Add(txtNombre);
            Controls.Add(btnAgregarCliente);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(listBoxClientes);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(listBoxCuentas);
            Controls.Add(txtMonto);
            Controls.Add(btnTransferir);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnTransferir;
        private TextBox txtMonto;
        private ListBox listBoxCuentas;
        private Label label1;
        private Label label2;
        private ListBox listBoxClientes;
        private Label label3;
        private Label label4;
        private Label label5;
        private Button btnAgregarCliente;
        private TextBox txtNombre;
        private Label label6;
        private TextBox txtDNI;
        private Label label7;
        private ComboBox comboBox3;
        private Label label8;
        private Button btnAgregarCuenta;
        private Label label9;
        private TextBox txtDescrip;
        private ListBox listBoxDeudores;
        private Label label10;
        private Button btnInfo;
        private TextBox txtIdOrigen;
        private TextBox txtIdDestino;
    }
}
