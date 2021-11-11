using System;
using System.Collections;
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
        private List<ArrayList> _deathRules;
        private int _deathYear;
        private bool _isLiving;
        private int _currentYear;



        private void NewChild()
        {
            if (_sex == "F" && _age >= 18 && _age <= 45)
                if (ProbabilityCalculator.IsEventHappened(0.151))
                    ChildBirth();
        }

        private void DeathCase()
        {
            
            for (int i = 0; i < _deathRules.Count; i ++)
            {
                for (int tableAge = (int)_deathRules[i][0]; tableAge < (int)_deathRules[i][1];
                    tableAge ++)
                {
                    if (_age == tableAge && _sex == "F" && 
                        ProbabilityCalculator.IsEventHappened((double)_deathRules[i][3]))
                    {
                        _isLiving = false;
                        _deathYear = _currentYear;
                    }
                    else if (_age == tableAge && _sex == "M" &&
                        ProbabilityCalculator.IsEventHappened((double)_deathRules[i][3]))
                    {
                        _isLiving = false;
                        _deathYear = _currentYear;
                    }
                }
            }
        }

        public delegate void Notification();
        public event Notification ChildBirth;
        public Person(string sex, int yearBirth, List<ArrayList> deathRules)
        {
            _sex = sex;
            _yearBirth = yearBirth;
            _deathRules = deathRules;
            _isLiving = true;
        }
       

        public void RenewYear(int year)
        {
            _currentYear = year;
            _age = year - _yearBirth;
            DeathCase();
            NewChild();

        }

        public string Sex => _sex;

        public int YearBirth => _yearBirth;

        public int Age => _age;

        public bool IsLiving => _isLiving;

        public int DeathYear => _deathYear;


    }
}
