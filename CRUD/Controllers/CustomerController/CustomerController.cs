using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Repository.ViewModels.Customer;
using Service.Servicees.CustomerService;

namespace CRUD.Controllers.CustomerController
{
    [Route("api/[controller]")]
    [AllowAnonymous]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService customerService;

        public CustomerController(ICustomerService _customerService)
        {
            customerService = _customerService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerDto>> Get(int id)
        {
            try
            {
                var res = await customerService.GetCustomerById(id);
                if(res == null)
                {
                    return NotFound(new {status = 404, message = "invalid customer id"});
                }
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            

        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<IList<CustomerDto>>> GetAll()
        {
            var res = await customerService.GetAllCustomer();
            if(res == null)
            {
                return BadRequest();
            }
            else
            {
                return Ok(res);
            }
        }

        [HttpPost("create")]
        public async Task<ActionResult<CustomerDto>> Create(CustomerActionDto model)
        {
            try
            {
                var id = await customerService.CreateCustomer(model);
                return RedirectToAction(nameof(Get), new { id});
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
            
        }

        [HttpPut("Update")]
        public async Task<ActionResult<CustomerDto>> Update(CustomerUpdateDto model)
        {
            try
            {
                var res = await customerService.UpdateCustomer(model);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try 
            {
                await customerService.DeleteCustomerById(id);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
