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

            chartGraph.Series.Clear();

            // Устанавливаем жирную линию для оси Y = 0
            chartGraph.ChartAreas[0].AxisY.StripLines.Add(new StripLine
            {
                Interval = 0,
                StripWidth = 0,
                BackColor = Color.Black,
                BorderColor = Color.Black,
                BorderWidth = 2,
                BorderDashStyle = ChartDashStyle.Solid
            });

            // Устанавливаем жирную линию для оси X = 0
            chartGraph.ChartAreas[0].AxisX.StripLines.Add(new StripLine
            {
                Interval = 0,
                StripWidth = 0,
                BackColor = Color.Black,
                BorderColor = Color.Black,
                BorderWidth = 2,
                BorderDashStyle = ChartDashStyle.Solid
            });

            textBoxResult.ReadOnly = true;

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
            chartGraph.Series.Add(series);

            series.Name = equation;

            // Находим постфиксную форму выражения (Reverse Polish Notaion)
            string postfixNotation = RPN(equation);

            // Вычисляем значения функции для каждого значения X и добавляем их в серию данных
            for (double x = -10; x <= 10; x += 0.1)
            {
                double y = Evaluate(postfixNotation, x);
                series.Points.AddXY(x, y);
            }

        }

        //RPN - Reverse Polish Notation
        private string RPN(string equation)
        {
            //Создаем словарь с приоритетом операций
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
            //Создаем стек операторов и StringBuilder для постфиксной записи
            Stack<char> operators = new Stack<char>();
            StringBuilder postfixNotation = new StringBuilder();

            //Перебираем каждый символ уравнения
            for (int i = 0; i < equation.Length; i++)
            {
                char el = equation[i];

                //Проверяем является ли символ операцией
                if (priority.ContainsKey(el))
                {
                    if (el != '(')
                    {
                        //Проверяем приоритет первого элемента стека
                        while (operators.Count > 0 && priority[operators.Peek()] >= priority[el])
                        {
                            //Если приоритет у новой операции меньше либо равен приоритету предыдущей, то удаляем из стека первую операцию и записываем в постфиксную запись, для сохранения порядка операций
                            char temp = operators.Pop();
                            if (temp == '(')
                                break;
                            postfixNotation.Append(" ").Append(temp);
                        }
                    }
                    if (el != ')') operators.Push(el);
                }
                //Создаем StringBuilder в который записываем операнд и сохраняем в постфиксной записи
                else if (char.IsLetterOrDigit(el))
                {
                    StringBuilder operand = new StringBuilder();
                    while (i < equation.Length && (char.IsLetterOrDigit(equation[i])))
                    {
                        operand.Append(equation[i]);
                        i++;
                    }
                    //Для цикла for
                    i--;

                    if (operand.ToString() == "x") postfixNotation.Append(" x");
                    else postfixNotation.Append(" ").Append(operand);
                }
            }

            //Записываем операции в постфиксную запись
            while (operators.Count > 0) postfixNotation.Append(" ").Append(operators.Pop());

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
            MessageBox.Show(
        "Вы можете использовать операции: * / ^ + - ( )\r\nВсе записывается подряд, без пробелов.",
        "Инструкция ввода",
        MessageBoxButtons.OK,
        MessageBoxIcon.Information);
        }

        private void buttonEvaluate_Click(object sender, EventArgs e)
        {
            if (comboBoxAnalysis.SelectedIndex == 0)
            {
                textBoxResult.Text = FindXInterceptions(textBoxEquation.Text);
            }

            if (comboBoxAnalysis.SelectedIndex == 1)
            {
                textBoxResult.Text = FindYInterception(textBoxEquation.Text);
            }
            if (comboBoxAnalysis.SelectedIndex == 2)
            {
                textBoxResult.Text = EvenOrOdd(textBoxEquation.Text);
            }

        }

        private string FindXInterceptions(string equation)
        {
            List<string> interceptions = new List<string>();
            for (int x = -50; x <= 50; x++)
            {
                double y = Evaluate(RPN(equation), x);
                if (y == 0)
                {
                    interceptions.Add($"({x}, 0)");
                }
            }

            if (interceptions.Count == 0)
            {
                return "Нет пересечений с Ox";
            }
            else
            {
                return "Пересечения с Ox: " + string.Join(", ", interceptions);
            }
        }


        private string FindYInterception(string equation)
        {
            double yIntercept = Evaluate(RPN(equation), 0);

            if (double.IsInfinity(yIntercept)) return "Нет пересечений с Oy";
            else return $"Пересечение с Oy: (0, {yIntercept})";
        }

        private string FindDomain(string equation)
        {
            if (equation.Contains("/x"))
            {
                return "Область определения: (-∞, 0) U (0, +∞)";
            }
            else
            {
                return "Область определения: R";
            }
        }
        private string EvenOrOdd(string equation)
        {
            Random random = new Random();
            int rndNumber = random.Next(-5000, 5000);
            string postfixNotation = RPN(equation);

            double num1 = Evaluate(postfixNotation, rndNumber);
            double num2 = Evaluate(postfixNotation, -rndNumber);

            if (num1 == num2) return "Функция является чётной";
            else if (num2 == -num1) return "Функция является нечётной";
            else return "Функций ни чётная, ни нечётная";
        }

        private void buttonGraphClear_Click(object sender, EventArgs e)
        {
            chartGraph.Series.Clear();
        }


        private void buttonGraphSave_Click(object sender, EventArgs e)
        {
            // Отображаем диалоговое окно для сохранения файла
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PNG Image|*.png|JPEG Image|*.jpg";
            saveFileDialog.Title = "Сохранить график";
            saveFileDialog.ShowDialog();

            if (saveFileDialog.FileName != "")
            {
                string extension = System.IO.Path.GetExtension(saveFileDialog.FileName);
                ChartImageFormat imageFormat;

                switch (extension)
                {
                    case ".png":
                        imageFormat = ChartImageFormat.Png;
                        break;
                    case ".jpg":
                        imageFormat = ChartImageFormat.Jpeg;
                        break;
                    default:
                        MessageBox.Show("Неподдерживаемый формат изображения.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                }

                // Сохраняем график в выбранном формате
                chartGraph.SaveImage(saveFileDialog.FileName, imageFormat);
                MessageBox.Show("График успешно сохранен.", "Сохранение графика", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


    }
}

