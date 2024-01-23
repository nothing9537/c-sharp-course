namespace NumericNumberSuggester
{
    partial class MainForm
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
            MinValueLabel = new Label();
            MaxValueLabel = new Label();
            MinValueTextBox = new TextBox();
            MaxValueTextBox = new TextBox();
            IntegralOnlyCheckbox = new CheckBox();
            SuggestedTypeLabel = new Label();
            SuggestedTypeValue = new Label();
            MustBePreciseCheckbox = new CheckBox();
            SuspendLayout();
            // 
            // MinValueLabel
            // 
            MinValueLabel.AutoSize = true;
            MinValueLabel.Font = new Font("Arial", 16F);
            MinValueLabel.Location = new Point(120, 7);
            MinValueLabel.Margin = new Padding(5, 0, 5, 0);
            MinValueLabel.Name = "MinValueLabel";
            MinValueLabel.Size = new Size(109, 25);
            MinValueLabel.TabIndex = 0;
            MinValueLabel.Text = "Min value:";
            // 
            // MaxValueLabel
            // 
            MaxValueLabel.AutoSize = true;
            MaxValueLabel.Font = new Font("Arial", 16F);
            MaxValueLabel.Location = new Point(114, 49);
            MaxValueLabel.Margin = new Padding(5, 0, 5, 0);
            MaxValueLabel.Name = "MaxValueLabel";
            MaxValueLabel.Size = new Size(115, 25);
            MaxValueLabel.TabIndex = 1;
            MaxValueLabel.Text = "Max value:";
            // 
            // MinValueTextBox
            // 
            MinValueTextBox.Location = new Point(237, 7);
            MinValueTextBox.Name = "MinValueTextBox";
            MinValueTextBox.Size = new Size(670, 36);
            MinValueTextBox.TabIndex = 2;
            MinValueTextBox.TextChanged += TextBox_TextChanged;
            MinValueTextBox.KeyPress += TextBox_KeyPress;
            // 
            // MaxValueTextBox
            // 
            MaxValueTextBox.Location = new Point(237, 49);
            MaxValueTextBox.Name = "MaxValueTextBox";
            MaxValueTextBox.Size = new Size(670, 36);
            MaxValueTextBox.TabIndex = 3;
            MaxValueTextBox.TextChanged += TextBox_TextChanged;
            MaxValueTextBox.KeyPress += TextBox_KeyPress;
            // 
            // IntegralOnlyCheckbox
            // 
            IntegralOnlyCheckbox.AutoSize = true;
            IntegralOnlyCheckbox.CheckAlign = ContentAlignment.MiddleRight;
            IntegralOnlyCheckbox.Checked = true;
            IntegralOnlyCheckbox.CheckState = CheckState.Checked;
            IntegralOnlyCheckbox.Location = new Point(66, 78);
            IntegralOnlyCheckbox.Name = "IntegralOnlyCheckbox";
            IntegralOnlyCheckbox.RightToLeft = RightToLeft.No;
            IntegralOnlyCheckbox.Size = new Size(163, 34);
            IntegralOnlyCheckbox.TabIndex = 4;
            IntegralOnlyCheckbox.Text = "Intergal only?";
            IntegralOnlyCheckbox.TextAlign = ContentAlignment.MiddleRight;
            IntegralOnlyCheckbox.UseVisualStyleBackColor = true;
            IntegralOnlyCheckbox.CheckedChanged += IntegralOnlyCheckbox_CheckedChanged;
            // 
            // SuggestedTypeLabel
            // 
            SuggestedTypeLabel.AutoSize = true;
            SuggestedTypeLabel.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            SuggestedTypeLabel.Location = new Point(40, 155);
            SuggestedTypeLabel.Name = "SuggestedTypeLabel";
            SuggestedTypeLabel.Size = new Size(182, 30);
            SuggestedTypeLabel.TabIndex = 5;
            SuggestedTypeLabel.Text = "Suggested type:";
            // 
            // SuggestedTypeValue
            // 
            SuggestedTypeValue.AutoSize = true;
            SuggestedTypeValue.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            SuggestedTypeValue.Location = new Point(219, 155);
            SuggestedTypeValue.Name = "SuggestedTypeValue";
            SuggestedTypeValue.Size = new Size(185, 30);
            SuggestedTypeValue.TabIndex = 6;
            SuggestedTypeValue.Text = "not enough data";
            // 
            // MustBePreciseCheckbox
            // 
            MustBePreciseCheckbox.AutoSize = true;
            MustBePreciseCheckbox.CheckAlign = ContentAlignment.MiddleRight;
            MustBePreciseCheckbox.Location = new Point(33, 118);
            MustBePreciseCheckbox.Name = "MustBePreciseCheckbox";
            MustBePreciseCheckbox.RightToLeft = RightToLeft.No;
            MustBePreciseCheckbox.Size = new Size(196, 34);
            MustBePreciseCheckbox.TabIndex = 7;
            MustBePreciseCheckbox.Text = "Must be precise?";
            MustBePreciseCheckbox.TextAlign = ContentAlignment.MiddleRight;
            MustBePreciseCheckbox.UseVisualStyleBackColor = true;
            MustBePreciseCheckbox.CheckedChanged += MustBePreciseCheckbox_CheckedChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(943, 252);
            Controls.Add(MustBePreciseCheckbox);
            Controls.Add(SuggestedTypeValue);
            Controls.Add(SuggestedTypeLabel);
            Controls.Add(IntegralOnlyCheckbox);
            Controls.Add(MaxValueTextBox);
            Controls.Add(MinValueTextBox);
            Controls.Add(MaxValueLabel);
            Controls.Add(MinValueLabel);
            Font = new Font("Segoe UI", 16F);
            Margin = new Padding(5, 6, 5, 6);
            Name = "Form1";
            Text = "Number suggester";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label MinValueLabel;
        private Label MaxValueLabel;
        private TextBox MinValueTextBox;
        private TextBox MaxValueTextBox;
        private CheckBox IntegralOnlyCheckbox;
        private Label SuggestedTypeLabel;
        private Label SuggestedTypeValue;
        private CheckBox MustBePreciseCheckbox;
    }
}
