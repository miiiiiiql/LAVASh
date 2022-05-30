using LAVASh.DBmodels;
namespace LAVASh.Models
{
    public class WorkerListModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }

        public static explicit operator WorkerListModel(User user)
        {
            return new WorkerListModel { Id = user.Id, FullName = user.FullName };
        }
    }
}
