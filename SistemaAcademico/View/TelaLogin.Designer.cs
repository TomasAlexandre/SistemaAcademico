
namespace SistemaAcademico.View
{
    partial class TelaLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TelaLogin));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btlogar = new System.Windows.Forms.Button();
            this.txtlogin = new System.Windows.Forms.TextBox();
            this.txtsenha2 = new System.Windows.Forms.TextBox();
            this.txtaviso = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(258, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(236, 50);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tela de Login";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(258, 209);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Login:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(258, 256);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Senha:";
            this.label3.Click += new System.EventHandler(this.label3_Click_1);
            // 
            // btlogar
            // 
            this.btlogar.BackColor = System.Drawing.Color.Teal;
            this.btlogar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btlogar.ForeColor = System.Drawing.Color.White;
            this.btlogar.Location = new System.Drawing.Point(306, 308);
            this.btlogar.Name = "btlogar";
            this.btlogar.Size = new System.Drawing.Size(162, 66);
            this.btlogar.TabIndex = 3;
            this.btlogar.Text = "Logar";
            this.btlogar.UseVisualStyleBackColor = false;
            this.btlogar.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtlogin
            // 
            this.txtlogin.BackColor = System.Drawing.Color.White;
            this.txtlogin.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtlogin.Location = new System.Drawing.Point(304, 208);
            this.txtlogin.Name = "txtlogin";
            this.txtlogin.Size = new System.Drawing.Size(162, 16);
            this.txtlogin.TabIndex = 4;
            // 
            // txtsenha2
            // 
            this.txtsenha2.BackColor = System.Drawing.Color.White;
            this.txtsenha2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtsenha2.Location = new System.Drawing.Point(304, 255);
            this.txtsenha2.Name = "txtsenha2";
            this.txtsenha2.PasswordChar = '*';
            this.txtsenha2.Size = new System.Drawing.Size(162, 16);
            this.txtsenha2.TabIndex = 5;
            // 
            // txtaviso
            // 
            this.txtaviso.AutoSize = true;
            this.txtaviso.ForeColor = System.Drawing.Color.Red;
            this.txtaviso.Location = new System.Drawing.Point(306, 279);
            this.txtaviso.Name = "txtaviso";
            this.txtaviso.Size = new System.Drawing.Size(0, 15);
            this.txtaviso.TabIndex = 7;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.BackColor = System.Drawing.Color.Transparent;
            this.checkBox1.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.checkBox1.Location = new System.Drawing.Point(306, 230);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(103, 19);
            this.checkBox1.TabIndex = 8;
            this.checkBox1.Text = "Lembrar Login";
            this.checkBox1.UseVisualStyleBackColor = false;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // TelaLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtsenha2);
            this.Controls.Add(this.txtlogin);
            this.Controls.Add(this.btlogar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtaviso);
            this.Name = "TelaLogin";
            this.Text = "TelaLogin";
            this.Load += new System.EventHandler(this.TelaLogin_Load_1);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btlogar;
        private System.Windows.Forms.TextBox txtlogin;
        private System.Windows.Forms.TextBox txtsenha2;
        private System.Windows.Forms.TextBox txtsenha;
        private System.Windows.Forms.Label txtaviso;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}