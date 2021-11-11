using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Demographic
{
    public class InitializeData : IInitializeData
    {
        private int _beginYear;
        private int _endYear;
        private int _population;
        private List<ArrayList> _initMatrix;
        private List<ArrayList> _deathMatrix;
        private List<Person> people = new List<Person>();
        public int BeginYear => _beginYear;

        public int EndYear => _endYear;

        public int Population => _population;

        public List<ArrayList> InitMatrix => _initMatrix;

        public List<ArrayList> DeathMatrix => _deathMatrix;

        public void Initialize(string beginYear, string endYear, string population,
            List<ArrayList> initMatrix, List<ArrayList> deathMatrix)
        {
            Engine engine = new Engine();
            if (initMatrix.Count == 0 || deathMatrix.Count == 0)
                throw new FileNotFoundException();
            if (!int.TryParse(beginYear, out _) || !int.TryParse(endYear, out _)
                || !int.TryParse(population, out _))
                throw new FormatException();

            _beginYear = Convert.ToInt32(beginYear);
            _endYear = Convert.ToInt32(endYear);
            _population = Convert.ToInt32(population);
            _initMatrix = initMatrix;
            _deathMatrix = deathMatrix;

            
        }
    }
}
