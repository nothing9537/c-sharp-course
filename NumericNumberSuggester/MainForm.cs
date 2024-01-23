using System.Numerics;

namespace NumericNumberSuggester
{
    public partial class MainForm : Form
    {
        // Events
        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MustBePreciseCheckbox.Visible = false;
        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            RecalculateSuggestedType();
            SetColorOfMaxValueTextField();
        }

        private void IntegralOnlyCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            MustBePreciseCheckbox.Visible = !IntegralOnlyCheckbox.Checked;

            RecalculateSuggestedType();
        }

        private void MustBePreciseCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            RecalculateSuggestedType();
        }

        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            var textBox = (TextBox)sender;

            if (!IsValidInput(e.KeyChar, textBox))
            {
                e.Handled = true;
            }
        }

        // Handling

        private void RecalculateSuggestedType()
        {
            if (IsInputComplete())
            {
                var minValue = BigInteger.Parse(MinValueTextBox.Text);
                var maxValue = BigInteger.Parse(MaxValueTextBox.Text);

                if (maxValue >= minValue)
                {
                    SuggestedTypeValue.Text = NumericTypeSuggester.GetName(
                        minValue,
                        maxValue,
                        IntegralOnlyCheckbox.Checked,
                        MustBePreciseCheckbox.Checked
                    );

                    return;
                }
            }

            SuggestedTypeValue.Text = "not enough data";
        }

        private void SetColorOfMaxValueTextField()
        {
            bool isValid = true;

            if (IsInputComplete())
            {
                var minValue = BigInteger.Parse(MinValueTextBox.Text);
                var maxValue = BigInteger.Parse(MaxValueTextBox.Text);

                if (maxValue < minValue)
                {
                    isValid = false;
                }
            }

            MaxValueTextBox.BackColor = isValid ? Color.White : Color.IndianRed;
        }

        // Validation
        private static bool IsValidInput(char keyChar, TextBox sender)
        {
            return (
                char.IsControl(keyChar)
                || char.IsDigit(keyChar)
                || (keyChar == '-' && sender.SelectionStart == 0)
            );
        }

        private bool IsInputComplete()
        {
            return MinValueTextBox.Text.Length > 0 &&
                MinValueTextBox.Text != "-" &&
                MaxValueTextBox.Text.Length > 0 &&
                MaxValueTextBox.Text != "-";
        }
    }
}
