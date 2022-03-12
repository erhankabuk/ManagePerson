using Dapper;
using ManagePerson.CommandAndQuery.Commands.Request;
using ManagePerson.CommandAndQuery.Handlers.CommandHandlers;
using ManagePerson.CommandAndQuery.Handlers.QueryHandlers;
using ManagePerson.CommandAndQuery.Queries.Response;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data.SqlClient;

namespace ManagePersonUnitTests
{
    [TestClass]
    public class UnitTests
    {

        [TestMethod]
        public void GetPersonByEmail_Parameters_Test()
        {
            string email = "reddy@yopmail.com";
            var expected = new GetPersonByEmailQueryResponse()
            {
                Name = "Rani  S",
                Family = "S",
                Given = "Roni",
                Email = "reddy@yopmail.com",
                Phone = "+919925516002"
            };

            GetPersonByEmailQueryHandler obj = new GetPersonByEmailQueryHandler(new SqlConnection("Server=(LocalDB)\\MSSQLLocalDB;Database=ManagePerson;Trusted_Connection=True;MultipleActiveResultSets=true;"));

            var response = obj.GetPersonByEmail(email);

            Assert.AreEqual(expected.Family, response.Family);
            Assert.AreEqual(expected.Given, response.Given);
            Assert.AreEqual(expected.Name, response.Name);
            Assert.AreEqual(expected.Phone, response.Phone);
            Assert.AreEqual(expected.Email, response.Email);
        }


        [TestMethod]
        public void GetPersonByEmail_Any_Parameter_IsNull_Test()
        {
            string email = "reddy@yopmail.com";

            GetPersonByEmailQueryHandler obj = new GetPersonByEmailQueryHandler(new SqlConnection("Server=(LocalDB)\\MSSQLLocalDB;Database=ManagePerson;Trusted_Connection=True;MultipleActiveResultSets=true;"));

            var response = obj.GetPersonByEmail(email);
            Assert.IsNotNull(response, "Null parameter");
        }

        [TestMethod]
        public void EditPersonById_Parameters_Test()
        {
            Guid personId = new Guid("1B2F6401-63CC-402B-A4D4-08D82CCD102E");
            var request = new EditPersonCommandRequest()
            {
                Family = "S",
                Given = "Roni",
                PersonId = personId,
                Value = "+919925516002"
            };

            EditPersonCommandHandler obj = new EditPersonCommandHandler(new SqlConnection("Server=(LocalDB)\\MSSQLLocalDB;Database=ManagePerson;Trusted_Connection=True;MultipleActiveResultSets=true;"));

            obj.EditPersonById(request);
            Assert.IsNotNull(request);
        }

        [TestMethod]
        public void IsPersonId_Existed()
        {

            Guid personId = new Guid("1B2F6401-63CC-402B-A4D4-08D82CCD102E");
            // Guid personId = new Guid("1B2F6401-63CC-402B-A4D4-08D82CCD102A");

            var obj = new SqlConnection("Server=(LocalDB)\\MSSQLLocalDB;Database=ManagePerson;Trusted_Connection=True;MultipleActiveResultSets=true;");

            var sqlHumanName = "SELECT PersonId FROM HumanNames H WHERE H.PersonId =@personId";
            var sqlContactPoints = "SELECT PersonId FROM ContactPoints C WHERE C.PersonId =@personId";

            var actualHumanName = obj.Query<Guid>(sqlHumanName, new { @personId = personId }).AsList()[0];
            var actualContactPoints = obj.Query<Guid>(sqlContactPoints, new { @personId = personId }).AsList()[0];

            Assert.AreEqual(personId, actualHumanName);
            Assert.AreEqual(personId, actualContactPoints);

        }



    }
}
