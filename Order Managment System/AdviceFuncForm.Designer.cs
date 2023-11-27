namespace Order_Managment_System
{
    partial class AdviceFuncForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdviceFuncForm));
            Panel = new Panel();
            pictureBox3 = new PictureBox();
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            DeleteInfo = new Label();
            UpdateInfo = new Label();
            InsertInfo = new Label();
            DeleteLabel = new Label();
            UpdateLabel = new Label();
            InsertLabel = new Label();
            Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // Panel
            // 
            Panel.BackColor = Color.FromArgb(173, 91, 91);
            Panel.Controls.Add(pictureBox3);
            Panel.Controls.Add(pictureBox2);
            Panel.Controls.Add(pictureBox1);
            Panel.Controls.Add(DeleteInfo);
            Panel.Controls.Add(UpdateInfo);
            Panel.Controls.Add(InsertInfo);
            Panel.Controls.Add(DeleteLabel);
            Panel.Controls.Add(UpdateLabel);
            Panel.Controls.Add(InsertLabel);
            Panel.Location = new Point(14, 13);
            Panel.Margin = new Padding(4, 3, 4, 3);
            Panel.Name = "Panel";
            Panel.Size = new Size(905, 459);
            Panel.TabIndex = 0;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = Properties.Resources.delete1;
            pictureBox3.Location = new Point(723, 338);
            pictureBox3.Margin = new Padding(4, 3, 4, 3);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(115, 107);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 8;
            pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.update;
            pictureBox2.Location = new Point(397, 338);
            pictureBox2.Margin = new Padding(4, 3, 4, 3);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(115, 107);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 7;
            pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.insert;
            pictureBox1.Location = new Point(35, 338);
            pictureBox1.Margin = new Padding(4, 3, 4, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(117, 107);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            // 
            // DeleteInfo
            // 
            DeleteInfo.Font = new Font("Microsoft Sans Serif", 12.25F, FontStyle.Regular, GraphicsUnit.Point);
            DeleteInfo.Location = new Point(648, 68);
            DeleteInfo.Margin = new Padding(4, 0, 4, 0);
            DeleteInfo.Name = "DeleteInfo";
            DeleteInfo.Size = new Size(254, 267);
            DeleteInfo.TabIndex = 5;
            DeleteInfo.Text = resources.GetString("DeleteInfo.Text");
            // 
            // UpdateInfo
            // 
            UpdateInfo.Font = new Font("Microsoft Sans Serif", 12.25F, FontStyle.Regular, GraphicsUnit.Point);
            UpdateInfo.Location = new Point(345, 68);
            UpdateInfo.Margin = new Padding(4, 0, 4, 0);
            UpdateInfo.Name = "UpdateInfo";
            UpdateInfo.Size = new Size(254, 267);
            UpdateInfo.TabIndex = 4;
            UpdateInfo.Text = resources.GetString("UpdateInfo.Text");
            // 
            // InsertInfo
            // 
            InsertInfo.Font = new Font("Microsoft Sans Serif", 12.25F, FontStyle.Regular, GraphicsUnit.Point);
            InsertInfo.Location = new Point(4, 68);
            InsertInfo.Margin = new Padding(4, 0, 4, 0);
            InsertInfo.Name = "InsertInfo";
            InsertInfo.Size = new Size(254, 267);
            InsertInfo.TabIndex = 3;
            InsertInfo.Text = resources.GetString("InsertInfo.Text");
            // 
            // DeleteLabel
            // 
            DeleteLabel.AutoSize = true;
            DeleteLabel.Font = new Font("Microsoft Sans Serif", 12.25F, FontStyle.Bold, GraphicsUnit.Point);
            DeleteLabel.Location = new Point(692, 38);
            DeleteLabel.Margin = new Padding(4, 0, 4, 0);
            DeleteLabel.Name = "DeleteLabel";
            DeleteLabel.Size = new Size(151, 20);
            DeleteLabel.TabIndex = 2;
            DeleteLabel.Text = "DELETE(Ctrl+D)";
            // 
            // UpdateLabel
            // 
            UpdateLabel.AutoSize = true;
            UpdateLabel.Font = new Font("Microsoft Sans Serif", 12.25F, FontStyle.Bold, GraphicsUnit.Point);
            UpdateLabel.Location = new Point(380, 38);
            UpdateLabel.Margin = new Padding(4, 0, 4, 0);
            UpdateLabel.Name = "UpdateLabel";
            UpdateLabel.Size = new Size(152, 20);
            UpdateLabel.TabIndex = 1;
            UpdateLabel.Text = "UPDATE(Ctrl+U)";
            // 
            // InsertLabel
            // 
            InsertLabel.AutoSize = true;
            InsertLabel.Font = new Font("Microsoft Sans Serif", 12.25F, FontStyle.Bold, GraphicsUnit.Point);
            InsertLabel.Location = new Point(30, 38);
            InsertLabel.Margin = new Padding(4, 0, 4, 0);
            InsertLabel.Name = "InsertLabel";
            InsertLabel.Size = new Size(136, 20);
            InsertLabel.TabIndex = 0;
            InsertLabel.Text = "INSERT(Ctrl+I)";
            // 
            // AdviceFuncForm
            // 
            AutoScaleDimensions = new SizeF(7F, 14F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(76, 76, 76);
            ClientSize = new Size(933, 485);
            Controls.Add(Panel);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 3, 4, 3);
            Name = "AdviceFuncForm";
            Text = "AdviceFuncForm";
            Panel.ResumeLayout(false);
            Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel Panel;
        private Label InsertLabel;
        private Label DeleteInfo;
        private Label UpdateInfo;
        private Label InsertInfo;
        private Label DeleteLabel;
        private Label UpdateLabel;
        private PictureBox pictureBox1;
        private PictureBox pictureBox3;
        private PictureBox pictureBox2;
    }
}