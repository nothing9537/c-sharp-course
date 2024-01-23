namespace WinFormsApp1
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
            CounterLabel = new Label();
            IncreaseCounterButton = new Button();
            HideButtonCheckbox = new CheckBox();
            YearOfBirthTextbox = new TextBox();
            SuspendLayout();
            // 
            // CounterLabel
            // 
            CounterLabel.AutoSize = true;
            CounterLabel.Font = new Font("Microsoft YaHei", 20F, FontStyle.Bold, GraphicsUnit.Point, 0);
            CounterLabel.Location = new Point(72, 113);
            CounterLabel.Name = "CounterLabel";
            CounterLabel.Size = new Size(32, 36);
            CounterLabel.TabIndex = 0;
            CounterLabel.Text = "0";
            // 
            // IncreaseCounterButton
            // 
            IncreaseCounterButton.Font = new Font("Arial", 20F);
            IncreaseCounterButton.Location = new Point(110, 106);
            IncreaseCounterButton.Name = "IncreaseCounterButton";
            IncreaseCounterButton.Size = new Size(164, 53);
            IncreaseCounterButton.TabIndex = 1;
            IncreaseCounterButton.Text = "ClickMe";
            IncreaseCounterButton.UseVisualStyleBackColor = true;
            IncreaseCounterButton.Click += IncreaseCounterButton_Click;
            // 
            // HideButtonCheckbox
            // 
            HideButtonCheckbox.AutoSize = true;
            HideButtonCheckbox.Font = new Font("Arial", 16F);
            HideButtonCheckbox.Location = new Point(72, 165);
            HideButtonCheckbox.Name = "HideButtonCheckbox";
            HideButtonCheckbox.Size = new Size(141, 29);
            HideButtonCheckbox.TabIndex = 2;
            HideButtonCheckbox.Text = "Hide button";
            HideButtonCheckbox.UseVisualStyleBackColor = true;
            HideButtonCheckbox.CheckedChanged += HideButtonCheckbox_CheckedChanged;
            // 
            // YearOfBirthTextbox
            // 
            YearOfBirthTextbox.Font = new Font("Arial", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            YearOfBirthTextbox.Location = new Point(280, 113);
            YearOfBirthTextbox.Name = "YearOfBirthTextbox";
            YearOfBirthTextbox.Size = new Size(165, 39);
            YearOfBirthTextbox.TabIndex = 3;
            YearOfBirthTextbox.KeyPress += YearOfBirthTextbox_KeyPress;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(YearOfBirthTextbox);
            Controls.Add(HideButtonCheckbox);
            Controls.Add(IncreaseCounterButton);
            Controls.Add(CounterLabel);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label CounterLabel;
        private Button IncreaseCounterButton;
        private CheckBox HideButtonCheckbox;
        private TextBox YearOfBirthTextbox;
    }
}
