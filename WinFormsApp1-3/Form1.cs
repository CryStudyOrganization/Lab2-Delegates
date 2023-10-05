using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using MathNet.Symbolics;
using WinFormsApp1.Lib;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        internal Label StepLabel => stepLabel;
        internal TextBox StepBox => stepBox;
        internal TextBox Equation => equation;
        internal TextBox XValue => xValue;
        internal CheckBox UseRangeCheckbox => useRangeCheckbox;
        internal Button Solve => solve;
        internal ProgressBar ProgressBar => progressBar;
        internal Label ResultLabel => resultLabel;

        private readonly Calculator calculator;

        public Form1()
        {
            InitializeComponent();
            calculator = new Calculator(this);
            progressBar.Visible = false;

            useRangeCheckbox.CheckedChanged += UseRangeCheckbox_CheckedChanged;

            // Изначально скрываем stepBox и stepLabel
            stepBox.Visible = false;
            stepLabel.Visible = false;
        }

        private void UseRangeCheckbox_CheckedChanged(object? sender, EventArgs e)
        {
            bool isChecked = useRangeCheckbox.Checked;
            calculator.ToggleRangeInput(isChecked, isChecked);

            stepBox.Visible = isChecked;
            stepLabel.Visible = isChecked;
        }


        private async void solve_Click(object sender, EventArgs e)
        {
            await calculator.SolveAsync();
        }

        private void useRangeCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            calculator.ToggleRangeInput(useRangeCheckbox.Checked, useRangeCheckbox.Checked);
        }
    }
}