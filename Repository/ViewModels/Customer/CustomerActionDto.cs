using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.ViewModels.Customer
{
    public record CustomerActionDto(string FirstName, string LastName, string PhoneNumber) : RecordWithValidation
    {
        public DateTime RegistrationDateTime { get; } = DateTime.Now;

        protected override void Validate()
        {
            if (FirstName == null)
                throw new ArgumentException("Argument cannot be null.", nameof(FirstName));
            if (LastName == null)
                throw new ArgumentException("Argument cannot be null.", nameof(LastName));
            if(PhoneNumber == null)
                throw new ArgumentException("Argument cannot be null.", nameof(PhoneNumber));
            if (!PhoneNumber.StartsWith("09") || PhoneNumber.Length != 11)
                throw new ArgumentException("Phone number should start with 09 and it should be 11 digit", nameof(PhoneNumber));
        }
    }
    

}
