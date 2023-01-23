using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using WebTestVersta.Models;

namespace WebTestVersta.Controllers
{
    public class SenderController : Controller
    {

        private SuppliesDbContext db;

        public SenderController(SuppliesDbContext supplies) 
        {
            db = supplies;
        }

        public async Task<IActionResult> IndexSenders()
        {
            ViewData["Title"] = "Таблица отправителей";
            return View(await db.Senders.ToListAsync());
        }
        [HttpGet]
        public IActionResult CreateSender()
        {
            Sender _sender = new Sender();
            return View(_sender);
        }

        [HttpPost]

        public IActionResult CreateSender(Sender _sender)
        {
            if (ModelState.IsValid)
            {
                if (_sender.Id != 0)
                {
                    db.Senders.Update(_sender);
                }
                else
                    db.Add(_sender);
                db.SaveChanges();
                return RedirectToAction("IndexSenders");
            }
            else
                return View();
        }

        public IActionResult Edit(Sender _sender)
        {
            if (_sender != null)
                return View("CreateSender", _sender);
            else
                return NotFound();

        }
        public IActionResult Delete(Sender _sender)
        {
            var deletedSender = db.Senders.FirstOrDefault(s => s.Id == _sender.Id);
            if (deletedSender != null)
            {
                db.Senders.Remove(deletedSender);
                db.SaveChanges();
            }
            return RedirectToAction("IndexSenders");
        }



    }
}