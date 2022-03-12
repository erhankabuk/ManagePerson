using Dapper;
using ManagePerson.CommandAndQuery.Queries.Response;
using ManagePerson.Core.Repository;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagePerson.CommandAndQuery.Handlers.QueryHandlers
{
    public class GetPersonByEmailQueryHandler : IRepository
    {
        private IDbConnection db;
        public GetPersonByEmailQueryHandler(IConfiguration configuration)
        {
            db = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
        }
        public GetPersonByEmailQueryHandler(SqlConnection con)
        {
            db = con;
        }
        public GetPersonByEmailQueryResponse GetPersonByEmail(string email)
        {
            try
            {
                var sql = "SELECT h.Name, h.Family, h.Given ,c.Value AS Email, (SELECT c.Value FROM ContactPoints c WHERE c.System LIKE @System) AS Phone FROM Persons p JOIN HumanNames h ON h.PersonId = p.Id JOIN ContactPoints c ON c.PersonId = p.Id WHERE c.Value LIKE @Value";

                return db.Query<GetPersonByEmailQueryResponse>(sql, new { @Value = email, @System = "Phone" }).Single();
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
