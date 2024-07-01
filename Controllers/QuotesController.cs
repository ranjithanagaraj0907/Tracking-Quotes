using System.Net;
using System.Xml;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using QuotesApplication.Data;
using QuotesApplication.Models;

[ApiController]
[Route("[controller]")]
public class QuotesController : ControllerBase
{
    private readonly QuoteDbContext _context;

    public QuotesController(QuoteDbContext context)
    {
        _context = context;
    }


    //Get the all customer details

    [HttpGet]
    [Route("QuotesDetails")]
    public async Task<ActionResult<IEnumerable<QuotesModel>>> GetQuotesDetails()
    {
        return await _context.quotesModel.ToListAsync();
    }

    //Get the customer details filtering by id only

    // GET: api/Users/5

    [HttpGet("{id}")]

    public async Task<ActionResult<QuotesModel>> GetQuotesDetailsById(int id)
    {
        var user = await _context.quotesModel.FindAsync(id);

        if (user == null)
        {
            return NotFound();
        }

        return user;
    }


    //Add for customer Details


    [HttpPost("Qu0tesDetails")]

    public async Task<IActionResult> GetQuotesDetails([FromBody] QuotesModel request)
    {
        if (await _context.quotesModel.AnyAsync(u => u.Id == request.Id))
        {
            return BadRequest(new { message = "This QuoteItem already exists" });
        }

        var user = new QuotesModel()
        {
            Title=request.Title,
            Description=request.Description,
            StaffID=request.StaffID,
            CustomerID=request.CustomerID,
            ReceviedDtae=request.ReceviedDtae,
            quoteitem=(from item in request.quoteitem
                       select new Quoteitem()
                       {
                           Itemcode=item.Itemcode,
                           ItemName=item.ItemName,
                           Quantityrequested=item.Quantityrequested
                       }).ToList()


        };

        _context.quotesModel.Add(user);
        await _context.SaveChangesAsync();


        //return Ok(HttpStatusCode.OK);

        
        return Ok(user);
    }


}
