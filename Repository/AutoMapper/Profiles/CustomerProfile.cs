using AutoMapper;
using DataLayer.Model;
using Repository.ViewModels.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.AutoMapper.Profiles
{
    public class CustomerProfile: Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer, CustomerDto>().ForMember(x => x.RegistrationDateTime, o => o.MapFrom(s => s.RegistrationDateTime.ToLongDateString()));
            CreateMap<CustomerActionDto, Customer>();

        }
    }
}
