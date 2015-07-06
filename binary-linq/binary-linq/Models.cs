using System.Collections.Generic;

namespace binary_linq
{
    public class User
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Year { get; set; }
        public string City { get; set; }
        public string Univercity { get; set; }
        public Category Category { get; set; }
    }
    public class Test
    {
        public string Name { get; set; }
        public Category Category { get; set; }
        public List<Question> Questions { get; set; }
        public int MaxPassTime { get; set; }
        public int PassMark { get; set; }
    }
    public class Question
    {
        public string Text { get; set; }
        public Category Category { get; set; }
    }
    public class TestWork
    {
        public Test Test { get; set; }
        public User User { get; set; }
        public int Result { get; set; }
        public int PassTime { get; set; }
    }
    public class Category
    {
        public string Name { get; set; }
    }

}