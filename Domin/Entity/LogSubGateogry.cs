using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Entity
{
    public class LogSubGateogry
    {
        public Guid Id { get; set; }
        public string Action { get; set; }
        public DateTime Date { get; set; }
        public Guid UesrId { get; set; }
        public Guid SubCateogryId { get; set; }
        [ForeignKey("SubCateogryId")]
        public SubCateogry SubCateogry { get; set; }
    }
}
