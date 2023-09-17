using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw2
{
    public class Person
    {
        private string name;
        private string address;
        private double salary;

        public Person(string name, string address, double salary)
        {
            this.name = name;
            this.address = address;
            this.salary = salary;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        public double Salary
        {
            get { return salary; }
            set { salary = value; }
        }

        public static Person InputPersonInfo(string name, string address, string sSalary)
        {
            if (string.IsNullOrWhiteSpace(sSalary))
            {
                throw new Exception("Bạn phải nhập Mức lương.");
            }

            if (!double.TryParse(sSalary, out double salary))
            {
                throw new Exception("Bạn phải nhập một số hợp lệ cho Mức lương.");
            }

            if (salary < 0)
            {
                throw new Exception("Mức lương phải là số dương.");
            }

            return new Person(name, address, salary);
        }

        public static void DisplayPersonInfo(Person person)
        {
            Console.WriteLine($"Name: {person.Name}");
            Console.WriteLine($"Address: {person.Address}");
            Console.WriteLine($"Salary: {person.Salary}");
        }

        public static Person[] SortBySalary(Person[] people)
        {
            if (people == null)
            {
                throw new Exception("Không thể sắp xếp người");
            }

            int n = people.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (people[j].Salary > people[j + 1].Salary)
                    {
                        Person temp = people[j];
                        people[j] = people[j + 1];
                        people[j + 1] = temp;
                    }
                }
            }
            return people;
        }

        public static void Main(string[] args)
        {
            try
            {
                Person[] people = new Person[3];

                for (int i = 0; i < people.Length; i++)
                {
                    Console.WriteLine($"Nhập thông tin chi tiết về người { i + 1}");
                    Console.Write("Name: ");
                    string name = Console.ReadLine();
                    Console.Write("Address: ");
                    string address = Console.ReadLine();
                    Console.Write("Salary: ");
                    string salaryInput = Console.ReadLine();

                    people[i] = InputPersonInfo(name, address, salaryInput);
                }

                Console.WriteLine("Mọi người trước khi phân loại:");
                foreach (Person person in people)
                {
                    DisplayPersonInfo(person);
                }

                people = SortBySalary(people);

                Console.WriteLine("Mọi người sau khi sắp xếp theo mức lương:");
                foreach (Person person in people)
                {
                    DisplayPersonInfo(person);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Lỗi: " + e.Message);
            }
        }
    }
   











}
