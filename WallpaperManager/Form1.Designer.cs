namespace WallpaperManager
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
            flowLayoutPanel1 = new FlowLayoutPanel();
            buttonSelect = new Button();
            ButtonRemove = new Button();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = Color.LimeGreen;
            button1.Location = new Point(1076, 12);
            button1.Name = "button1";
            button1.Size = new Size(94, 73);
            button1.TabIndex = 0;
            button1.Text = "ADD";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.Location = new Point(12, 127);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(1158, 610);
            flowLayoutPanel1.TabIndex = 1;
            flowLayoutPanel1.Paint += flowLayoutPanel1_Paint;
            // 
            // buttonSelect
            // 
            buttonSelect.Location = new Point(27, 12);
            buttonSelect.Name = "buttonSelect";
            buttonSelect.Size = new Size(94, 68);
            buttonSelect.TabIndex = 2;
            buttonSelect.Text = "Set Wallpaper";
            buttonSelect.UseVisualStyleBackColor = true;
            buttonSelect.Click += button2_Click;
            // 
            // ButtonRemove
            // 
            ButtonRemove.Location = new Point(147, 14);
            ButtonRemove.Name = "ButtonRemove";
            ButtonRemove.Size = new Size(94, 68);
            ButtonRemove.TabIndex = 3;
            ButtonRemove.Text = "Remove";
            ButtonRemove.UseVisualStyleBackColor = true;
            ButtonRemove.Click += ButtonRemove_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1182, 768);
            Controls.Add(ButtonRemove);
            Controls.Add(buttonSelect);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button buttonSelect;
        private Button ButtonRemove;
    }
}
