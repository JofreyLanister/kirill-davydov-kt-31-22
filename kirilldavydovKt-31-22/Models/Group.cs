namespace kirilldavydovKt_31_22.Models
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public List<Student> Students { get; set; } = new();
    }
}