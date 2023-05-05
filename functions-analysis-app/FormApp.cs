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

            // Вычисляем значения функции для каждого значения X и добавляем их в серию данных
            for (double x = -10; x <= 10; x += 0.1)
            {
                double y = Evaluate(equation, x);
                series.Points.AddXY(x, y);
            }
        }

        private double Evaluate(string equation, double x)
        {
            // Разделяем строку на массив операторов и операндов
            string[] operators = new string[] { "*", "/", "+", "-" };
            string[] operands = equation.Split(operators, StringSplitOptions.RemoveEmptyEntries);

            // Создаем новый список, в котором будут храниться числовые значения операндов
            List<double> values = new List<double>();

            // Преобразуем каждый операнд в числовое значение и добавляем его в список values
            foreach (string operand in operands)
            {
 
                if (operand == "x")
                {
                    values.Add(x);
                }
                else 
                {
                    values.Add(int.Parse(operand));
                }
              
            }

            // Создаем новый список, в котором будут храниться операторы
            List<string> operatorsList = new List<string>();

            // Добавляем все операторы в список operatorsList
            foreach (char c in equation)
            {
                if (operators.Contains(c.ToString()))
                {
                    operatorsList.Add(c.ToString());
                }
            }

            // Вычисляем значение выражения, используя операторы и операнды
            double result = values[0];
            for (int i = 0; i < operatorsList.Count; i++)
            {
                string op = operatorsList[i];
                double val = values[i + 1];

                switch (op)
                {
                    case "*":
                        result *= val;
                        break;
                    case "/":
                        result /= val;
                        break;
                    case "+":
                        result += val;
                        break;
                    case "-":
                        result -= val;
                        break;
                }
            }

            return result;
        }

        private void buttonInputInfo_Click(object sender, EventArgs e)
        {

        }
    }
}
