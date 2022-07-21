using BootcampV1.Abstract;
using System;

namespace BootcampV1.Concrete
{
    public class Accountant : BaseEmployee
    {
        public string KnowingEncounterPrograms { get; set; }
        public Accountant(string Name, float Salary, int age, string Job) : base(Name, Salary, age, Job)
        {
        }

        public override void GetEmployeeInformation()
        {
            base.GetEmployeeInformation();
            if (KnowingEncounterPrograms is not null)
                Console.WriteLine($"The accounting programs {_Name} knows are {KnowingEncounterPrograms}.");
            Console.WriteLine(Environment.NewLine);
        }
    }
}
