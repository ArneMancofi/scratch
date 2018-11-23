using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using HelloWorldServer.Models;

namespace TodoApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class HelloWorldController : ControllerBase
  {
    private readonly HelloWorldContext _context;

    public HelloWorldController(HelloWorldContext context)
    {
      _context = context;

      if (_context.PensionCompanies.Count() == 0)
      {
        // Create a new PensionCompany if collection is empty,
        // which means you can't delete all PensionCompanies.
        _context.PensionCompanies.Add(new PensionCompany { Name = "PlatinPension" });
        _context.PensionCompanies.Add(new PensionCompany { Name = "BedreEndIngen Pension" });
        _context.SaveChanges();
      }
    }

    [HttpGet]
    public ActionResult<List<PensionCompany>> GetAll()
    {
      return _context.PensionCompanies.ToList();
    }

    [HttpGet("{id}", Name = "GetPensionCompany")]
    public ActionResult<PensionCompany> GetById(long id)
    {
      var company = _context.PensionCompanies.Find(id);
      if (company == null)
      {
        return NotFound();
      }
      return company;
    }

    [HttpPost]
    public IActionResult Create(PensionCompany company)
    {
      _context.PensionCompanies.Add(company);
      _context.SaveChanges();

      return CreatedAtRoute("GetPensionCompany", new { id = company.Id }, company);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(long id)
    {
      var todo = _context.PensionCompanies.Find(id);
      if (todo == null)
      {
        return NotFound();
      }

      _context.PensionCompanies.Remove(todo);
      _context.SaveChanges();
      return NoContent();
    }
  }
}