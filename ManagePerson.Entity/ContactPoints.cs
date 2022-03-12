using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagePerson.Entity
{    public class ContactPoint
    {
        public Guid Id { get; set; }
        [Required, MaxLength(20)]
        public string System { get; set; }
        [Required, MaxLength(200)]
        public string Value { get; set; }
        [Required]
        public bool IsArchive { get; set; }
        [ForeignKey("Persons")]
        public Guid PersonId { get; set; }

    }
}
