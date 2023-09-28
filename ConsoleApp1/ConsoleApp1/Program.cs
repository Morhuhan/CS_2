using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    enum emp_type : byte 
    {
        mangaer = 10, 
        grunt = 1, 
        contractor = 100, 
        VP = 9    
    }

    struct sEmployee
    {
        public emp_type title;
        public string name;
        public short deptID;

        // Структура в C# может иметь конструктор, но только с параметрами
        public sEmployee(emp_type et, string n, byte d)
        {
            title = et;
            name = n;
            deptID = d;
        }
    }

    class Employee
    {
        protected string fullName;
        protected short empID;
        protected double currPay;

        public Employee() { }

        public Employee(string fullName, short empID, double currPay)
        {
            this.fullName = fullName;
            this.empID = empID;
            this.currPay = currPay;
        }

        public void GiveBonus (double amount)
        {
            currPay += amount;
        }

        public virtual void DisplayStats()
        {
            Console.WriteLine("\nИмя: {0}", fullName);
            Console.WriteLine("Зарплата: {0}", currPay);
            Console.WriteLine("ID: {0}", empID);
        }

        public string Name
        {
            get
            {
                return fullName;
            }

            set
            {
                fullName = value;
            }
        }

    }

    class Manager : Employee
    {
        private ulong numberOfOptuins;

        public Manager() { } 

        public Manager(short empID)
        {
            this.empID = empID;
        }

        // Конструктор с использованием base
        public Manager(string name, short ID, double pay, ulong p) :
            //  передает параметры name, ID и pay в конструктор базового класса. 
            base(name, ID, pay)
        {
            numberOfOptuins = p;
        }

        // Переопределение виртуального метода базового класса
        public override void DisplayStats()
        {
            base.DisplayStats();
            Console.WriteLine("Опционов: {0}", numberOfOptuins);
        }

        public ulong OptionsNumber
        {
            get 
            {
                return numberOfOptuins;
            }
            set
            {
                numberOfOptuins = value;
            }
        }
    }



    internal class Program
    {   
        void DeisplayEmployeeStats (sEmployee e)
        {
            Console.WriteLine("{0}: отедел {1}, тип {2}",
                e.name, 
                e.deptID,
                // Выполняет форматирование значения перечисления в строку
                Enum.Format(typeof(emp_type), e.title, "G") + ".");
        }

        // Преобразование ссылочного типа в структурный
        void UnboxsEmployee(object o)
        {
            sEmployee e = (sEmployee)o;
            DeisplayEmployeeStats(e);
        }

        static void Main(string[] args)
        {
            //Program t = new Program();
            //sEmployee bill = new sEmployee(emp_type.VP, "Bill", 10);
            //t.DeisplayEmployeeStats(bill);

            //// Преобразование структурного типа в ссылочный (Упаковка)
            //object bill_inbox = bill;

            //// Распаковку можно сделать так:
            //t.UnboxsEmployee(bill_inbox);

            //// Или компилятор сделает упаковку автоматически
            //t.UnboxsEmployee(bill);

            ////////////////////////////////

            //// Определяем двух сотрудников
            //Employee e = new Employee("Bill", 100, 30000.0);
            //e.GiveBonus(500);
            //e.DisplayStats();

            //Employee e2 = new Employee("Mary", 101, 36000.0);
            //e2.GiveBonus(1000);
            //e2.DisplayStats();

            //e2.Name = "Ann";
            //e2.DisplayStats();

            ////////////////////////////////
            
            Manager m = new Manager(102);
            m.Name = "John";
            //((Employee)m).DisplayStats();

            Manager m2 = new Manager("Sam", 103, 40000.0, 20);
            //((Employee)m2).DisplayStats();

            m.DisplayStats();
            m2.DisplayStats();

        }

    }
}
