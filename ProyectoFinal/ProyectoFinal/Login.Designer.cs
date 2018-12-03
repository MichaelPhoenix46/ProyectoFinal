namespace ProyectoFinal
{
    partial class Login
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
            this.components = new System.ComponentModel.Container();
            this.UsertextBox = new System.Windows.Forms.TextBox();
            this.passtextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.logInbutton = new System.Windows.Forms.Button();
            this.LogInerrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.LogInerrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // UsertextBox
            // 
            this.UsertextBox.Location = new System.Drawing.Point(130, 120);
            this.UsertextBox.Name = "UsertextBox";
            this.UsertextBox.Size = new System.Drawing.Size(100, 22);
            this.UsertextBox.TabIndex = 0;
            // 
            // passtextBox
            // 
            this.passtextBox.Location = new System.Drawing.Point(130, 200);
            this.passtextBox.Name = "passtextBox";
            this.passtextBox.Size = new System.Drawing.Size(100, 22);
            this.passtextBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(62, 123);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Usuario";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 203);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Contraseña";
            // 
            // logInbutton
            // 
            this.logInbutton.Location = new System.Drawing.Point(138, 243);
            this.logInbutton.Name = "logInbutton";
            this.logInbutton.Size = new System.Drawing.Size(75, 48);
            this.logInbutton.TabIndex = 4;
            this.logInbutton.Text = "Login";
            this.logInbutton.UseVisualStyleBackColor = true;
            this.logInbutton.Click += new System.EventHandler(this.logInbutton_Click);
            // 
            // LogInerrorProvider
            // 
            this.LogInerrorProvider.ContainerControl = this;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 303);
            this.Controls.Add(this.logInbutton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.passtextBox);
            this.Controls.Add(this.UsertextBox);
            this.Name = "Login";
            this.Text = "Login";
            ((System.ComponentModel.ISupportInitialize)(this.LogInerrorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox UsertextBox;
        private System.Windows.Forms.TextBox passtextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button logInbutton;
        private System.Windows.Forms.ErrorProvider LogInerrorProvider;
    }
}