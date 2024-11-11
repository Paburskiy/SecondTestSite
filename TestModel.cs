// Models/TestModel.cs
using System.Collections.Generic;

namespace YourNamespace.Models
{
    public class TestModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public List<QuestionModel> Questions { get; set; } = new List<QuestionModel>();
    }

    public class QuestionModel
    {
        public string Question { get; set; }
        public List<string> Answers { get; set; }
        public int CorrectAnswer { get; set; }
    }
}
