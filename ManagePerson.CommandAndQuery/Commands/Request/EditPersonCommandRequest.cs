using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagePerson.CommandAndQuery.Commands.Request
{
    public class EditPersonCommandRequest
    {
        [MaxLength(50)]
        public string Family { get; set; }

        [MaxLength(100)]
        public string Given { get; set; }

        [Required, MaxLength(200)]
        public string Value { get; set; }

        [ForeignKey("Persons")]
        public Guid PersonId { get; set; }
    }
}
