using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Demographic
{
    public class Person : IPerson
    {

        private string _sex;
        private int _yearBirth;
        private int _age;

        private void NewChild()
        {
            if (_sex == "F" && _age >= 18 && _age <= 45)
                if (ProbabilityCalculator.IsEventHappened(0.151))
                    ChildBirth();
        }

        public delegate void Notification();
        public event Notification ChildBirth;
        public Person(string sex, int yearBirth)
        {
            _sex = sex;
            _yearBirth = yearBirth;
        }
        public string Sex { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int YearBirth { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool IsLiving { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public int Age => throw new NotImplementedException();

        public int DeathYear => throw new NotImplementedException();

        public void RenewYear(int year)
        {
            _age = year - _yearBirth;
            NewChild();
        }

        
    }
}
