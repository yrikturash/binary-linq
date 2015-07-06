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

            var categories = new List<Category>()
            {
                new Category() {Name = ".Net"},
                new Category() {Name = "JS"},
                new Category() {Name = "PHP"},
                new Category() {Name = "DB"},
                new Category() {Name = "OOP"},
                new Category() {Name = "English"},
            };
            var users = new List<User>()
            {
                new User()
                {
                    Name = "Mercedes Sutton",
                    Univercity = "KPI",
                    Year = "1993",
                    City = "Kyiv",
                    Category = categories.ElementAt(0)
                },
                new User()
                {
                    Name = "Bradley	Harvey",
                    Univercity = "KPI",
                    Year = "1993",
                    City = "Lviv",
                    Category = categories.ElementAt(1)
                },
                new User()
                {
                    Name = "Roman Cobb",
                    Univercity = "KPI",
                    Year = "1993",
                    City = "Lviv",
                    Category = categories.ElementAt(2)
                },
                new User()
                {
                    Name = "Jack Stanley",
                    Univercity = "KPI",
                    Year = "1993",
                    City = "Lviv",
                    Category = categories.ElementAt(3)
                },
                new User()
                {
                    Name = "Stuart Freeman",
                    Univercity = "KPI",
                    Year = "1993",
                    City = "Kyiv",
                    Category = categories.ElementAt(4)
                },
                new User()
                {
                    Name = "Kim	Bowman",
                    Univercity = "KPI",
                    Year = "1993",
                    City = "Kyiv",
                    Category = categories.ElementAt(5)
                },
            };
            var questions = new List<Question>()
            {
                new Question()
                {
                    Text = "ddfref",
                    Category = categories.ElementAt(5)
                },
                new Question()
                {
                    Text = "ddfref",
                    Category = categories.ElementAt(5)
                },
                new Question()
                {
                    Text = "ddfref",
                    Category = categories.ElementAt(0)
                },
                new Question()
                {
                    Text = "ddfref",
                    Category = categories.ElementAt(0)
                },
                new Question()
                {
                    Text = "ddfref",
                    Category = categories.ElementAt(0)
                },
            };
            var tests = new List<Test>()
            {
                new Test()
                {
                    Name = "English Test",
                    Category = categories.ElementAt(5),
                    Questions = questions.Where(n => n.Category.Name == "English").ToList(),
                    MaxPassTime = 30,
                    PassMark = 60
                },
                new Test()
                {
                    Name = ".Net Test",
                    Category = categories.ElementAt(0),
                    Questions = questions.Where(n => n.Category.Name == ".Net").ToList(),
                    MaxPassTime = 25,
                    PassMark = 70
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
                    PassTime = 32
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
                new TestWork()
                {
                    User = users.ElementAt(2),
                    Test = tests.Single(n => n.Name == ".Net Test"),
                    Result = 40,
                    PassTime = 32
                },
                new TestWork()
                {
                    User = users.ElementAt(3),
                    Test = tests.Single(n => n.Name == ".Net Test"),
                    Result = 55,
                    PassTime = 26
                },
                new TestWork()
                {
                    User = users.ElementAt(4),
                    Test = tests.Single(n => n.Name == ".Net Test"),
                    Result = 25,
                    PassTime = 32
                },
                new TestWork()
                {
                    User = users.ElementAt(5),
                    Test = tests.Single(n => n.Name == ".Net Test"),
                    Result = 92,
                    PassTime = 29
                }
            };
#endregion

            var passedUsers = users.SelectMany(c => testWorks, (c, o) => new {c, o})
                .Where(t => t.o.User.Name == t.c.Name && t.o.Result >= tests.First(n => n.Name == t.o.Test.Name).PassMark)
                .Select(t => new
                {
                    User = t.o.User,
                    Result = t.o.Result
                }).ToList();

            var passedInTimeUsers = users.SelectMany(c => testWorks, (c, o) => new {c, o})
                .Where(t => t.o.User.Name == t.c.Name && t.o.Result >= tests.First(n => n.Name == t.o.Test.Name).PassMark && t.o.PassTime <= tests.First(n => n.Name == t.o.Test.Name).MaxPassTime)
                .Select(t => new
                {
                    User = t.o.User,
                    Result = t.o.Result
                }).ToList();

            var passedOutTimeUsers = users.SelectMany(c => testWorks, (c, o) => new {c, o})
                .Where(t => t.o.User.Name == t.c.Name && t.o.Result >= tests.First(n => n.Name == t.o.Test.Name).PassMark && t.o.PassTime > tests.First(n => n.Name == t.o.Test.Name).MaxPassTime)
                .Select(t => new
                {
                    User = t.o.User,
                    Result = t.o.Result
                }).ToList();

            var usersByCity =
                users.GroupBy(n => n.City)
                    .Select(n => new {City = n.Key, Users = n.Where(m => m.City == n.Key).ToList()})
                    .ToList();


            var passedUsersByCity = users.SelectMany(c => testWorks, (c, o) => new {c, o})
                .Where(
                    t => t.o.User.Name == t.c.Name && t.o.Result >= tests.First(n => n.Name == t.o.Test.Name).PassMark)
                .GroupBy(n => n.c.City, n => n.c.Name, (key, g) => new
                {
                    City = key,
                    Users = g.ToList()
                }).ToList();


            var resultsForUsers =
                testWorks.Select(
                    n =>
                        new
                        {
                            User = n.User.Name,
                            Result = n.Result,
                            Time = n.PassTime,
                            Category = n.Test.Category.Name,
                            PassPercent = (float) (n.Result)/n.Test.PassMark*100
                        })
                    .GroupBy(n => n.User,
                        (m, k) =>
                            new
                            {
                                User = m,
                                Results =
                                    k.Select(
                                        n =>
                                            new
                                            {
                                                n.Category,
                                                n.Time,
                                                n.Result,
                                                n.PassPercent
                                            }).ToList()
                            })
                    .ToList();
        }
    }
}
