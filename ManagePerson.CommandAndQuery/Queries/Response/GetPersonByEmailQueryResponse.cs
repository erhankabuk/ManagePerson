using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagePerson.CommandAndQuery.Queries.Response
{    public class GetPersonByEmailQueryResponse
    {
        public string Name { get; set; }
        [MaxLength(50)]
        public string Family { get; set; }
        [MaxLength(100)]
        public string Given { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
