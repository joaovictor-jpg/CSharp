using Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entitys
{
    public class Task : Base
    {
        public string Description { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public DateTime RegisterDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public StatusTask StatusTask { get; set; }

        [ForeignKey("ApplicationUser")]
        [Column(Order = 1)]
        public int IdUser { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

    }
}
