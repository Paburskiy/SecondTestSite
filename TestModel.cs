// Models/TestModel.cs
using System.Collections.Generic;

namespace YourNamespace.Models
{
    public class TestModel
    {
        public string Id { get; set; }          // Идентификатор теста
        public string Name { get; set; }        // Название теста
        public List<QuestionModel> Questions { get; set; } = new List<QuestionModel>();
    }

    public class QuestionModel
    {
        public string Question { get; set; }           // Текст вопроса
        public List<string> Answers { get; set; }      // Варианты ответов
        public int CorrectAnswer { get; set; }         // Индекс правильного ответа
    }
}