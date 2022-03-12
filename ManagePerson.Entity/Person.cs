using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagePerson.Entity
{
    public class Person
    {
        public Guid Id { get; set; }
        [MaxLength(50)]
        public string Gender { get; set; }
        [Required]
        public bool IsAdult { get; set; }
        public HumanName MyProperty { get; set; }
    }
}
