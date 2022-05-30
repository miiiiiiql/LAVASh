using System.ComponentModel.DataAnnotations.Schema;
namespace LAVASh.DBmodels
{
    public class HeadSubordinate
    {
        public int Id { get; set; }
        [InverseProperty("UserHead")]
        public User Head { get; set; }
        public int HeadId { get; set; }
        [InverseProperty("UserSubordinate")]
        public User Subordinate { get; set; }
        public int? SubordinateId { get; set; }
        
    }
}
