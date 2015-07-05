using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace binary_linq
{
    class Program
    {
        static void Main(string[] args)
        {
            #region GenerateData
            var users = new List<User>()
            {
                new User()
                {
                    Name = "Mercedes Sutton",
                    Univercity = "KPI",
                    Year = "1993",
                    City = "Lviv",
                    Category = ".Net"
                },
                new User()
                {
                    Name = "Bradley	Harvey",
                    Univercity = "KPI",
                    Year = "1993",
                    City = "Lviv",
                    Category = "JS"
                },
                new User()
                {
                    Name = "Roman Cobb",
                    Univercity = "KPI",
                    Year = "1993",
                    City = "Lviv",
                    Category = "PHP"
                },
                new User()
                {
                    Name = "Jack Stanley",
                    Univercity = "KPI",
                    Year = "1993",
                    City = "Lviv",
                    Category = "DB"
                },
                new User()
                {
                    Name = "Stuart Freeman",
                    Univercity = "KPI",
                    Year = "1993",
                    City = "Lviv",
                    Category = "OOP"
                },
                new User()
                {
                    Name = "Kim	Bowman",
                    Univercity = "KPI",
                    Year = "1993",
                    City = "Lviv",
                    Category = "English"
                },
            };
            var questions = new List<Question>()
            {
                new Question()
                {
                    Text = "ddfref",
                    Category = "English"
                },
                new Question()
                {
                    Text = "ddfref",
                    Category = "English"
                },
                new Question()
                {
                    Text = "ddfref",
                    Category = ".Net"
                },
                new Question()
                {
                    Text = "ddfref",
                    Category = ".Net"
                },
                new Question()
                {
                    Text = "ddfref",
                    Category = ".Net"
                },
            };
            var tests = new List<Test>()
            {
                new Test()
                {
                    Name = "English Test",
                    Category = "English",
                    Questions = questions.Where(n => n.Category == "English").ToList(),
                    MaxPassTime = 30,
                    PassMark = 60
                },
                new Test()
                {
                    Name = ".Net Test",
                    Category = ".Net",
                    Questions = questions.Where(n => n.Category == ".Net").ToList(),
                    MaxPassTime = 25,
                    PassMark = 65
                }
            };
            var testWorks = new List<TestWork>()
            {
                new TestWork()
                {
                    User = users.ElementAt(0),
                    Test = tests.Single(n => n.Name == "English Test"),
                    Result = 80,
                    PassTime = 29
                },
                new TestWork()
                {
                    User = users.ElementAt(1),
                    Test = tests.Single(n => n.Name == "English Test"),
                    Result = 88,
                    PassTime = 25
                },
                new TestWork()
                {
                    User = users.ElementAt(2),
                    Test = tests.Single(n => n.Name == "English Test"),
                    Result = 95,
                    PassTime = 30
                },
                new TestWork()
                {
                    User = users.ElementAt(3),
                    Test = tests.Single(n => n.Name == "English Test"),
                    Result = 98,
                    PassTime = 25
                },
                new TestWork()
                {
                    User = users.ElementAt(4),
                    Test = tests.Single(n => n.Name == "English Test"),
                    Result = 56,
                    PassTime = 26
                },
                new TestWork()
                {
                    User = users.ElementAt(5),
                    Test = tests.Single(n => n.Name == "English Test"),
                    Result = 44,
                    PassTime = 13
                },
            };
#endregion


        }
    }
}
