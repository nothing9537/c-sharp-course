namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private int _counterClicks = 0;
        private void IncreaseCounterButton_Click(object sender, EventArgs e)
        {
            _counterClicks++;

            CounterLabel.Text = _counterClicks.ToString();
        }

        private void HideButtonCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            bool isChecked = HideButtonCheckbox.Checked;

            IncreaseCounterButton.Visible = !isChecked;
        }

        private void YearOfBirthTextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!IsValid(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private bool IsValid(char c)
        {
            return char.IsControl(c) || (
                char.IsDigit(c) && YearOfBirthTextbox.Text.Length < 4);
        }
    }
}
