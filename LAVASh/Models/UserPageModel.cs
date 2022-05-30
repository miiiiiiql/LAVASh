namespace LAVASh.Models
{
    public class UserPageModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<LAVASh.DBmodels.Task> Tasks { get; set; }

    }
}
