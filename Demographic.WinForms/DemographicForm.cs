using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Demographic.WinForms.Presenter;
using Demographic.WinForms.View;


namespace Demographic.WinForms
{
    public partial class DemographicForm : Form, IDemographicForm
    {
        DemographicPresenter presenter;

        public string DisplayInitPath { set => fileInitPath.Text = value; }
        public string DisplayDeathPath { set => fileDeathPath.Text = value; }

        public DemographicForm()
        {
            InitializeComponent();
            presenter = new DemographicPresenter(this);
        }

        private void fileInitButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "CSV files (*.csv)|*.csv";
            if (openFileDialog.ShowDialog() == DialogResult.Cancel)
                return;
            presenter.PathInitFile = openFileDialog.FileName;
            presenter.DisplayInitPath();
            presenter.ProcessInitFile();
        }

        private void fileDeathButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "CSV files (*.csv)|*.csv";
            if (openFileDialog.ShowDialog() == DialogResult.Cancel)
                return;
            presenter.PathDeathFile = openFileDialog.FileName;
            presenter.DisplayDeathPath();
            presenter.ProcessDeathFile();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            presenter.BeginYear = beginYearBox.Text;
            presenter.EndYear = endYearBox.Text;
            presenter.NumOfPopulation = population.Text;
            presenter.MakeModel();
        }

        public void DisplayError(string errorText)
        {
            MessageBox.Show(errorText);
        }

        public void SetSplineChart(List<int> years, List<int> mPopulation, List<int> wPopulation, List<int> population)
        {
            splineChart.Series[0].Points.Clear();
            splineChart.Series[1].Points.Clear();
            splineChart.Series[2].Points.Clear();
            for (int i = 0; i < years.Count; i++)
            {
                splineChart.Series[0].Points.AddXY(years[i], population[i]);
                splineChart.Series[1].Points.AddXY(years[i], mPopulation[i]);
                splineChart.Series[2].Points.AddXY(years[i], wPopulation[i]);
            }
        }

        public void SetBarChart(List<string> ageGroups, List<int> mFinalPopulation, List<int> wFinalPopulation)
        {
            /*for (int i = 0; i < ageGroups.Count; i++)
            {
                barChartMen.Series[i].Points.Clear();
            }*/

            barChartMen.Series.Clear();
            barChartMen.Titles.Clear();
            barChartMen.ChartAreas.Clear();


            barChartWomen.Series.Clear();
            barChartWomen.Titles.Clear();
            barChartWomen.ChartAreas.Clear();

            barChartMen.ChartAreas.Add("M");
            barChartWomen.ChartAreas.Add("W");
            barChartMen.Titles.Add("Мужской пол");
            barChartWomen.Titles.Add("Женский пол");
            for (int i = 0; i < ageGroups.Count; i++)
            {               
                barChartMen.Series.Add(ageGroups[i]);
                barChartMen.Series[i].Points.Add(mFinalPopulation[i]);
               
                barChartWomen.Series.Add(ageGroups[i]);
                barChartWomen.Series[i].Points.Add(wFinalPopulation[i]);
            }
        }
    }
}
