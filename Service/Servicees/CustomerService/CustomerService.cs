using Repository.Repositories.CustomerRepo;
using Repository.ViewModels.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Servicees.CustomerService
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository customerRepository;

        public CustomerService(ICustomerRepository _cusromerRepository)
        {
            customerRepository = _cusromerRepository;
        }
        public async Task<int> CreateCustomer(CustomerActionDto model)
        {
            return await customerRepository.CreateCustomer(model);
        }

        public async Task DeleteCustomerById(int id)
        {
            await customerRepository.DeleteCustomerById(id);
        }

        public async Task<IList<CustomerDto>> GetAllCustomer()
        {
            return await customerRepository.GetAllCustomer();
        }

        public async Task<CustomerDto> GetCustomerById(int id)
        {
            return await customerRepository.GetCustomerById(id);
        }

        public async Task<CustomerDto> UpdateCustomer(CustomerUpdateDto model)
        {
            return await customerRepository.UpdateCustomer(model);
        }
    }
}
