using Entities.Notification;
using System.ComponentModel.DataAnnotations;

namespace Entities.Entitys
{
    public class Base : Notifies
    {
        [Display(Name = "Código")]
        public int Id { get; set; }
        [Display(Name = "Nome")]
        public string Name { get; set; }
    }
}
