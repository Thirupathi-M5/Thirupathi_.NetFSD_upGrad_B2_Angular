using DAL.DataAccess;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace UVEMS.UI.Controllers
{
    public class EventController:Controller
    {
        private readonly EventDetailsService _service;

        public EventController()
        {
            _service = new EventDetailsService();
        }

        // Show all events
        public IActionResult Index()
        {
            var events = _service.GetAllEvents();
            return View(events);
        }

        // GET: Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Create
        [HttpPost]
        public IActionResult Create(EventDetails eventObj)
        {
            _service.AddEvent(eventObj);
            return RedirectToAction("Index");
        }
        // GET: Edit
        public IActionResult Edit(int id)
        {
            var eventObj = _service.GetEventById(id);
            return View(eventObj);
        }

        // POST: Edit
        [HttpPost]
        public IActionResult Edit(EventDetails eventObj)
        {
            _service.UpdateEvent(eventObj);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            _service.DeleteEvent(id);
            return RedirectToAction("Index");
        }
    }
}
