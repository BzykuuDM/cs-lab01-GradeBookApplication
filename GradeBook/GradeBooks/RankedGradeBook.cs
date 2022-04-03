using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name, bool isWeighted) : base(name, isWeighted)
        {
            Type = Enums.GradeBookType.Ranked;
            IsWeighted = isWeighted;
        }
        public override char GetLetterGrade(double averageGrade)
        {
            var top20 = 0;
            
            if (Students.Count < 5)
            {
                throw new InvalidOperationException();
            }

            var indexes = Students.Select(t => t.AverageGrade).ToList();
            top20 = (int)Math.Ceiling(Students.Count * 0.2);

            if (indexes[top20] < averageGrade)
            {
                return 'A';
            }

            else if(indexes[top20*2] < averageGrade)
            {
                return 'B';
            }

            else if (indexes[top20 * 3] < averageGrade)
            {
                return 'C';
            }

            else if (indexes[top20 * 4] < averageGrade)
            {
                return 'D';
            }

            else
            {
                return 'F';
            }
            
        }

        public override void CalculateStudentStatistics(string name)
        {
            if(Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students.");
            }

            if(Students.Count >= 5)
            {
                base.CalculateStudentStatistics(name);
            }
        }

        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students.");
            }

            if (Students.Count >= 5)
            {
                base.CalculateStatistics();
            }
        }
    }
}
