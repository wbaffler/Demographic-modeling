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
        private List<int> yearArr = new List<int>();
        private InitializeData init;

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
                Person personF = new Person("F", yearArr.Last(), init.DeathMatrix);
                YearTick += personF.RenewYear;
                personF.ChildBirth += NewPerson;
                people.Add(personF);
            }
            else
            {
                Person personM = new Person("M", yearArr.Last(), init.DeathMatrix);
                YearTick += personM.RenewYear;
                people.Add(personM);
            }              
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


        

        public void Modeling(string beginYear, string endYear, string population,
            List<ArrayList> initMatrix, List<ArrayList> deathMatrix)
        {
            init = new InitializeData();
            init.Initialize(beginYear, endYear, population, initMatrix, deathMatrix);
            MakeBasis();
            for (int currentYear = init.BeginYear; currentYear < init.EndYear; currentYear++)
            {
                yearArr.Add(currentYear);
                int number = (from p in people where p.Age == 91 select p).Count();
                YearTick(currentYear);
                //Console.WriteLine("All people: " + people.Count);
         
                
                Console.WriteLine(number);
                //var b = (from p in people where p.IsLiving select p).All
                //Console.WriteLine();

            }
        }

        
    }
}
