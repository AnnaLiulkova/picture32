namespace picture32
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
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(148, 42);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 0;
            button1.Text = "Завантажити";
            button1.UseVisualStyleBackColor = true;
            button1.Click += BtnLoadImage_Click;
            // 
            // button2
            // 
            button2.Location = new Point(355, 42);
            button2.Name = "button2";
            button2.Size = new Size(97, 23);
            button2.TabIndex = 1;
            button2.Text = "Перевернути";
            button2.UseVisualStyleBackColor = true;
            button2.Click += BtnMirrorImage_Click;
            // 
            // button3
            // 
            button3.Location = new Point(585, 42);
            button3.Name = "button3";
            button3.Size = new Size(75, 23);
            button3.TabIndex = 2;
            button3.Text = "Зберегти";
            button3.UseVisualStyleBackColor = true;
            button3.Click += BtnSaveImage_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(58, 102);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(256, 282);
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.Location = new Point(486, 102);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(269, 282);
            pictureBox2.TabIndex = 4;
            pictureBox2.TabStop = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(805, 450);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private Button button2;
        private Button button3;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
    }
}
