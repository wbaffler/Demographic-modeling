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
        void SetSplineChart(List<int> years, List<int> mPopulation, List<int> wPopulation,
            List<int> population);
        void SetBarChart(List<string> ageGroups, List<int> mFinalPopulation, List<int> wFinalPopulation);

    }
}
