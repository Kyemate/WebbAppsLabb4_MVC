using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared.Models;

namespace WebbAppsLabb4_MVC.Controllers;

public class CustomerController : Controller
{
    private readonly AppDbContext _context;

    public CustomerController(AppDbContext context)
    {
        _context = context;
    }
    // GET: CustomerController
    public async Task<IActionResult> Index()
    {
        return View(await _context.Customers.ToListAsync());
    }

    // GET: CustomerController/Details/5
    public ActionResult Profile(int id)
    {
        var profile = _context.Customers.Where(x => x.Id == id)
            .Include(x => x.Loans)!.ThenInclude(x => x.Book).FirstOrDefault();
        
        return View(profile);
    }


    // GET: Employee/Create
    public IActionResult AddOrEdit(int id = 0)
    {
        if (id == 0)
            return View(new Customer());
        else
            return View(_context.Customers.Find(id));
    }

    // POST: CustomerController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> AddOrEdit([Bind("Id,Name,Address")] Customer customer)
    {
        if (ModelState.IsValid)
        {
            if (customer.Id == 0)
                _context.Add(customer);
            else
                _context.Update(customer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(customer);
    }


    public IActionResult AddLoan(int id = 0)
    {
        //if (id == 0)
        return View(new Loan {CustomerId = id});
        //else
        //    return View(_context.Customers.Find(id));
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> AddLoan([Bind("LoanDate,IsActive,CustomerId,BookId")] Loan loan)
    {
        ModelState.Remove("Customer");
        ModelState.Remove("Book");
        if (ModelState.IsValid && !await _context.Loans.AnyAsync(x => x.CustomerId == loan.CustomerId && x.BookId == loan.BookId))
        {
            _context.Add(loan);
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Profile), new {Id = loan.CustomerId});
        }
        return View(loan);
    }

    // GET: CustomerController/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        var customer = await _context.Customers.FindAsync(id);
        _context.Customers.Remove(customer);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }


    //// POST: CustomerController/Delete/5
    //[HttpPost]
    //[ValidateAntiForgeryToken]
    //public ActionResult Delete(int id, IFormCollection collection)
    //{
    //    try
    //    {
    //        return RedirectToAction(nameof(Index));
    //    }
    //    catch
    //    {
    //        return View();
    //    }
    //}
}