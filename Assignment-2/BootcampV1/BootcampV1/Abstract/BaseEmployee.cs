using System;

namespace BootcampV1.Abstract
{
    public abstract class BaseEmployee
    {
        protected string _Name { get; set; }
        private float _Salary { get; set; }
        protected int _Age { get; set; }
        protected string _Job { get; set; }
        private bool ishasraise { get; set; } = false;
        public BaseEmployee(string Name, float Salary, int age, string job)
        {
            _Salary = Salary;
            _Name = Name;
            _Age = age;
            _Job = job;
        }
        public virtual void salary_raise(int raise_rate)
        {
            ishasraise = true;
            _Salary = _Salary + (_Salary * raise_rate / 100);
        }

        public virtual void GetEmployeeInformation()
        {
            if (_Age > 0)
                Console.WriteLine($"{_Name} is {_Age} years old.");
            if (!ishasraise)
                Console.WriteLine($"{_Name}'s salary is {_Salary}.");
            else
                Console.WriteLine($"{_Name}'s increased salary is {_Salary}.");
        }
    }
}
