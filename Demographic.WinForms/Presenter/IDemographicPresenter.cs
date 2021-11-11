using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Demographic.WinForms.Presenter
{
    interface IDemographicPresenter
    {
        void ProcessInitFile();
        void ProcessDeathFile();
        void MakeModel();
        void DisplayInitPath();
        void DisplayDeathPath();
        string PathInitFile {get; set; }
        string PathDeathFile { get; set; }
        string BeginYear { set; }
        string EndYear { set; }
        string NumOfPopulation { set; }

    }
}
