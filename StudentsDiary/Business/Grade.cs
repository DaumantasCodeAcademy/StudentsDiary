using System;

namespace Business
{
    public class Grade
    {
        public int Value { get; }
        public string Lesson { get; }
        public DateTime CreatedAt { get; }

        public Grade(int grade, string lesson, DateTime createdAt)
        {
            if (grade < 1 || grade > 10)
            {
                throw new Exception("Grade can't be less than 1 or bigger than 10");
            }

            Value = grade;
            Lesson = lesson;
            CreatedAt = createdAt;
        }
    }
}
