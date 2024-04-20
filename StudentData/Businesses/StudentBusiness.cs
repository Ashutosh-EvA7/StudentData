using StudentData.Models;

public class StudentBusiness
{
    private static List<Student> _students = new List<Student>
    {
        new Student
            {
                StudentId = 1,
                StudentName = "Prajyot",
                Class = 10,
                Marksheets = new List<Marksheet>
                {
                    new Marksheet { MarkSheetId = 1, Subject = "Math", TotalMark = 100, MarksObtained = 90 },
                    new Marksheet { MarkSheetId = 2, Subject = "Science", TotalMark = 100, MarksObtained = 85 },
                    new Marksheet { MarkSheetId = 3, Subject = "English", TotalMark = 100, MarksObtained = 95 }
                }
            },
            new Student
            {
                StudentId = 2,
                StudentName = "Rajat",
                Class = 10,
                Marksheets = new List<Marksheet>
                {
                    new Marksheet { MarkSheetId = 4, Subject = "Math", TotalMark = 100, MarksObtained = 85 },
                    new Marksheet { MarkSheetId = 5, Subject = "Science", TotalMark = 100, MarksObtained = 90 },
                    new Marksheet { MarkSheetId = 6, Subject = "English", TotalMark = 100, MarksObtained = 80 }
                }
            },
            new Student
            {
                StudentId = 3,
                StudentName = "Manas",
                Class = 10,
                Marksheets = new List<Marksheet>
                {
                    new Marksheet { MarkSheetId = 7, Subject = "Math", TotalMark = 100, MarksObtained = 80 },
                    new Marksheet { MarkSheetId = 8, Subject = "Science", TotalMark = 100, MarksObtained = 75 },
                    new Marksheet { MarkSheetId = 9, Subject = "English", TotalMark = 100, MarksObtained = 90 }
                }
            },
            new Student
            {
                StudentId = 4,
                StudentName = "Rakesh",
                Class = 11,
                Marksheets = new List<Marksheet>
                {
                    new Marksheet { MarkSheetId = 10, Subject = "Math", TotalMark = 100, MarksObtained = 75 },
                    new Marksheet { MarkSheetId = 11, Subject = "Science", TotalMark = 100, MarksObtained = 80 },
                    new Marksheet { MarkSheetId = 12, Subject = "English", TotalMark = 100, MarksObtained = 85 }
                }
            },
            new Student
            {
                StudentId = 5,
              StudentName = "Salony",
                Class = 11,
                Marksheets = new List<Marksheet>
                {
                    new Marksheet { MarkSheetId = 13, Subject = "Math", TotalMark = 100, MarksObtained = 90 },
                    new Marksheet { MarkSheetId = 14, Subject = "Science", TotalMark = 100, MarksObtained = 90 },
                    new Marksheet { MarkSheetId = 15, Subject = "English", TotalMark = 100, MarksObtained = 90 }
                }
            }
    };

    public int GetTotalMarkObtained(int studentId)
    {
        return _students.FirstOrDefault(s => s.StudentId == studentId)?.TotalMarkObtained ?? 0;
    }

    public double GetTotalPercentageObtained(int studentId)
    {
        return _students.FirstOrDefault(s => s.StudentId == studentId)?.TotalPercentageObtained ?? 0;
    }

    public List<Marksheet> GetAllMarksById(int studentId)
    {
        return _students.FirstOrDefault(s => s.StudentId == studentId)?.Marksheets ?? [];
    }

    public void AddMarks(Marksheet marksheet)
    {
        var student = _students.FirstOrDefault(s => s.StudentId == marksheet.StudentId);
        if (student != null)
        {
            student.Marksheets.Add(marksheet);
        }
    }

    public void UpdateMarks(Marksheet marksheet)
    {
        var student = _students.FirstOrDefault(s => s.StudentId == marksheet.StudentId);
        if (student != null)
        {
            var existingMarksheet = student.Marksheets.FirstOrDefault(m => m.Subject == marksheet.Subject);
            if (existingMarksheet != null)
            {
                existingMarksheet.MarksObtained = marksheet.MarksObtained;
            }
        }
    }

    public List<Student> GetStudentList()
    {
        return _students;
    }

    public List<Student> GetTopThree(int @class)
    {
        return _students.Where(s => s.Class == @class).OrderByDescending(s => s.TotalMarkObtained).Take(3).ToList();
    }
}