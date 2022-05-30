
using System.ComponentModel.DataAnnotations.Schema;

namespace LAVASh.DBmodels
{
    public class Task
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Periodly { get; set; }
        public DateTime TimeToDo { get; set; }
        public DateTime EndOfDoing { get; set; }
        [InverseProperty ("AuthorOfTasks") ]
        public User Author { get; set; }
        public int AuthorId { get; set; }
        [InverseProperty("HisTasks")]
        public User Executor { get; set; }
        public int ExecutorId { get; set; }
        public Place Place { get; set; }
        public int PlaceId { get; set; }
        public bool IsDone { get; set; }
    }
}
