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
        private const double probabilityBirthWomen = 0.55;
        private const double numOfGenders = 2;
        private const double adduction = 1000;
        private List<Person> people = new List<Person>();
        private List<int> _yearArr = new List<int>();
        private InitializeData init;
        private List<int> _mPopulation = new List<int>();
        private List<int> _wPopulation = new List<int>();
        private List<int> _population = new List<int>();
        private List<int> _mAgePopulation = new List<int>();
        private List<int> _wAgePopulation = new List<int>();

        

        public delegate void Notification(int year);
        public event Notification YearTick;
        public List<int> Years => _yearArr;

        public List<int> MPopulation => _mPopulation;

        public List<int> WPopulation => _wPopulation;

        public List<int> Population => _population;

        public List<List<int>> AgeGroups => init.AgeGroups;

        public List<int> MAgePopulation => _mAgePopulation;

        public List<int> WAgePopulation => _wAgePopulation;
        private void MakeBasis()
        {
            int prev = 0;
            foreach (ArrayList list in init.InitMatrix)
            {                
                for (int i = 0; i < init.Population * adduction; i++)
                {

                    if (ProbabilityCalculator.IsEventHappened(Convert.ToDouble(list[1]) / adduction / numOfGenders))
                    {
                        Person personM = new Person(SexClass.Sex.Male, init.BeginYear - Convert.ToInt32(list[0]), init.DeathMatrix);
                        Person personF = new Person(SexClass.Sex.Female, init.BeginYear - Convert.ToInt32(list[0]), init.DeathMatrix);
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
            if (ProbabilityCalculator.IsEventHappened(probabilityBirthWomen))
            {
                Person personF = new Person(SexClass.Sex.Female, _yearArr.Last(), init.DeathMatrix);
                YearTick += personF.RenewYear;
                personF.ChildBirth += NewPerson;
                people.Add(personF);
            }
            else
            {
                Person personM = new Person(SexClass.Sex.Male, _yearArr.Last(), init.DeathMatrix);
                YearTick += personM.RenewYear;
                people.Add(personM);
            }              
        }

        private void YearProgress(int currentYear)
        {
            _yearArr.Add(currentYear);
            int mPopulation = (from p in people where p.IsLiving && p.Sex == SexClass.Sex.Male select p).Count();
            int wPopulation = (from p in people where p.IsLiving && p.Sex == SexClass.Sex.Female select p).Count();
            int fullPopulation = mPopulation + wPopulation;
            _mPopulation.Add(mPopulation);
            _wPopulation.Add(wPopulation);
            _population.Add(fullPopulation);

            YearTick(currentYear);
            Console.WriteLine(mPopulation + " " + wPopulation);
        }

        private void CalculateFinalResults()
        {
            for (int i = 0; i < init.AgeGroups.Count; i++)
            {
                int mAgePopulation = (from p in people
                                      where 
                                      p.Age >= init.AgeGroups[i][0] &&
                                      p.Age <= init.AgeGroups[i][1] &&
                                      p.Sex == SexClass.Sex.Male &&
                                      p.IsLiving
                                      select p).Count();
                int wAgePopulation = (from p in people
                                      where 
                                      p.Age >= init.AgeGroups[i][0] &&
                                      p.Age <= init.AgeGroups[i][1] &&
                                      p.Sex == SexClass.Sex.Female &&
                                      p.IsLiving
                                      select p).Count();

                _mAgePopulation.Add(mAgePopulation);
                _wAgePopulation.Add(wAgePopulation);
            }
        }

        public void Modeling(string beginYear, string endYear, string population,
            List<ArrayList> initMatrix, List<ArrayList> deathMatrix)
        {
            init = new InitializeData();
            init.Initialize(beginYear, endYear, population, initMatrix, deathMatrix);
            MakeBasis();

            for (int currentYear = init.BeginYear; currentYear < init.EndYear; currentYear++)
            {
                YearProgress(currentYear);
            }
            CalculateFinalResults();
        }

        
    }
}
