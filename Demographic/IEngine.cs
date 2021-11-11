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
        List<int> MPopulation { get; }
        List<int> WPopulation { get; }
        List<int> Population { get; }
        List<List<int>> AgeGroups { get; }
        List<int> MAgePopulation { get; }
        List<int> WAgePopulation { get; }
    }
}
