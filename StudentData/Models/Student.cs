namespace StudentData.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string? StudentName { get; set; }
        public DateTime StudentJoinDate { get; set; }
        public int Class { get; set; }
        public List<Marksheet> Marksheets { get; set; }

        public int TotalMarkObtained
        {
            get
            {
                return Marksheets.Sum(m => m.MarksObtained);
            }
        }

        public double TotalPercentageObtained
        {
            get
            {
                return (double)TotalMarkObtained * 100 / Marksheets.Sum(m => m.TotalMark);
            }
        }
    }

    public class Marksheet
    {
        public int MarkSheetId { get; set; }
        public int StudentId { get; set; }
        public string? Subject { get; set; }
        public int TotalMark { get; set; }
        public int MarksObtained { get; set; }
    }
}