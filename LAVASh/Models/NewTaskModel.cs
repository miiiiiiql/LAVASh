using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace LAVASh.Models
{
    public class NewTaskModel
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public SelectList Places { get; set; }
        [Required(ErrorMessage = "Не указано название задачи")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Не указано описание")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Не указана дата выполнения")]
        public DateTime TimeToDo { get; set; }
        [Required(ErrorMessage = "Не указана предельная дата")]
        public DateTime EndOfDoing { get; set; }
        [Required(ErrorMessage = "Не указано место")]
        public int PlaceId { get; set; }
    }
}
