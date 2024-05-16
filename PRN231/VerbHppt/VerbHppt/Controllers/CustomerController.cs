using Microsoft.AspNetCore.Mvc;
using VerbHppt.Models;

namespace VerbHppt.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : Controller
    {
        private readonly PRN_Sum22_B1Context _context;
        public CustomerController(PRN_Sum22_B1Context context)
        {
            _context = context;
        }
        [HttpPost("AddCustomer")]
        public async Task<IActionResult> AddCustomer(CustomerDTO c)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    Customer n= new Customer();

                    _context.Customers.Add(c);
                    await _context.SaveChangesAsync();
                    return View(c);
                }
                return BadRequest();
            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet("GetCustomer/{name}")]
        public IActionResult GetCustomer(string name)
        {
            var customers = _context.Customers.Where(x => x.ContactName.ToLower().Contains(name.ToLower())).ToList();
            if (customers.Count == 0)
            {
                return NotFound();
            }
            int numofrow = customers.Count;
            return Ok(customers);
        }
        [HttpPost("CreateNewEmployee")]
        public IActionResult CreateNewEmployee(EmployeeDTOPost tmp) {
            try
            {
                ModelMapper modelMapper = new ModelMapper();
                if (tmp != null)
                {
                    Employee p = new Employee()
                    {
                        LastName = tmp.LastName,
                        FirstName = tmp.FirstName,
                        DepartmentId = tmp.DepartmentId,
                        Title = tmp.Title,
                        TitleOfCourtesy = tmp.TitleOfCourtesy,
                        BirthDate = tmp.BirthDate,
                        HireDate = tmp.HireDate,
                        Address = tmp.Address,
                    };
                    _context.Employees.Add(p);
                    int t= _context.SaveChanges();
                    return Ok(t);
                }

            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }
        [HttpPut("UpdateDatabase/{id}")]
        public IActionResult UpdateEmployee(int id, EmployeeDTOPost tmp)
        {
            try
            {
                var e = _context.Employees.FirstOrDefault(x => x.EmployeeId == id);
                if (e != null)
                {
                    e.Title= tmp.Title;
                    e.FirstName= tmp.FirstName;
                    e.LastName= tmp.LastName;
                    e.TitleOfCourtesy= tmp.TitleOfCourtesy;
                    e.BirthDate = tmp.BirthDate;
                    e.Address= tmp.Address;
                    _context.Employees.Update(e);
                    _context.SaveChanges();
                    return Ok(e);
                }
            }catch (Exception ex)
            {
                return BadRequest(ex);
            }
            return NotFound();
        }
        [HttpDelete("DeleteProduct/{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            try
            {
                var tmp = _context.Products.FirstOrDefault(x => x.ProductId == id);
                if(tmp != null)
                {
                    var detail= _context.OrderDetails.Where(x=>x.ProductId == id).ToList();
                    if (detail != null)
                    {
                        foreach(var t in detail)
                        {
                            _context.OrderDetails.Remove(t);
                            _context.SaveChanges();
                        }
                    } 
                    _context.Products.Remove(tmp);
                    _context.SaveChanges();
                    return Ok(tmp);
                }
            }catch  (Exception ex)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}
