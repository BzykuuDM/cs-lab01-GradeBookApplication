using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = Enums.GradeBookType.Ranked;
        }
        public override char GetLetterGrade(double averageGrade)
        {
            var top20 = 0;
            
            if (Students.Count < 5)
            {
                throw new InvalidOperationException();
            }

            //top20 = Student.AverageGrade * 0.2;
            var indexes = Students.Select(t => t.AverageGrade).ToList();
            top20 = (int)Math.Ceiling(Students.Count * 0.2);

            if (indexes[top20] < averageGrade)
            {
                return 'A';
            }

            if(indexes[top20*2] < averageGrade)
            {
                return 'B';
            }

            if (indexes[top20 * 3] < averageGrade)
            {
                return 'C';
            }

            if (indexes[top20 * 4] < averageGrade)
            {
                return 'D';
            }

            if (indexes[top20 * 5] < averageGrade)
            {
                return 'F';
            }


            return base.GetLetterGrade(averageGrade);
        }
    }
}
