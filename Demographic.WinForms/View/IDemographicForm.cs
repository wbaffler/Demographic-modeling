using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Demographic.WinForms.View
{
    interface IDemographicForm
    {
        string DisplayInitPath { set; }
        string DisplayDeathPath { set; }
        void DisplayError(string errorText);
        void SetSplineChart(List<int> years, List<double> mPopulation, List<double> wPopulation,
            List<double> Population);
        void SetBarChart(List<string> ageGroups, List<double> mPopulation, List<double> wPopulation);

    }
}
