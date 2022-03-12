using ManagePerson.CommandAndQuery.Commands.Request;
using ManagePerson.CommandAndQuery.Handlers.CommandHandlers;
using ManagePerson.CommandAndQuery.Handlers.QueryHandlers;
using ManagePerson.CommandAndQuery.Queries.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManagePerson.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly GetPersonByEmailQueryHandler _getPersonByEmailQueryHandler;
        private readonly EditPersonCommandHandler _editPersonCommandHandler;

        public PersonController(GetPersonByEmailQueryHandler getPersonByEmailQueryHandler, EditPersonCommandHandler editPersonCommandHandler)
        {
            _getPersonByEmailQueryHandler = getPersonByEmailQueryHandler;
            _editPersonCommandHandler = editPersonCommandHandler;
        }


        // Email=> reddy@yopmail.com
        // GET /api/Person/{email}
        [HttpGet("{email}")]
        public GetPersonByEmailQueryResponse Get(string email)
        {
            return _getPersonByEmailQueryHandler.GetPersonByEmail(email);
        }


        // PersonId=> 1B2F6401-63CC-402B-A4D4-08D82CCD102E
        // PUT api/Person/{PersonId}               
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, EditPersonCommandRequest _editPersonCommandRequest)
        {
            if (id != _editPersonCommandRequest.PersonId) return BadRequest();

            _editPersonCommandHandler.EditPersonById(_editPersonCommandRequest);

            return Ok();
        }
    }
}
