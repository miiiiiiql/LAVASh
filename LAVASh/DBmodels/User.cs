using System.ComponentModel.DataAnnotations.Schema;
namespace LAVASh.DBmodels
{
    public class User
    {
        public int Id { get; set; }
        public string Password { get; set; }
        public string? Firstname { get; set; }
        public string? Secondname { get; set; }
        public string? Lastname { get; set; }
        public string Email { get; set; }
        public bool IsAdmin { get; set; }
        public List<HeadSubordinate> UserSubordinate { get; set; } = new();
        
        public HeadSubordinate UserHead { get; set; }
        public int HeadId { get; set; }
        public List<Task> HisTasks { get; set; } = new();
        public List<Task> AuthorOfTasks { get; set; } = new();

        public string FullName { get { return Firstname + " " + Secondname + " "; } }
    }
}
