
namespace IPv6ShortenderExtender
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
            this.InputTextBox = new System.Windows.Forms.TextBox();
            this.OutputTextBox = new System.Windows.Forms.TextBox();
            this.ConvertButton = new System.Windows.Forms.Button();
            this.InputLabel = new System.Windows.Forms.Label();
            this.OutputLabel = new System.Windows.Forms.Label();
            this.CopyOutputButton = new System.Windows.Forms.Button();
            this.DeleteInputButton = new System.Windows.Forms.Button();
            this.ErrorMessageLabel = new System.Windows.Forms.Label();
            this.SwitchModeLabelLeft = new System.Windows.Forms.Label();
            this.SwitchModeButton = new System.Windows.Forms.Button();
            this.SwitchModeLabelRight = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // InputTextBox
            // 
            this.InputTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InputTextBox.Location = new System.Drawing.Point(12, 73);
            this.InputTextBox.Name = "InputTextBox";
            this.InputTextBox.Size = new System.Drawing.Size(560, 31);
            this.InputTextBox.TabIndex = 0;
            // 
            // OutputTextBox
            // 
            this.OutputTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.OutputTextBox.Location = new System.Drawing.Point(12, 239);
            this.OutputTextBox.Name = "OutputTextBox";
            this.OutputTextBox.ReadOnly = true;
            this.OutputTextBox.Size = new System.Drawing.Size(560, 31);
            this.OutputTextBox.TabIndex = 1;
            // 
            // ConvertButton
            // 
            this.ConvertButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.ConvertButton.ForeColor = System.Drawing.Color.Black;
            this.ConvertButton.Location = new System.Drawing.Point(217, 141);
            this.ConvertButton.Name = "ConvertButton";
            this.ConvertButton.Size = new System.Drawing.Size(150, 60);
            this.ConvertButton.TabIndex = 2;
            this.ConvertButton.Text = "SKRATI";
            this.ConvertButton.UseVisualStyleBackColor = true;
            this.ConvertButton.Click += new System.EventHandler(this.ConvertButton_Click);
            // 
            // InputLabel
            // 
            this.InputLabel.AutoSize = true;
            this.InputLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InputLabel.Location = new System.Drawing.Point(12, 55);
            this.InputLabel.Name = "InputLabel";
            this.InputLabel.Size = new System.Drawing.Size(105, 15);
            this.InputLabel.TabIndex = 3;
            this.InputLabel.Text = "Upiši IPv6 adresu:";
            // 
            // OutputLabel
            // 
            this.OutputLabel.AutoSize = true;
            this.OutputLabel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.OutputLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.OutputLabel.Location = new System.Drawing.Point(12, 221);
            this.OutputLabel.Name = "OutputLabel";
            this.OutputLabel.Size = new System.Drawing.Size(129, 15);
            this.OutputLabel.TabIndex = 4;
            this.OutputLabel.Text = "Skraćena IPv6 adresa:";
            // 
            // CopyOutputButton
            // 
            this.CopyOutputButton.Location = new System.Drawing.Point(496, 277);
            this.CopyOutputButton.Name = "CopyOutputButton";
            this.CopyOutputButton.Size = new System.Drawing.Size(75, 23);
            this.CopyOutputButton.TabIndex = 5;
            this.CopyOutputButton.Text = "Kopiraj";
            this.CopyOutputButton.UseVisualStyleBackColor = true;
            this.CopyOutputButton.Click += new System.EventHandler(this.CopyOutputButton_Click);
            // 
            // DeleteInputButton
            // 
            this.DeleteInputButton.Location = new System.Drawing.Point(497, 110);
            this.DeleteInputButton.Name = "DeleteInputButton";
            this.DeleteInputButton.Size = new System.Drawing.Size(75, 23);
            this.DeleteInputButton.TabIndex = 6;
            this.DeleteInputButton.Text = "Izbriši";
            this.DeleteInputButton.UseVisualStyleBackColor = true;
            this.DeleteInputButton.Click += new System.EventHandler(this.DeleteInputButton_Click);
            // 
            // ErrorMessageLabel
            // 
            this.ErrorMessageLabel.AutoSize = true;
            this.ErrorMessageLabel.ForeColor = System.Drawing.Color.Red;
            this.ErrorMessageLabel.Location = new System.Drawing.Point(12, 110);
            this.ErrorMessageLabel.Name = "ErrorMessageLabel";
            this.ErrorMessageLabel.Size = new System.Drawing.Size(99, 13);
            this.ErrorMessageLabel.TabIndex = 7;
            this.ErrorMessageLabel.Text = "Error Message Text";
            this.ErrorMessageLabel.Visible = false;
            // 
            // SwitchModeLabelLeft
            // 
            this.SwitchModeLabelLeft.AutoSize = true;
            this.SwitchModeLabelLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.SwitchModeLabelLeft.Location = new System.Drawing.Point(230, 23);
            this.SwitchModeLabelLeft.Name = "SwitchModeLabelLeft";
            this.SwitchModeLabelLeft.Size = new System.Drawing.Size(42, 17);
            this.SwitchModeLabelLeft.TabIndex = 8;
            this.SwitchModeLabelLeft.Text = "Duga";
            // 
            // SwitchModeButton
            // 
            this.SwitchModeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.SwitchModeButton.Location = new System.Drawing.Point(276, 15);
            this.SwitchModeButton.Name = "SwitchModeButton";
            this.SwitchModeButton.Size = new System.Drawing.Size(32, 32);
            this.SwitchModeButton.TabIndex = 9;
            this.SwitchModeButton.Text = "→";
            this.SwitchModeButton.UseVisualStyleBackColor = true;
            this.SwitchModeButton.Click += new System.EventHandler(this.SwitchModeButton_Click);
            // 
            // SwitchModeLabelRight
            // 
            this.SwitchModeLabelRight.AutoSize = true;
            this.SwitchModeLabelRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.SwitchModeLabelRight.Location = new System.Drawing.Point(312, 23);
            this.SwitchModeLabelRight.Name = "SwitchModeLabelRight";
            this.SwitchModeLabelRight.Size = new System.Drawing.Size(49, 17);
            this.SwitchModeLabelRight.TabIndex = 10;
            this.SwitchModeLabelRight.Text = "Kratka";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 311);
            this.Controls.Add(this.SwitchModeLabelRight);
            this.Controls.Add(this.SwitchModeButton);
            this.Controls.Add(this.SwitchModeLabelLeft);
            this.Controls.Add(this.ErrorMessageLabel);
            this.Controls.Add(this.DeleteInputButton);
            this.Controls.Add(this.CopyOutputButton);
            this.Controls.Add(this.OutputLabel);
            this.Controls.Add(this.InputLabel);
            this.Controls.Add(this.ConvertButton);
            this.Controls.Add(this.OutputTextBox);
            this.Controls.Add(this.InputTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox InputTextBox;
        private System.Windows.Forms.TextBox OutputTextBox;
        private System.Windows.Forms.Button ConvertButton;
        private System.Windows.Forms.Label InputLabel;
        private System.Windows.Forms.Label OutputLabel;
        private System.Windows.Forms.Button CopyOutputButton;
        private System.Windows.Forms.Button DeleteInputButton;
        private System.Windows.Forms.Label ErrorMessageLabel;
        private System.Windows.Forms.Label SwitchModeLabelLeft;
        private System.Windows.Forms.Button SwitchModeButton;
        private System.Windows.Forms.Label SwitchModeLabelRight;
    }
}

