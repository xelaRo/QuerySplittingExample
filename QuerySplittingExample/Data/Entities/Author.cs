namespace QuerySplittingExample.Data.Entities
{
    public class Author
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfRegistration { get; set; }

        public ICollection<Course> Courses { get; set; }
    }
}
