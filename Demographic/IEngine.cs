using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Demographic
{
    public interface IEngine
    {
        void Modeling(string beginYear, string endYear, string population,
            List<ArrayList> initMatrix, List<ArrayList> deathMatrix);

        List<int> Years { get; }
        List<double> MPopulation { get; }
        List<double> WPopulation { get; }
        List<double> Population { get; }
        List<int> AgeGroups { get; }
        List<double> MAgePopulation { get; }
        List<double> WAgePopulation { get; }
    }
}
