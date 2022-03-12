using Dapper;
using ManagePerson.CommandAndQuery.Commands.Request;
using ManagePerson.Core.Repository;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagePerson.CommandAndQuery.Handlers.CommandHandlers
{
    public class EditPersonCommandHandler : IRepository
    {

        private IDbConnection db;
        public EditPersonCommandHandler(IConfiguration configuration)
        {
            db = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
        }
        public EditPersonCommandHandler(SqlConnection con)
        {
            db = con;
        }
        public void EditPersonById(EditPersonCommandRequest editPersonCommandRequest)
        {
            try
            {
            var sqlHumanName = "UPDATE HumanNames SET Family=@Family, Given =@Given WHERE PersonId=@PersonId";
            db.Execute(sqlHumanName, new { @Family = editPersonCommandRequest.Family, @Given = editPersonCommandRequest.Given, @PersonId = editPersonCommandRequest.PersonId });

            var sqlContactPoint = "UPDATE ContactPoints SET Value=@Value WHERE System=@System AND PersonId=@PersonId";
            db.Execute(sqlContactPoint, new { @Value = editPersonCommandRequest.Value, @System = "Phone", @PersonId = editPersonCommandRequest.PersonId });

            }
            catch (Exception)
            {

                throw ;
            }
        }
    }
}
