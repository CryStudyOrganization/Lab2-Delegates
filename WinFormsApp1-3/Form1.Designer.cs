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
            solve = new Button();
            equation = new TextBox();
            xValue = new TextBox();
            resultLabel = new Label();
            label1 = new Label();
            label2 = new Label();
            progressBar = new ProgressBar();
            useRangeCheckbox = new CheckBox();
            stepBox = new TextBox();
            stepLabel = new Label();
            SuspendLayout();
            // 
            // solve
            // 
            solve.Location = new Point(590, 72);
            solve.Name = "solve";
            solve.Size = new Size(101, 34);
            solve.TabIndex = 0;
            solve.Text = "Solve";
            solve.UseVisualStyleBackColor = true;
            solve.Click += solve_Click;
            // 
            // equation
            // 
            equation.Location = new Point(36, 72);
            equation.Multiline = true;
            equation.Name = "equation";
            equation.Size = new Size(367, 34);
            equation.TabIndex = 1;
            equation.Text = "(4*x^3)-(7*x^2)+1";
            // 
            // xValue
            // 
            xValue.Location = new Point(409, 72);
            xValue.Multiline = true;
            xValue.Name = "xValue";
            xValue.Size = new Size(175, 34);
            xValue.TabIndex = 2;
            xValue.Text = "[-10, 10)";
            // 
            // resultLabel
            // 
            resultLabel.AutoSize = true;
            resultLabel.Location = new Point(36, 122);
            resultLabel.Name = "resultLabel";
            resultLabel.Size = new Size(0, 20);
            resultLabel.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(36, 35);
            label1.Name = "label1";
            label1.Size = new Size(147, 20);
            label1.TabIndex = 4;
            label1.Text = "Введите уравнение:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(409, 35);
            label2.Name = "label2";
            label2.Size = new Size(19, 20);
            label2.TabIndex = 5;
            label2.Text = "x:";
            // 
            // progressBar
            // 
            progressBar.Location = new Point(36, 194);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(747, 29);
            progressBar.TabIndex = 6;
            // 
            // useRangeCheckbox
            // 
            useRangeCheckbox.AutoSize = true;
            useRangeCheckbox.Location = new Point(590, 35);
            useRangeCheckbox.Name = "useRangeCheckbox";
            useRangeCheckbox.Size = new Size(103, 24);
            useRangeCheckbox.TabIndex = 7;
            useRangeCheckbox.Text = "Диапазон:";
            useRangeCheckbox.UseVisualStyleBackColor = true;
            // 
            // stepBox
            // 
            stepBox.Location = new Point(409, 145);
            stepBox.Multiline = true;
            stepBox.Name = "stepBox";
            stepBox.Size = new Size(175, 34);
            stepBox.TabIndex = 8;
            // 
            // stepLabel
            // 
            stepLabel.AutoSize = true;
            stepLabel.Location = new Point(409, 122);
            stepLabel.Name = "stepLabel";
            stepLabel.Size = new Size(46, 20);
            stepLabel.TabIndex = 9;
            stepLabel.Text = "Step: ";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(794, 256);
            Controls.Add(stepLabel);
            Controls.Add(stepBox);
            Controls.Add(useRangeCheckbox);
            Controls.Add(progressBar);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(resultLabel);
            Controls.Add(xValue);
            Controls.Add(equation);
            Controls.Add(solve);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button solve;
        private TextBox equation;
        private TextBox xValue;
        private Label resultLabel;
        private Label label1;
        private Label label2;
        private ProgressBar progressBar;
        private CheckBox useRangeCheckbox;
        private TextBox stepBox;
        private Label stepLabel;
    }
}