namespace AmDemo.WinApp
{
	partial class Form1
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
			this.tbFirstname = new System.Windows.Forms.TextBox();
			this.tbLastname = new System.Windows.Forms.TextBox();
			this.tbAge = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.tbGender = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.btnGo = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// tbFirstname
			// 
			this.tbFirstname.Location = new System.Drawing.Point(26, 40);
			this.tbFirstname.Name = "tbFirstname";
			this.tbFirstname.Size = new System.Drawing.Size(205, 20);
			this.tbFirstname.TabIndex = 0;
			// 
			// tbLastname
			// 
			this.tbLastname.Location = new System.Drawing.Point(26, 82);
			this.tbLastname.Name = "tbLastname";
			this.tbLastname.Size = new System.Drawing.Size(205, 20);
			this.tbLastname.TabIndex = 1;
			// 
			// tbAge
			// 
			this.tbAge.Location = new System.Drawing.Point(26, 130);
			this.tbAge.Name = "tbAge";
			this.tbAge.Size = new System.Drawing.Size(93, 20);
			this.tbAge.TabIndex = 2;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(26, 21);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(55, 13);
			this.label1.TabIndex = 3;
			this.label1.Text = "First name";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(26, 67);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(56, 13);
			this.label2.TabIndex = 4;
			this.label2.Text = "Last name";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(26, 109);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(26, 13);
			this.label3.TabIndex = 5;
			this.label3.Text = "Age";
			// 
			// tbGender
			// 
			this.tbGender.Location = new System.Drawing.Point(143, 130);
			this.tbGender.Name = "tbGender";
			this.tbGender.Size = new System.Drawing.Size(88, 20);
			this.tbGender.TabIndex = 6;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(143, 109);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(42, 13);
			this.label4.TabIndex = 7;
			this.label4.Text = "Gender";
			// 
			// btnGo
			// 
			this.btnGo.BackColor = System.Drawing.Color.LimeGreen;
			this.btnGo.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnGo.Location = new System.Drawing.Point(280, 40);
			this.btnGo.Name = "btnGo";
			this.btnGo.Size = new System.Drawing.Size(167, 110);
			this.btnGo.TabIndex = 8;
			this.btnGo.Text = "Go!";
			this.btnGo.UseVisualStyleBackColor = false;
			this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(473, 186);
			this.Controls.Add(this.btnGo);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.tbGender);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.tbAge);
			this.Controls.Add(this.tbLastname);
			this.Controls.Add(this.tbFirstname);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "Form1";
			this.Text = "Form1";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox tbFirstname;
		private System.Windows.Forms.TextBox tbLastname;
		private System.Windows.Forms.TextBox tbAge;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox tbGender;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button btnGo;
	}
}

