using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace test
{
    public class Engine : IEngine
    {
        
        public List<int> Years => throw new NotImplementedException();

        public List<double> MPopulation => throw new NotImplementedException();

        public List<double> WPopulation => throw new NotImplementedException();

        public List<double> Population => throw new NotImplementedException();

        public List<int> AgeGroups => throw new NotImplementedException();

        public List<double> MAgePopulation => throw new NotImplementedException();

        public List<double> WAgePopulation => throw new NotImplementedException();

        public void Initialize(string beginYear, string endYear, 
            string population, List<ArrayList> initMatrix, List<ArrayList> deathMatrix)
        {
            {
                if (initMatrix == null || deathMatrix == null)
                    throw new FileNotFoundException();
                if (!int.TryParse(beginYear, out _) || !int.TryParse(endYear, out _)
                    || !int.TryParse(population, out _))
                    throw new FormatException();
            }
            
        }

        public void Modeling()
        {
            throw new NotImplementedException();
        }
    }
}
