namespace LAVASh.Models
{
    public class SubordinateTaskModel
    {
        public int UserId { get; set; }
        public List<TaskModel> Tasks { get; set; }
    }
    public class TaskModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Place { get; set; }
        public string Description { get; set; }
        public DateTime TimeToDo { get; set; }
        public DateTime Deadline { get; set; }
        
        public static explicit operator TaskModel(LAVASh.DBmodels.Task task)
        {
            return new TaskModel { Id = task.Id, Name = task.Name, Description = task.Description, Place = task.Place.Name, Deadline = task.EndOfDoing, TimeToDo = task.TimeToDo };
        }
    }

}
