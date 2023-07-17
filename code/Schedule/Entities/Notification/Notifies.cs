using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Notification
{
    public class Notifies
    {
        [NotMapped]
        public string PropertyName { get; set; }
        [NotMapped]
        public string Message { get; set; }
        [NotMapped]
        public List<Notifies> Notifications { get; set; }

        public Notifies()
        {
            Notifications = new List<Notifies>();
        }

        public bool PropertyIsValidString(string value, string property)
        {
            if (string.IsNullOrWhiteSpace(value) || string.IsNullOrWhiteSpace(property))
            {
                Notifications.Add(new Notifies
                {
                    Message = "Campo Obrigatorio",
                    PropertyName = property
                });
                return false;
            }
            return true;
        }


        public bool PropertyIsValidInt(int value, string property)
        {
            if (value < 1 || string.IsNullOrWhiteSpace(property))
            {
                Notifications.Add(new Notifies
                {
                    Message = "Campo Obrigatorio",
                    PropertyName = property
                });
                return false;
            }
            return true;
        }
    }
}
