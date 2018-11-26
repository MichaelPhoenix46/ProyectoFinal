namespace ProyectoFinal.UI.Consultas
{
    partial class ConsultaMiembros
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
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ReporteButton = new System.Windows.Forms.Button();
            this.Consultabutton = new System.Windows.Forms.Button();
            this.TipocomboBox = new System.Windows.Forms.ComboBox();
            this.CriteriotextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Tipo = new System.Windows.Forms.Label();
            this.ConsultadataGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.ConsultadataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.CustomFormat = "dd/MM/yyyy";
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker2.Location = new System.Drawing.Point(228, 76);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(115, 22);
            this.dateTimePicker2.TabIndex = 71;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(75, 76);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(115, 22);
            this.dateTimePicker1.TabIndex = 70;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(266, 56);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 17);
            this.label3.TabIndex = 69;
            this.label3.Text = "Hasta";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(118, 56);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 17);
            this.label1.TabIndex = 68;
            this.label1.Text = "Desde";
            // 
            // ReporteButton
            // 
            this.ReporteButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ReporteButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ReporteButton.Location = new System.Drawing.Point(21, 397);
            this.ReporteButton.Margin = new System.Windows.Forms.Padding(4);
            this.ReporteButton.Name = "ReporteButton";
            this.ReporteButton.Size = new System.Drawing.Size(169, 85);
            this.ReporteButton.TabIndex = 64;
            this.ReporteButton.Text = "Imprimir";
            this.ReporteButton.UseVisualStyleBackColor = true;
            // 
            // Consultabutton
            // 
            this.Consultabutton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Consultabutton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Consultabutton.Location = new System.Drawing.Point(618, 12);
            this.Consultabutton.Margin = new System.Windows.Forms.Padding(4);
            this.Consultabutton.Name = "Consultabutton";
            this.Consultabutton.Size = new System.Drawing.Size(169, 98);
            this.Consultabutton.TabIndex = 63;
            this.Consultabutton.Text = "Consultar";
            this.Consultabutton.UseVisualStyleBackColor = true;
            // 
            // TipocomboBox
            // 
            this.TipocomboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TipocomboBox.FormattingEnabled = true;
            this.TipocomboBox.Items.AddRange(new object[] {
            "id",
            "Nombre",
            "Direccion",
            "Cedula",
            "Telefono",
            "Listar Todo"});
            this.TipocomboBox.Location = new System.Drawing.Point(42, 28);
            this.TipocomboBox.Margin = new System.Windows.Forms.Padding(4);
            this.TipocomboBox.Name = "TipocomboBox";
            this.TipocomboBox.Size = new System.Drawing.Size(167, 24);
            this.TipocomboBox.TabIndex = 61;
            // 
            // CriteriotextBox
            // 
            this.CriteriotextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CriteriotextBox.Location = new System.Drawing.Point(228, 30);
            this.CriteriotextBox.Margin = new System.Windows.Forms.Padding(4);
            this.CriteriotextBox.Name = "CriteriotextBox";
            this.CriteriotextBox.Size = new System.Drawing.Size(382, 22);
            this.CriteriotextBox.TabIndex = 62;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(400, 10);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 17);
            this.label2.TabIndex = 67;
            this.label2.Text = "Criterio";
            // 
            // Tipo
            // 
            this.Tipo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Tipo.AutoSize = true;
            this.Tipo.Location = new System.Drawing.Point(99, 10);
            this.Tipo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Tipo.Name = "Tipo";
            this.Tipo.Size = new System.Drawing.Size(39, 17);
            this.Tipo.TabIndex = 66;
            this.Tipo.Text = "Filtro";
            // 
            // ConsultadataGridView
            // 
            this.ConsultadataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ConsultadataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ConsultadataGridView.Location = new System.Drawing.Point(13, 118);
            this.ConsultadataGridView.Margin = new System.Windows.Forms.Padding(4);
            this.ConsultadataGridView.Name = "ConsultadataGridView";
            this.ConsultadataGridView.Size = new System.Drawing.Size(774, 271);
            this.ConsultadataGridView.TabIndex = 65;
            // 
            // ConsultaMiembros
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 492);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ReporteButton);
            this.Controls.Add(this.Consultabutton);
            this.Controls.Add(this.TipocomboBox);
            this.Controls.Add(this.CriteriotextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Tipo);
            this.Controls.Add(this.ConsultadataGridView);
            this.Name = "ConsultaMiembros";
            this.Text = "ConsultaMiembros";
            ((System.ComponentModel.ISupportInitialize)(this.ConsultadataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ReporteButton;
        private System.Windows.Forms.Button Consultabutton;
        private System.Windows.Forms.ComboBox TipocomboBox;
        private System.Windows.Forms.TextBox CriteriotextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label Tipo;
        private System.Windows.Forms.DataGridView ConsultadataGridView;
    }
}