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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormApp));
            this.chartGraph = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.buttonGraphBuild = new System.Windows.Forms.Button();
            this.textBoxEquation = new System.Windows.Forms.TextBox();
            this.pictureBoxFunction = new System.Windows.Forms.PictureBox();
            this.pictureBoxEqual = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonInputInfo = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chartGraph)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFunction)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEqual)).BeginInit();
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
            this.chartGraph.Size = new System.Drawing.Size(492, 350);
            this.chartGraph.TabIndex = 0;
            this.chartGraph.Text = "chart1";
            // 
            // buttonGraphBuild
            // 
            this.buttonGraphBuild.Font = new System.Drawing.Font("Sitka Small", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonGraphBuild.Location = new System.Drawing.Point(12, 409);
            this.buttonGraphBuild.Name = "buttonGraphBuild";
            this.buttonGraphBuild.Size = new System.Drawing.Size(246, 44);
            this.buttonGraphBuild.TabIndex = 1;
            this.buttonGraphBuild.Text = "Построить график";
            this.buttonGraphBuild.UseVisualStyleBackColor = true;
            this.buttonGraphBuild.Click += new System.EventHandler(this.buttonGraphBuild_Click);
            // 
            // textBoxEquation
            // 
            this.textBoxEquation.Font = new System.Drawing.Font("Century", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxEquation.Location = new System.Drawing.Point(152, 368);
            this.textBoxEquation.Name = "textBoxEquation";
            this.textBoxEquation.Size = new System.Drawing.Size(352, 36);
            this.textBoxEquation.TabIndex = 2;
            // 
            // pictureBoxFunction
            // 
            this.pictureBoxFunction.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxFunction.Image")));
            this.pictureBoxFunction.Location = new System.Drawing.Point(12, 368);
            this.pictureBoxFunction.Name = "pictureBoxFunction";
            this.pictureBoxFunction.Size = new System.Drawing.Size(79, 35);
            this.pictureBoxFunction.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxFunction.TabIndex = 3;
            this.pictureBoxFunction.TabStop = false;
            // 
            // pictureBoxEqual
            // 
            this.pictureBoxEqual.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxEqual.Image")));
            this.pictureBoxEqual.Location = new System.Drawing.Point(97, 368);
            this.pictureBoxEqual.Name = "pictureBoxEqual";
            this.pictureBoxEqual.Size = new System.Drawing.Size(49, 36);
            this.pictureBoxEqual.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxEqual.TabIndex = 4;
            this.pictureBoxEqual.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Sitka Text", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(728, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(227, 35);
            this.label1.TabIndex = 5;
            this.label1.Text = "Анализ функции";
            // 
            // buttonInputInfo
            // 
            this.buttonInputInfo.Font = new System.Drawing.Font("Sitka Small", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonInputInfo.Location = new System.Drawing.Point(264, 410);
            this.buttonInputInfo.Name = "buttonInputInfo";
            this.buttonInputInfo.Size = new System.Drawing.Size(240, 44);
            this.buttonInputInfo.TabIndex = 6;
            this.buttonInputInfo.Text = "Инструкция ввода";
            this.buttonInputInfo.UseVisualStyleBackColor = true;
            this.buttonInputInfo.Click += new System.EventHandler(this.buttonInputInfo_Click);
            // 
            // FormApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1158, 458);
            this.Controls.Add(this.buttonInputInfo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBoxEqual);
            this.Controls.Add(this.pictureBoxFunction);
            this.Controls.Add(this.textBoxEquation);
            this.Controls.Add(this.buttonGraphBuild);
            this.Controls.Add(this.chartGraph);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormApp";
            this.Text = "Functions analysis";
            ((System.ComponentModel.ISupportInitialize)(this.chartGraph)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFunction)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEqual)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartGraph;
        private System.Windows.Forms.Button buttonGraphBuild;
        private System.Windows.Forms.TextBox textBoxEquation;
        private System.Windows.Forms.PictureBox pictureBoxFunction;
        private System.Windows.Forms.PictureBox pictureBoxEqual;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonInputInfo;
    }
}

