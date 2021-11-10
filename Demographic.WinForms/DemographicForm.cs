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
            presenter.StartModeling();
        }

        public void DisplayError(string errorText)
        {
            MessageBox.Show(errorText);
        }

        public void SetSplineChart(List<int> years, List<double> mPopulation, List<double> wPopulation, List<double> Population)
        {
            throw new NotImplementedException();
        }

        public void SetBarChart(List<string> ageGroups, List<double> mFinalPopulation, List<double> wFinalPopulation)
        {
            throw new NotImplementedException();
        }
    }
}
