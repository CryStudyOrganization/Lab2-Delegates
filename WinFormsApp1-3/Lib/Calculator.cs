using MathNet.Symbolics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.Lib
{
    internal class Calculator
    {
        private readonly Form1 form;

        public Calculator(Form1 form)
        {
            this.form = form;
        }

        public async Task SolveAsync()
        {
            // Создаем объект Stopwatch для измерения времени выполнения
            Stopwatch stopwatch = new Stopwatch();

            string equationString = form.Equation.Text;
            string xValueString = form.XValue.Text;
            string stepString = form.StepBox.Text;

            if (string.IsNullOrEmpty(equationString) || (form.UseRangeCheckbox.Checked && string.IsNullOrEmpty(xValueString)))
            {
                MessageBox.Show("Введите уравнение и, при необходимости, диапазон.");
                return;
            }

            bool useRange = form.UseRangeCheckbox.Checked;
            bool showStepInput = useRange && !string.IsNullOrEmpty(stepString);

            double stepValue = 1.0;

            if (showStepInput && !double.TryParse(stepString, out stepValue))
            {
                MessageBox.Show("Неверный формат шага.");
                return;
            }

            try
            {
                form.Solve.Enabled = false;
                form.ProgressBar.Visible = true;

                // Запускаем секундомер
                stopwatch.Start();

                if (useRange)
                {
                    await SolveRangeAsync(equationString, xValueString, stepValue);
                }
                else
                {
                    await SolveSingleValueAsync(equationString, xValueString);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
            finally
            {
                // Останавливаем секундомер
                stopwatch.Stop();

                // Получаем затраченное время в миллисекундах
                long elapsedMilliseconds = stopwatch.ElapsedMilliseconds;

                form.Solve.Enabled = true;
                form.ProgressBar.Visible = false;

                // Выводим затраченное время в миллисекундах
                MessageBox.Show($"Время выполнения: {elapsedMilliseconds} мс");
            }
        }

        private async Task SolveSingleValueAsync(string equationString, string xValueString)
        {
            double xValue = Convert.ToDouble(xValueString);
            int delayMilliseconds = 1000;
            int updateInterval = 100;
            int steps = delayMilliseconds / updateInterval;

            await Task.Run(async () =>
            {
                SymbolicExpression x = SymbolicExpression.Variable("x");
                SymbolicExpression equationExpression = SymbolicExpression.Parse(equationString);
                SymbolicExpression result = equationExpression.Substitute("x", xValue);

                for (int i = 0; i < steps; i++)
                {
                    int progress = (i * 100) / steps;

                    form.ProgressBar.Invoke((MethodInvoker)(() => { form.ProgressBar.Value = progress; }));

                    await Task.Delay(updateInterval);
                }

                form.ProgressBar.Invoke((MethodInvoker)(() => { form.ProgressBar.Value = 100; }));

                form.ResultLabel.Invoke((MethodInvoker)(() => { form.ResultLabel.Text = $"Решение: {result}"; }));
            });
        }

        private async Task SolveRangeAsync(string equationString, string xValueString, double stepValue)
        {
            double minValue = double.NegativeInfinity;
            double maxValue = double.PositiveInfinity;

            ParseRange(xValueString, out minValue, out maxValue);

            int totalSteps = (int)((maxValue - minValue) / stepValue) + 1;
            int currentStep = 0;

            await Task.Run(async () =>
            {
                SymbolicExpression x = SymbolicExpression.Variable("x");
                SymbolicExpression equationExpression = SymbolicExpression.Parse(equationString);
                SymbolicExpression result = SymbolicExpression.Zero;

                for (double xValue = minValue; xValue <= maxValue; xValue += stepValue)
                {
                    await Task.Delay(1000);
                    SymbolicExpression currentResult = equationExpression.Substitute("x", xValue);
                    result += currentResult;

                    int progressValue = (int)((++currentStep / (double)totalSteps) * 100);

                    form.ProgressBar.Invoke((MethodInvoker)(() => { form.ProgressBar.Value = progressValue; }));

                    form.ResultLabel.Invoke((MethodInvoker)(() =>
                    {
                        form.ResultLabel.Text = $"Промежуточное решение \"x\" = {xValue} на шаге {currentStep}: {result}";
                    }));
                }

                form.ResultLabel.Invoke((MethodInvoker)(() => { form.ResultLabel.Text = $"Решение на диапазоне: {result}"; }));
            });
        }

        private static void ParseRange(string rangeString, out double minValue, out double maxValue)
        {
            minValue = double.NegativeInfinity;
            maxValue = double.PositiveInfinity;

            string cleanedRange = rangeString.Trim('(', ')', '[', ']');
            string[] rangeParts = cleanedRange.Split(',');

            if (rangeParts.Length != 2)
            {
                return;
            }

            if (double.TryParse(rangeParts[0], out double min))
            {
                minValue = min;

                if (cleanedRange.StartsWith("("))
                {
                    minValue += double.Epsilon;
                }
            }

            if (double.TryParse(rangeParts[1], out double max))
            {
                maxValue = max;

                if (cleanedRange.EndsWith(")"))
                {
                    maxValue -= double.Epsilon;
                }
            }
        }

        public void ToggleRangeInput(bool useRange, bool showStepInput)
        {
            form.XValue.Enabled = true;
            form.StepLabel.Visible = showStepInput;
            form.StepBox.Visible = showStepInput;
        }

    }
}
