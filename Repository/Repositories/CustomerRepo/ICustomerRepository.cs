using Repository.ViewModels.Customer;

namespace Repository.Repositories.CustomerRepo
{
    public interface ICustomerRepository
    {
        Task<int> CreateCustomer(CustomerActionDto model);
        Task<CustomerDto> UpdateCustomer(CustomerUpdateDto model);
        Task<CustomerDto> GetCustomerById(int id);
        Task<IList<CustomerDto>> GetAllCustomer();
        Task DeleteCustomerById(int id);

    }
}
