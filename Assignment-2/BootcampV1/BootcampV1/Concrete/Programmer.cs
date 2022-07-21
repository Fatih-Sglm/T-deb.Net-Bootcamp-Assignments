using BootcampV1.Abstract;
using System;

namespace BootcampV1.Concrete
{
    public class Programmer : BaseEmployee
    {
        public string Know_Programming_languages { get; set; }
        public Programmer(string Name, float Salary, int Age, string Job) : base(Name, Salary, Age, Job)
        {

        }

        public override void salary_raise(int raise_rate)
        {
            base.salary_raise(raise_rate);
        }
        public override void GetEmployeeInformation()
        {
            base.GetEmployeeInformation();
            Console.WriteLine($"{_Name} is a {_Job}.");
            if (Know_Programming_languages is not null)
                Console.WriteLine($"The programming languages {_Name} knows are {Know_Programming_languages}.");
            Console.WriteLine(Environment.NewLine);
        }
    }
}
