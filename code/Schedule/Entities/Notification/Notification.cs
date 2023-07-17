using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Notification
{
    public class Notification
    {
        [NotMapped]
        public string PropertyName { get; set; }
        [NotMapped]
        public string Description { get; set; }
        [NotMapped]
        public List<Notification> Notifications;

        public Notification()
        {
            Notifications = new List<Notification>();
        }

        public bool PropertyIsValidString(string value, string property)
        {
            if (string.IsNullOrWhiteSpace(value) || string.IsNullOrWhiteSpace(property))
            {
                Notifications.Add(new Notification
                {
                    Description = "Campo Obrigatorio",
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
                Notifications.Add(new Notification
                {
                    Description = "Campo Obrigatorio",
                    PropertyName = property
                });
                return false;
            }
            return true;
        }

    }
}
