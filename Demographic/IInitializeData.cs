using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Demographic
{
    public interface IInitializeData
    {
        void Initialize(string beginYear, string endYear,
            string population, List<ArrayList> initMatrix, List<ArrayList> deathMatrix);
        int BeginYear { get; }
        int EndYear { get; }
        int Population { get; }

        List<ArrayList> InitMatrix { get; }
        List<ArrayList> DeathMatrix { get; }

    }
}
