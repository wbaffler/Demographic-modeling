using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Demographic
{
    public class Person : IPerson
    {
        private const int maxAge = 100;
        private const double probabilityOfChild = 0.151;
        private List<int> giveBirthAge = new List<int>() { 18, 45 };
        //private string _sex;
        private int _yearBirth;
        private int _age;
        private List<ArrayList> _deathRules;
        private int _deathYear;
        private bool _isLiving;
        private int _currentYear;
        private SexClass.Sex _sex;
        private int Male = 0;

        public delegate void Notification();
        public event Notification ChildBirth;
        public SexClass.Sex Sex => _sex;

        public int YearBirth => _yearBirth;

        public int Age => _age;

        public bool IsLiving => _isLiving;

        public int DeathYear => _deathYear;
        public Person(SexClass.Sex sex, int yearBirth, List<ArrayList> deathRules)
        {
            _sex = sex;
            _yearBirth = yearBirth;
            _deathRules = deathRules;
            _isLiving = true;
            
        }


        private void NewChild()
        {
            if (_sex == SexClass.Sex.Female && _age >= giveBirthAge[0] && _age <= giveBirthAge[1])
                if (ProbabilityCalculator.IsEventHappened(probabilityOfChild))
                    ChildBirth();
        }

        private void DeathCase()
        {
            
            for (int i = 0; i < _deathRules.Count; i ++)
            {
                if (_age >= (int)_deathRules[i][0] && _age <= (int)_deathRules[i][1])
                {
                    if (_sex == SexClass.Sex.Female && ProbabilityCalculator.IsEventHappened((double)_deathRules[i][3]))
                    {
                        _isLiving = false;
                        _deathYear = _currentYear;
                    }
                    else if (_sex == SexClass.Sex.Male && ProbabilityCalculator.IsEventHappened((double)_deathRules[i][2]))
                    {
                        _isLiving = false;
                        _deathYear = _currentYear;
                    }               
                }
            }
            if (_age > maxAge)
            {
                _isLiving = false;
                _deathYear = _currentYear;
            }
        }

        
        

        public void RenewYear(int year)
        {
            _currentYear = year;
            _age = year - _yearBirth;
            DeathCase();
            NewChild();

        }




    }
}
