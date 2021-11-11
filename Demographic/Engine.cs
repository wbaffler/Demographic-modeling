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
        private List<Person> people = new List<Person>();
        private List<int> _yearArr = new List<int>();
        private InitializeData init;
        private List<int> _mPopulation = new List<int>();
        private List<int> _wPopulation = new List<int>();
        private List<int> _population = new List<int>();
        private List<int> _mAgePopulation = new List<int>();
        private List<int> _wAgePopulation = new List<int>();

        private void MakeBasis()
        {
            int prev = 0;
            foreach (ArrayList list in init.InitMatrix)
            {
                
                for (int i = 0; i < init.Population * 1000; i++)
                {

                    if (ProbabilityCalculator.IsEventHappened(Convert.ToDouble(list[1]) / 1000 / 2))
                    {
                        Person personM = new Person("M", init.BeginYear - Convert.ToInt32(list[0]), init.DeathMatrix);
                        Person personF = new Person("F", init.BeginYear - Convert.ToInt32(list[0]), init.DeathMatrix);
                        YearTick += personM.RenewYear;
                        YearTick += personF.RenewYear;
                        personF.ChildBirth += NewPerson;
                        people.Add(personM);
                        people.Add(personF);
                    }
                }
                Console.WriteLine(people.Count - prev);
                prev = people.Count;
            }
            Console.WriteLine(people.Count);
        }
        private void NewPerson()
        {
            if (ProbabilityCalculator.IsEventHappened(0.55))
            {
                Person personF = new Person("F", _yearArr.Last(), init.DeathMatrix);
                YearTick += personF.RenewYear;
                personF.ChildBirth += NewPerson;
                people.Add(personF);
            }
            else
            {
                Person personM = new Person("M", _yearArr.Last(), init.DeathMatrix);
                YearTick += personM.RenewYear;
                people.Add(personM);
            }              
        }

        public delegate void Notification(int year);
        public event Notification YearTick;
        public List<int> Years => _yearArr;

        public List<int> MPopulation => _mPopulation;

        public List<int> WPopulation => _wPopulation;

        public List<int> Population => _population;

        public List<List<int>> AgeGroups => init.AgeGroups;

        public List<int> MAgePopulation => _mAgePopulation;

        public List<int> WAgePopulation => _wAgePopulation;



        public void Modeling(string beginYear, string endYear, string population,
            List<ArrayList> initMatrix, List<ArrayList> deathMatrix)
        {
            init = new InitializeData();
            init.Initialize(beginYear, endYear, population, initMatrix, deathMatrix);
            MakeBasis();

            for (int currentYear = init.BeginYear; currentYear < init.EndYear; currentYear++)
            {
                _yearArr.Add(currentYear);
                int mPopulation = (from p in people where p.IsLiving && p.Sex == "M" select p).Count();
                int wPopulation = (from p in people where p.IsLiving && p.Sex == "F" select p).Count();
                int fullPopulation = mPopulation + wPopulation;
                _mPopulation.Add(mPopulation);
                _wPopulation.Add(wPopulation);
                _population.Add(fullPopulation);

                YearTick(currentYear);
         
                
                Console.WriteLine(mPopulation + " " + wPopulation);
            }
            
            for (int i = 0; i < init.AgeGroups.Count; i++)
            {
                int mAgePopulation = (from p in people 
                                      where p.Age >= init.AgeGroups[i][0] &&
                                      p.Age <= init.AgeGroups[i][1] && 
                                      p.Sex == "M" select p).Count();
                int wAgePopulation = (from p in people
                                      where p.Age >= init.AgeGroups[i][0] &&
                                      p.Age <= init.AgeGroups[i][1] &&
                                      p.Sex == "F"
                                      select p).Count();

                _mAgePopulation.Add(mAgePopulation);
                _wAgePopulation.Add(wAgePopulation);
            }
        }

        
    }
}
