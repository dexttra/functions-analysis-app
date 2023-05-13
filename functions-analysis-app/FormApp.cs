using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Windows.Forms.DataVisualization;
using System.Text.RegularExpressions;

namespace functions_analysis_app
{
    public partial class FormApp : Form
    {
        public FormApp()
        {
            InitializeComponent();

            // Определяем границы координатной плоскости
            chartGraph.ChartAreas[0].AxisX.Minimum = -10;
            chartGraph.ChartAreas[0].AxisX.Maximum = 10;
            chartGraph.ChartAreas[0].AxisY.Minimum = -10;
            chartGraph.ChartAreas[0].AxisY.Maximum = 10;
        }

        private void buttonGraphBuild_Click(object sender, EventArgs e)
        {
            // Считываем функцию
            string equation = textBoxEquation.Text;

            // Создаем новую серию данных для графика
            Series series = new Series();
            series.ChartType = SeriesChartType.Line;
            series.BorderWidth = 2;

            // Добавляем серию данных в Chart
            chartGraph.Series.Clear();
            chartGraph.Series.Add(series);

            // Находим постфиксную форму выражения (Reverse Polish Notaion)
            string postfixNotation = RPN(equation);

            // Вычисляем значения функции для каждого значения X и добавляем их в серию данных
            for (double x = -10; x <= 10; x += 0.1)
            {
                double y = Evaluate(postfixNotation, x);
                series.Points.AddXY(x, y);
            }
        }

        private string RPN(string equation)
        {
            Dictionary<char, int> priority = new Dictionary<char, int>
            {
                { '(', 0 },
                { ')', 0 },
                { '+', 1 },
                { '-', 1 },
                { '*', 2 },
                { '/', 2 },
                { '^', 3 }
            };
            Stack<char> operators = new Stack<char>();
            StringBuilder postfixNotation = new StringBuilder();

            for (int i = 0; i < equation.Length; i++)
            {
                char el = equation[i];
                if (priority.ContainsKey(el))
                {
                    if (el != '(')
                    {
                        while (operators.Count > 0 && priority[operators.Peek()] >= priority[el])
                        {
                            char temp = operators.Pop();
                            if (temp == '(')
                                break;
                            postfixNotation.Append(" ").Append(temp);
                        }
                    }
                    if (el != ')')
                        operators.Push(el);
                }
                else if (char.IsLetterOrDigit(el))
                {
                    StringBuilder operand = new StringBuilder();
                    while (i < equation.Length && (char.IsLetterOrDigit(equation[i]) || equation[i] == '.'))
                    {
                        operand.Append(equation[i]);
                        i++;
                    }
                    i--;
                    if (operand.ToString() == "x")
                        postfixNotation.Append(" x");
                    else
                        postfixNotation.Append(" ").Append(operand);
                }
            }

            while (operators.Count > 0) 
                postfixNotation.Append(" ").Append(operators.Pop());

            return (postfixNotation.ToString().Trim());
        }

        private double Evaluate(string postfixNotation, double x)
        {
            Stack<double> stack = new Stack<double>();
            string[] tokens = postfixNotation.Split(' ');

            foreach (string token in tokens)
            {
                if (double.TryParse(token, out double operand))
                {
                    stack.Push(operand);
                }
                else if (token == "x")
                {
                    stack.Push(x);
                }
                else
                {
                    double operand2 = stack.Pop();
                    double operand1 = stack.Pop();

                    switch (token)
                    {
                        case "+":
                            stack.Push(operand1 + operand2);
                            break;
                        case "-":
                            stack.Push(operand1 - operand2);
                            break;
                        case "*":
                            stack.Push(operand1 * operand2);
                            break;
                        case "/":
                            stack.Push(operand1 / operand2);
                            break;
                        case "^":
                            stack.Push(Math.Pow(operand1, operand2));
                            break;
                        default:
                            throw new ArgumentException("Invalid token: " + token);
                    }
                }
            }

            return stack.Peek(); 
        }
        private void buttonInputInfo_Click(object sender, EventArgs e)
        {

        }
    }
}
