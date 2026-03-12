namespace kirilldavydovKt_31_22.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string FullName { get; set; } = null!;
        public int Age { get; set; }

        public int GroupId { get; set; }
        public Group Group { get; set; } = null!;
    }
}