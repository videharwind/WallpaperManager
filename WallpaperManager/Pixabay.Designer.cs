namespace WallpaperManager
{
    partial class Pixabay
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
            textBox1 = new TextBox();
            flowLayoutPanel1 = new FlowLayoutPanel();
            buttonDownload = new Button();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(1002, 12);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(125, 27);
            textBox1.TabIndex = 1;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Location = new Point(12, 77);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(1115, 683);
            flowLayoutPanel1.TabIndex = 2;
            flowLayoutPanel1.Paint += flowLayoutPanel1_Paint;
            // 
            // buttonDownload
            // 
            buttonDownload.Location = new Point(32, 12);
            buttonDownload.Name = "buttonDownload";
            buttonDownload.Size = new Size(94, 59);
            buttonDownload.TabIndex = 3;
            buttonDownload.Text = "Download";
            buttonDownload.UseVisualStyleBackColor = true;
            buttonDownload.Click += buttonDownload_Click;
            // 
            // Pixabay
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1173, 772);
            Controls.Add(buttonDownload);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(textBox1);
            Name = "Pixabay";
            Text = "Form2";
            Load += Pixabay_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox textBox1;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button buttonDownload;
    }
}