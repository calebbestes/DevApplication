using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DevApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace DevApplication.Controllers;

public class HomeController : Controller
{
    private ContactContext _context;

    public HomeController(ContactContext _temp)
    {
        _context = _temp;
    }
    
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }



    [HttpGet]
    public IActionResult Form()
    {
        ViewBag.Categories = _context.Categories
            .OrderBy(_context => _context.CategoryName).ToList();
        return View("Form");
    }

    [HttpPost]
    public IActionResult Form(Contact Response)
    {
        _context.Contacts.Add(Response);
        _context.SaveChanges();

        return View("Confirmation", Response);
    }

    [HttpGet]
    public IActionResult List()
    {
        var contact = _context.Contacts.Include(x => x.Category).ToList()
            .OrderBy(x => x.Name).ToList();
        return View(contact);
    }
    
    [HttpGet]

    public IActionResult Edit(int id)
    {
        var recordToEdit = _context.Contacts
            .Single((x => x.ContactID == id));
        ViewBag.Categories = _context.Categories
            .OrderBy(x => x.CategoryName).ToList();
        return View("Form", recordToEdit);
    }

    [HttpPost]

    public IActionResult Edit(Contact updatedInfo)
    {
        _context.Update(updatedInfo);
        _context.SaveChanges();
        return RedirectToAction("List");
    }
    
    [HttpGet]
    public IActionResult Delete(int id)
    {
        var RecordToDelete = _context.Contacts
            .Single(x => x.ContactID == id);
        return View("Delete", RecordToDelete);
    }

    [HttpPost]

    public IActionResult Delete(Contact record)
    {
        _context.Remove(record);
        _context.SaveChanges();
        return RedirectToAction("List");
    }

    [HttpGet]
    public IActionResult Profile(int id)
    {
        var product = _context.Contacts
            .Single(x => x.ContactID == id);
        return View("Profile", product);
    }
}