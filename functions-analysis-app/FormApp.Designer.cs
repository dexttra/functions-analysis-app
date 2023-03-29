namespace functions_analysis_app
{
    partial class FormApp
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chartGraph = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.buttonGraphBuild = new System.Windows.Forms.Button();
            this.textBoxEquation = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.chartGraph)).BeginInit();
            this.SuspendLayout();
            // 
            // chartGraph
            // 
            chartArea1.Name = "ChartArea1";
            this.chartGraph.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartGraph.Legends.Add(legend1);
            this.chartGraph.Location = new System.Drawing.Point(12, 12);
            this.chartGraph.Name = "chartGraph";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartGraph.Series.Add(series1);
            this.chartGraph.Size = new System.Drawing.Size(442, 300);
            this.chartGraph.TabIndex = 0;
            this.chartGraph.Text = "chart1";
            // 
            // buttonGraphBuild
            // 
            this.buttonGraphBuild.Location = new System.Drawing.Point(532, 25);
            this.buttonGraphBuild.Name = "buttonGraphBuild";
            this.buttonGraphBuild.Size = new System.Drawing.Size(179, 23);
            this.buttonGraphBuild.TabIndex = 1;
            this.buttonGraphBuild.Text = "Построить график";
            this.buttonGraphBuild.UseVisualStyleBackColor = true;
            // 
            // textBoxEquation
            // 
            this.textBoxEquation.Location = new System.Drawing.Point(36, 373);
            this.textBoxEquation.Name = "textBoxEquation";
            this.textBoxEquation.Size = new System.Drawing.Size(235, 20);
            this.textBoxEquation.TabIndex = 2;
            // 
            // FormApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textBoxEquation);
            this.Controls.Add(this.buttonGraphBuild);
            this.Controls.Add(this.chartGraph);
            this.Name = "FormApp";
            this.Text = "Приложение для анализа функции";
            ((System.ComponentModel.ISupportInitialize)(this.chartGraph)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartGraph;
        private System.Windows.Forms.Button buttonGraphBuild;
        private System.Windows.Forms.TextBox textBoxEquation;
    }
}

