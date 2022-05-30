namespace LAVASh.DBmodels
{
    public class Place
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string HelpStrings { get; set; }
        public List<Task> Tasks { get; set; } = new();
    }
}
