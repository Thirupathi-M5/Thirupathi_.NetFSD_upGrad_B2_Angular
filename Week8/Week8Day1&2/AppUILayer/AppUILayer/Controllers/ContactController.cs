using Microsoft.AspNetCore.Mvc;
using DataAccessLayer.Repositories;
using DataAccessLayer.Models;

public class ContactController : Controller
{
    private readonly IContactRepository _repo;

    public ContactController(IContactRepository repo)
    {
        _repo = repo;
    }

    public IActionResult ShowContacts()
    {
        var data = _repo.GetAllContacts();
        return View(data);
    }

    public IActionResult AddContact()
    {
        ViewBag.Companies = _repo.GetCompanies();
        ViewBag.Departments = _repo.GetDepartments();
        return View();
    }

    [HttpPost]
    public IActionResult AddContact(ContactInfo contact)
    {
        _repo.AddContact(contact);
        return RedirectToAction("ShowContacts");
    }

    public IActionResult DeleteContact(int id)
    {
        _repo.DeleteContact(id);
        return RedirectToAction("ShowContacts");
    }
}