using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Demographic
{
    public class Engine : IEngine
    {
        private int _beginYear;
        private int _endYear;
        private int _population;
        List<ArrayList> _initMatrix;
        List<ArrayList> _deathMatrix;
        private List<Person> people = new List<Person>();
        private List<int> yearArr = new List<int>();
        private void NewPerson()
        {
            if (ProbabilityCalculator.IsEventHappened(0.55))
            {
                Person personF = new Person("F", yearArr.Last());
                YearTick += personF.RenewYear;
                personF.ChildBirth += NewPerson;
                people.Add(personF);
            }
            else
            {
                Person personM = new Person("M", yearArr.Last());
                YearTick += personM.RenewYear;
                people.Add(personM);
            }              
        }

        public Engine()
        {
            
        }

        public delegate void Notification(int year);
        public event Notification YearTick;
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
                
                foreach (ArrayList list in _initMatrix)
                {
                    int k = 0;
                    for (int i = 0; i < _population * 1000; i++)
                    {
                        
                        if (ProbabilityCalculator.IsEventHappened(Convert.ToDouble(list[1]) / 1000 / 2))
                        {
                            Person personM = new Person("M", _beginYear - Convert.ToInt32(list[0]));
                            Person personF = new Person("F", _beginYear - Convert.ToInt32(list[0]));
                            YearTick += personM.RenewYear;
                            YearTick += personF.RenewYear;
                            personF.ChildBirth += NewPerson;
                            people.Add(personM);
                            people.Add(personF);
                            k++;
                        }                        
                    }
                    Console.WriteLine(k);
                }
                Console.WriteLine(people.Count);
            }

            
            
        }

        public void Modeling()
        {
            for (int currentYear = _beginYear; currentYear < _endYear; currentYear++)
            {
                yearArr.Add(currentYear);
                YearTick(currentYear);
                Console.WriteLine(people.Count);


            }
        }

        
    }
}
