// Tests/ContactValidationTests.cs
using System.ComponentModel.DataAnnotations;
using ContactManager.Models;
using Xunit;

namespace ContactManager.Tests
{
    public class ContactValidationTests
    {
        private List<ValidationResult> ValidateModel(Contact model)
        {
            var context = new ValidationContext(model, null, null);
            var results = new List<ValidationResult>();
            Validator.TryValidateObject(model, context, results, true);
            return results;
        }

        [Fact]
        public void Valid_Contact_Should_Pass_Validation()
        {
            var contact = new Contact
            {
                Name = "João da Silva",
                ContactNumber = "1234567890",
                Email = "joao@example.com"
            };

            var results = ValidateModel(contact);

            Assert.Empty(results);
        }

        [Fact]
        public void Invalid_Email_Should_Fail_Validation()
        {
            var contact = new Contact
            {
                Name = "João da Silva",
                ContactNumber = "1234567890",
                Email = "email_invalido"
            };

            var results = ValidateModel(contact);

            Assert.Contains(results, r => r.MemberNames.Contains("Email"));
        }
    }
}
