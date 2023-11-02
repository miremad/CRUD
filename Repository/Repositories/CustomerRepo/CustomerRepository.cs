using AutoMapper;
using AutoMapper.QueryableExtensions;
using DataLayer.ApplicationDbContext;
using DataLayer.Model;
using Microsoft.EntityFrameworkCore;
using Repository.ViewModels.Customer;

namespace Repository.Repositories.CustomerRepo
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IMapper mapper;
        public CustomerRepository(ApplicationDbContext _dbContext, IMapper _mapper)
        {
            dbContext = _dbContext;
            mapper = _mapper;

        }
        public async Task<int> CreateCustomer(CustomerActionDto model)
        {
            var newCustomer = mapper.Map<Customer>(model);
            dbContext.Customers.Add(newCustomer);
            await dbContext.SaveChangesAsync();
            return newCustomer.Id;
            
        }

        public async Task DeleteCustomerById(int id)
        {
            var customer = dbContext.Customers.SingleOrDefault(x => x.Id == id);
            if(customer == null)
            {
                throw new Exception("invalid Id");
            }

            dbContext.Customers.Remove(customer);
            await dbContext.SaveChangesAsync();

        }

        public async Task<IList<CustomerDto>> GetAllCustomer()
        {
            var customerList = await dbContext.Customers.ProjectTo<CustomerDto>(mapper.ConfigurationProvider).ToListAsync();
            return customerList;
        }

        public async Task<CustomerDto> GetCustomerById(int id)
        {
            var customer = await dbContext.Customers.Where(x => x.Id == id).ProjectTo<CustomerDto>(mapper.ConfigurationProvider).SingleOrDefaultAsync();
            return customer;
        }

        public async Task<CustomerDto> UpdateCustomer(CustomerUpdateDto model)
        {
            var customer = await dbContext.Customers.Where(x => x.Id == model.Id).SingleOrDefaultAsync();
            customer.FirstName = model.FirstName;
            customer.LastName = model.LastName;
            customer.PhoneNumber = model.PhoneNumber;
            await dbContext.SaveChangesAsync();
            return mapper.Map<CustomerDto>(customer);
        }
    }
}
