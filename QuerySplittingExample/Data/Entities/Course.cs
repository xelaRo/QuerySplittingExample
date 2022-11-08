namespace QuerySplittingExample.Data.Entities
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateAdded { get; set; }
        public int AuthorId { get; set; }
    }
}
