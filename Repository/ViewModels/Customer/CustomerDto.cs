using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.ViewModels.Customer
{
    public record CustomerDto(int Id, string FirstName, string LastName, string PhoneNumber, string RegistrationDateTime);
    
}
