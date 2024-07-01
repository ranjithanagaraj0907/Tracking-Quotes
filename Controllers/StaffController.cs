using System.Net;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using QuotesApplication.Data;
using QuotesApplication.Models;

[ApiController]
[Route("[controller]")]
public class StaffController : ControllerBase
{
    private readonly QuoteDbContext _context;

    public StaffController(QuoteDbContext context)
    {
        _context = context;
    }


    //Get the all customer details

    [HttpGet]
    [Route("StaffDetails")]
    public async Task<ActionResult<IEnumerable<StaffsModels>>> GetStaffDetails()
    {
        return await _context.staffmodel.ToListAsync();
    }

    //Get the customer details filtering by id only

    // GET: api/Users/5

    [HttpGet("{id}")]

    public async Task<ActionResult<StaffsModels>> GetStaffDetailsById(int id)
    {
        var user = await _context.staffmodel.FindAsync(id);

        if (user == null)
        {
            return NotFound();
        }

        return user;
    }


    //Add/insert the staff Details


    [HttpPost("StaffDetails")]
    public async Task<IActionResult> Register([FromBody] StaffsModels request)
    {
        if (await _context.staffmodel.AnyAsync(u => u.Email == request.Email))
        {
            return BadRequest(new { message = "Staff Details already exists" });
        }

        var user = new StaffsModels()
        {
           StaffName=request.StaffName,
           Desgination=request.Desgination,
           PhoneNumber=request.PhoneNumber,
           Address=request.Address,
           Email=request.Email

        };

        _context.staffmodel.Add(user);
        await _context.SaveChangesAsync();

        return Ok(new { message = "Staff Details added successfully" });
    }


}
