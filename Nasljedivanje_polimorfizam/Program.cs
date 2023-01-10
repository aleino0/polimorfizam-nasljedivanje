using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Nasljedivanje_polimorfizam
{
    class Dessert
    {
        private string name;
        private double weight;
        private int calories;

        public string Name { get => name; set => name = value; }
        public double Weight { get => weight; set => weight = value; }
        public int Calories { get => calories; set => calories = value; }

        public Dessert(string name, double weight, int calories)
        {
            this.name = name;
            this.weight = weight;
            this.calories = calories;
        }

        public override string ToString()
        {
            return "ime kolaca: {0} \r\ntežinea: {1}\r\nkalorije: {2}" + name + weight + calories;
        }
        public string getDessertType()
        {
            return "dessert";
        }
    }

    class Cake : Dessert
    {
        Boolean containsGluten;
        string cakeType;

        public Boolean ContainsGluten { get => containsGluten; set => containsGluten = value; }
        public string CakeType { get => cakeType; set => cakeType = value; }

        public Cake(string name, double weight, int calories, Boolean containsGluten, string cakeType) : base(name, weight, calories) { }

        public string ToString(string name, double weight, int calories)
        {
            return "ime kolaca: {0} \r\ntežinea: {1}\r\nkalorije: {2} \nGluten: {3} \nvrsta: {4}" + name + weight + calories + containsGluten + cakeType;
        }

        public string getDessertType()
        {
            return cakeType + "cake";
        }
    }

    class IceCream : Dessert
    {
        string flavour;
        string color;

        public string Flavour { get => flavour; set => flavour = value; }
        public string Color { get => color; set => color = value; }

        public IceCream(string flavour, string color, string name, double weight, int calories) : base(name, weight, calories) { }

        public string ToString(string name, double weight, int calories)
        {
            return "ime kolaca: {0} \ntežinea: {1} \nkalorije: {2} \nokus: {3} \nboja: {4}" + name + weight + calories + flavour + color;
        }

        public string getDessertType()
        {
            return "ice cream";
        }
    }

    class Person
    {
        string name;
        string surname;
        int age;

        public string Name { get => name; set => name = value; }
        public string Surname { get => surname; set => surname = value; }
        public int Age { get => age; set => age = value; }

        public Person(string name, string surname, int age)
        {
            this.name = name;
            this.surname = surname;
            this.age = age;
        }

        public string ToString(string name, string surname, int age)
        {
            return "Ime: {0} \nPrezime: {1} \nGodine: {3}" + name + surname + age;
        }

        public override bool Equals(object obj)
        {
            return obj is Person person &&
                   Name == person.Name &&
                   Surname == person.Surname &&
                   Age == person.Age;
        }
    }

    class Student : Person
    {
        string studentId;
        short academicYear;

        public string StudentId { get => studentId; set => studentId = value; }
        public short AcademicYear { get => academicYear; set => academicYear = value; }

        public Student(string name, string surname, int age, string studentId, short academicYear) : base(name, surname, age)
        {
            this.studentId = studentId;
            this.academicYear = academicYear;
        }

        public override string ToString()
        {
            string ispis = ("ID ucenika: " + this.studentId + "\nGodina skolovanja: " + this.academicYear);
            return ispis;
        }

        public override bool Equals(object obj)
        {
            return obj is Student student &&
                base.Equals(obj) &&
                   StudentId == student.StudentId;
        }
    }

    class Teacher : Person
    {
        string email;
        string subject;
        double salary;

        public string Email { get => email; set => email = value; }
        public string Subject { get => subject; set => subject = value; }
        public double Salary { get => salary; set => salary = value; }

        public Teacher(string email, string subject, double salary, string name, string surname, int age) : base(name, surname, age)
        {
            this.email = email;
            this.subject = subject;
            this.salary = salary;
        }

        public override string ToString()
        {
            string ispis = ("E-mail: " + this.email + "\nPredmet: " + this.subject + "\nPlaca: " + this.salary);
            return ispis;
        }

        public override bool Equals(object obj)
        {
            return obj is Teacher teacher &&
                base.Equals(obj) &&
                   Email == teacher.Email;
        }

        public void increaseSalary(int posto)
        {
            this.salary += (this.salary * (posto / 100));
        }
        public static void increaseSalary(int posto, Teacher teacher)
        {
            teacher.salary += (teacher.salary * (posto / 100));
        }
    }

    class CompetitionEntry
    {
        Teacher uciteljPrep;
        Dessert kolac;
        Student[] ziri;
        int[] bodovi;

        internal Teacher UciteljPrep { get => uciteljPrep; set => uciteljPrep = value; }
        internal Dessert Kolac { get => kolac; set => kolac = value; }
        internal Student[] Ziri { get => ziri; set => ziri = value; }
        public int[] Bodovi { get => bodovi; set => bodovi = value; }

        public CompetitionEntry(Teacher uciteljPrep, Dessert kolac)
        {
            UciteljPrep=uciteljPrep;
            Kolac = kolac;
        }

        public bool addRating(Student ucenik1, int ocjena)
        {
            bool check = false;
            if (Bodovi[0] != 0)
            {
                ziri[0] = ucenik1;
                bodovi[0] = ocjena;
                check = true;
            }
            else if (Bodovi[1] != 0 && Bodovi[0] != ocjena)
            {
                ziri[1] = ucenik1;
                bodovi[1] = ocjena;
                check = true;
            }
            if (bodovi[2] != 0 && ziri[0] != ucenik1 && ziri[1] != ucenik1)
            {
                ziri[2] = ucenik1;
                bodovi[2] = ocjena;
                check = true;
            }
            return check;
        }

        public double getRating()
        {
            double temp=0;
            double zavrsno=0;

            for (int i = 0; i < 3; i++)
            {
                if (Bodovi[i] != 0)
                {
                    temp++;
                    zavrsno += Bodovi[i];
                }
            }
            return zavrsno / temp;
        }
    }
    class UniMasterChef
    {
        CompetitionEntry[] natjecanje;
        internal CompetitionEntry[] Natjecanje { get => natjecanje; set => natjecanje = value; }

        public void addEntry(CompetitionEntry natj)
        {
            Natjecanje[0] = natj;
        }
        public string getBestDessert()
        {
            string best = Natjecanje[0].Kolac.Name;
            int scr = (int)natjecanje[0].getRating();
            for (int i = 1; i <= Natjecanje.Length - 1; i++)
            {
                if (natjecanje[i].getRating() >= scr)
                {
                    best = natjecanje[i].Kolac.Name;
                    scr = (int)natjecanje[i].getRating();
                }
            }
            return best;
        }
        public static Person[] getInvolvedPeople(CompetitionEntry co)
        {
            Person[] st = { };
            st[0] = co.UciteljPrep;
            for (int i = 1; i <= co.Ziri.Length + 1; i++)
            {
                st[i] = co.Ziri[i];
            }
            return st;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Dessert genericDessert = new Dessert("Chocolate Mousse", 120, 300);
            Cake cake = new Cake("Raspberry chocolate cake #3", 350.5, 400, false, "birthday");
            Teacher t1 = new Teacher("Dario", "Tušek", 42, "dario.tusek@fer.hr", "OOP", 10000);
            Teacher t2 = new Teacher("Doris", "Bezmalinović", 43, "doris.bezmalinovic@fer.hr", "OOP", 10000);
            Student s1 = new Student("Janko", "Horvat", 18, "0036312123", (short)1);
            Student s2 = new Student("Ana", "Kovač", 19, "0036387656", (short)2);
            Student s3 = new Student("Ivana", "Stanić", 19, "0036392357", (short)1);
            UniMasterChef competition = new UniMasterChef();
            CompetitionEntry e1 = new CompetitionEntry(t1, genericDessert);
            competition.addEntry(e1);
            Console.WriteLine("Entry 1 rating: " + e1.getRating());
            e1.addRating(s1, 4);
            e1.addRating(s2, 5);
            Console.WriteLine("Entry 1 rating: " + e1.getRating());
            CompetitionEntry e2 = new CompetitionEntry(t2, cake);
            e2.addRating(s1, 4);
            e2.addRating(s3, 5);
            e2.addRating(s2, 5);
            competition.addEntry(e2);
            Console.WriteLine("Entry 2 rating: " + e2.getRating());
            Console.WriteLine("Best dessert is: " + competition.getBestDessert());
            Person[] e2persons = UniMasterChef.getInvolvedPeople(e2);

            for (int i = 0; i <= e2persons.Length - 1; i++)
            {
                Console.WriteLine(e2persons[i].ToString());
            }

            Console.ReadKey();
        }
    }
}
