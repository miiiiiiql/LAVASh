using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
namespace LAVASh.Models
{
    public class AdminPanelModel
    {
        
        public SelectList Workers { get; set; }
        [Required(ErrorMessage = "Не указан подчинённый")]
        public int WorkerId { get; set; }
        [Required(ErrorMessage = "Не указан начальник")]
        public int HeadId { get; set; }
    }
}
