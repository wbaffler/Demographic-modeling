using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Demographic.WinForms.View;
using Demographic.FileOperations;
using System.IO;

namespace Demographic.WinForms.Presenter
{
    class DemographicPresenter : IDemographicPresenter
    {
        private string _pathInit;
        private string _pathDeath;
        private string _beginYear;
        private string _endYear;
        private string _population;
        private readonly IDemographicForm view;
        private InitialFileParser initFile;
        private DeathFileParser deathFile;

        
        public DemographicPresenter(IDemographicForm demographicForm)
        {
            view = demographicForm;
        }
        public string PathInitFile { get => _pathInit; set => _pathInit = value; }
        public string PathDeathFile { get => _pathDeath; set => _pathDeath = value; }
        public string BeginYear { set => _beginYear = value; }
        public string EndYear { set => _endYear = value; }
        public string NumOfPopulation { set => _population = value; }

        public void DisplayDeathPath()
        {
            view.DisplayDeathPath = _pathDeath;
        }

        public void DisplayInitPath()
        {
            view.DisplayInitPath = _pathInit;
        }

        public void ProcessDeathFile()
        {
            try
            {
                deathFile = new DeathFileParser();
                deathFile.ReadFile(_pathDeath);

            }
            catch (FileLoadException ex)
            {
                view.DisplayError(ex.Message);
                _pathDeath = "";
                view.DisplayDeathPath = _pathDeath;

            }
            catch (FileNotFoundException)
            {
                view.DisplayError("Пустой путь к файлу");
                _pathDeath = "";
                view.DisplayDeathPath = _pathDeath;
            }
        }

        public void ProcessInitFile()
        {
            try
            {
                initFile = new InitialFileParser();
                initFile.ReadFile(_pathInit);

            }
            catch (FileLoadException ex)
            {
                view.DisplayError(ex.Message);
                _pathInit = "";
                view.DisplayInitPath = _pathInit;
            }
            catch (FileNotFoundException)
            {
                view.DisplayError("Пустой путь к файлу");
                _pathInit = "";
                view.DisplayInitPath = _pathInit;
            }

        }

        public void StartModeling()
        {
            Console.WriteLine(_beginYear + " " + _endYear + " " + _population);
        }


    }
}
