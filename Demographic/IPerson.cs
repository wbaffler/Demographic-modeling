using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Demographic
{
    public interface IPerson
    {
        string Sex { get; set; }
        int YearBirth { get; set; }
        int Age { get; }
        bool IsLiving { get; set; }
        int DeathYear { get; }
        void RenewYear(int year);
    }
}
