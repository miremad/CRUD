using Repository.ViewModels.Customer;

namespace Service.Servicees.CustomerService
{
    public interface ICustomerService
    {
        Task<int> CreateCustomer(CustomerActionDto model);
        Task<CustomerDto> UpdateCustomer(CustomerUpdateDto model);
        Task<CustomerDto> GetCustomerById(int id);
        Task<IList<CustomerDto>> GetAllCustomer();
        Task DeleteCustomerById(int id);
    }
}
