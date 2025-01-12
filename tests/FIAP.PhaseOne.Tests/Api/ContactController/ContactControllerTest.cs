using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using FIAP.PhaseOne.Api.Dto;

namespace FIAP.PhaseOne.Tests.Api.ContactController
{
    public class ContactControllerTest : ApplicationTest
    {
        [Fact]
        public async Task POST_AddContact_ReturnOK()
        {
            //Arrange
            var app = new PhaseOneWebApplicationFactory();
            var contact = new ContactDto()
            {
                Name = $"{_faker.Name.FirstName()} {_faker.Name.LastName()}",
                Email = _faker.Internet.Email(),
                Address = NewAddress(),
                Phone = NewPhone()
            };
            var client = app.CreateClient();
            //Act
            var result = await client.PostAsJsonAsync("api/contacts", contact);
            
            //Assert
            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
        }
        [Fact]
        public async Task GET_ReturnExistContact_ReturnOk()
        {
            //Arrange
            var app = new PhaseOneWebApplicationFactory();
            var client = app.CreateClient();
            var id = "4ff026a0-9c39-427e-9f16-37ab10744dab";

            //Act
            var result = await client.GetAsync($"api/contacts/{id}");

            //Assert
            Assert.Equal(HttpStatusCode.OK, result.StatusCode);

            var content = await result.Content.ReadAsStringAsync();
            Assert.NotNull(content);
            Assert.Contains("name", content);
            Assert.Contains("email", content);
        }

        private PhoneDto NewPhone() =>
            new PhoneDto
            {
                DDD = new Random().Next(1, 99),
                Number = _faker.Phone.PhoneNumber("#########")
            };

        private AddressDto NewAddress() =>
            new AddressDto
            {
                Street = _faker.Address.StreetName(),
                Number = _faker.Address.BuildingNumber(),
                City = _faker.Address.City(),
                Complement = _faker.Address.SecondaryAddress(),
                State = _faker.Address.StateAbbr(),
                District = _faker.Address.County(),
                Zipcode = _faker.Address.ZipCode("########")
            };
    }
}
