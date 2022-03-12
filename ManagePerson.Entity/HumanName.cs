using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagePerson.Entity
{
    public class HumanName
    {
        public Guid Id { get; set; }
        [MaxLength(300)]
        public string Name { get; set; }
        [MaxLength(50)]
        public string Family { get; set; }
        [MaxLength(100)]
        public string Given { get; set; }
        [ForeignKey("Persons")]
        public Guid PersonId { get; set; }
    }
}
