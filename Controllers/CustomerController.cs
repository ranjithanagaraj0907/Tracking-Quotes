using System.Net;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using QuotesApplication.Data;
using QuotesApplication.Models;

[ApiController]
[Route("[controller]")]
public class CustomerController : ControllerBase
{
    private readonly QuoteDbContext _context;

    public CustomerController(QuoteDbContext context)
    {
        _context = context;
    }


    //Get the all customer details

    [HttpGet]
    [Route("CustomerDetails")]
    public async Task<ActionResult<IEnumerable<Customer>>> GetCustomerDetails()
    {
        return await _context.customer.ToListAsync();
    }

    //Get the customer details filtering by id only

    // GET: api/Users/5

    [HttpGet("{id}")]

    public async Task<ActionResult<Customer>> GetCustomerDetailsById(int id)
    {
        var user = await _context.customer.FindAsync(id);

        if (user == null)
        {
            return NotFound();
        }

        return user;
    }


    //Add for customer Details
    

    [HttpPost("CustomerDetails")]
    public async Task<IActionResult> Register([FromBody] Customer request)
    {
        if (await _context.customer.AnyAsync(u => u.Email == request.Email))
        {
            return BadRequest(new { message = "Customer already exists" });
        }

        var user = new Customer()
        {
            CustomerName=request.CustomerName,
            CompanyName=request.CompanyName,
            Desgination=request.Desgination,
            PhoneNumber=request.PhoneNumber,
            Email=request.Email,
            Address=request.Address,
            TaxNumber=request.TaxNumber

        };

        _context.customer.Add(user);
        await _context.SaveChangesAsync();

        return Ok(new { message = "Customer Details added successfully" });
    }

   
}
