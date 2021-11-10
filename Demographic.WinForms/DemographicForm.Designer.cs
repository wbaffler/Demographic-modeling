
namespace Demographic.WinForms
{
    partial class DemographicForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DemographicForm));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.fileInitButton = new System.Windows.Forms.Button();
            this.fileDeathButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.fileInitPath = new System.Windows.Forms.Label();
            this.fileDeathPath = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.beginYearBox = new System.Windows.Forms.TextBox();
            this.endYearBox = new System.Windows.Forms.TextBox();
            this.population = new System.Windows.Forms.TextBox();
            this.startButton = new System.Windows.Forms.Button();
            this.splineChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.barChartMen = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.barChartWomen = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.splineChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barChartMen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barChartWomen)).BeginInit();
            this.SuspendLayout();
            // 
            // fileInitButton
            // 
            resources.ApplyResources(this.fileInitButton, "fileInitButton");
            this.fileInitButton.Name = "fileInitButton";
            this.fileInitButton.UseVisualStyleBackColor = true;
            this.fileInitButton.Click += new System.EventHandler(this.fileInitButton_Click);
            // 
            // fileDeathButton
            // 
            resources.ApplyResources(this.fileDeathButton, "fileDeathButton");
            this.fileDeathButton.Name = "fileDeathButton";
            this.fileDeathButton.UseVisualStyleBackColor = true;
            this.fileDeathButton.Click += new System.EventHandler(this.fileDeathButton_Click);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // fileInitPath
            // 
            resources.ApplyResources(this.fileInitPath, "fileInitPath");
            this.fileInitPath.Name = "fileInitPath";
            // 
            // fileDeathPath
            // 
            resources.ApplyResources(this.fileDeathPath, "fileDeathPath");
            this.fileDeathPath.Name = "fileDeathPath";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // beginYearBox
            // 
            resources.ApplyResources(this.beginYearBox, "beginYearBox");
            this.beginYearBox.Name = "beginYearBox";
            // 
            // endYearBox
            // 
            resources.ApplyResources(this.endYearBox, "endYearBox");
            this.endYearBox.Name = "endYearBox";
            // 
            // population
            // 
            resources.ApplyResources(this.population, "population");
            this.population.Name = "population";
            // 
            // startButton
            // 
            resources.ApplyResources(this.startButton, "startButton");
            this.startButton.Name = "startButton";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // splineChart
            // 
            chartArea1.AxisX.Title = "Год";
            chartArea1.AxisY.Title = "Возраст";
            chartArea1.Name = "ChartArea1";
            this.splineChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.splineChart.Legends.Add(legend1);
            resources.ApplyResources(this.splineChart, "splineChart");
            this.splineChart.Name = "splineChart";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series1.Legend = "Legend1";
            series1.Name = "Общее";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series2.Legend = "Legend1";
            series2.Name = "Мужской пол";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series3.Legend = "Legend1";
            series3.Name = "Женский пол";
            this.splineChart.Series.Add(series1);
            this.splineChart.Series.Add(series2);
            this.splineChart.Series.Add(series3);
            // 
            // barChartMen
            // 
            chartArea2.AxisX.Title = "Возраст";
            chartArea2.AxisY.Title = "Численность";
            chartArea2.Name = "ChartArea1";
            this.barChartMen.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.barChartMen.Legends.Add(legend2);
            resources.ApplyResources(this.barChartMen, "barChartMen");
            this.barChartMen.Name = "barChartMen";
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bar;
            series4.Legend = "Legend1";
            series4.Name = "Мужской пол";
            series4.YValuesPerPoint = 6;
            this.barChartMen.Series.Add(series4);
            // 
            // barChartWomen
            // 
            chartArea3.Name = "ChartArea1";
            this.barChartWomen.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.barChartWomen.Legends.Add(legend3);
            resources.ApplyResources(this.barChartWomen, "barChartWomen");
            this.barChartWomen.Name = "barChartWomen";
            series5.ChartArea = "ChartArea1";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bar;
            series5.Legend = "Legend1";
            series5.Name = "Женский пол";
            series5.YValuesPerPoint = 6;
            this.barChartWomen.Series.Add(series5);
            // 
            // DemographicForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.barChartWomen);
            this.Controls.Add(this.barChartMen);
            this.Controls.Add(this.splineChart);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.population);
            this.Controls.Add(this.endYearBox);
            this.Controls.Add(this.beginYearBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.fileDeathPath);
            this.Controls.Add(this.fileInitPath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.fileDeathButton);
            this.Controls.Add(this.fileInitButton);
            this.Name = "DemographicForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.splineChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barChartMen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barChartWomen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button fileInitButton;
        private System.Windows.Forms.Button fileDeathButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label fileInitPath;
        private System.Windows.Forms.Label fileDeathPath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox beginYearBox;
        private System.Windows.Forms.TextBox endYearBox;
        private System.Windows.Forms.TextBox population;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.DataVisualization.Charting.Chart splineChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart barChartMen;
        private System.Windows.Forms.DataVisualization.Charting.Chart barChartWomen;
    }
}

