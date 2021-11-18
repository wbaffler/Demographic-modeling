using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Demographic
{
    public interface IPerson
    {
        SexClass.Sex Sex { get; }
        int YearBirth { get; }
        int Age { get; }
        bool IsLiving { get; }
        int DeathYear { get; }
        void RenewYear(int year);
    }
}
