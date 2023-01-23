using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using WebTestVersta.Models;

namespace WebTestVersta.Controllers
{
    public class RecipientController : Controller
    {

        private SuppliesDbContext db;

        public RecipientController(SuppliesDbContext supplies) 
        {
            db = supplies;
        }

        public async Task<IActionResult> IndexRecs()
        {
            ViewData["Title"] = "Таблица получателей";
            return View(await db.Recipients.ToListAsync());
        }
        [HttpGet]
        public IActionResult Create()
        {
            Recipient _recipient = new Recipient();
            return View(_recipient);
        }

        [HttpPost]

        public IActionResult Create(Recipient _recipient)
        {
            if (ModelState.IsValid)
            {
                if (_recipient.Id != 0)
                {
                    db.Recipients.Update(_recipient);
                }
                else
                    db.Add(_recipient);
                db.SaveChanges();
                return RedirectToAction("IndexRecs");
            }
            else
                return View();
        }

        public IActionResult Edit(Recipient _recipient)
        {
            if (_recipient != null)
                return View("CreateRec", _recipient);
            else
                return NotFound();

        }
        public IActionResult Delete(Recipient _recipient)
        {
            var deletedRecipient = db.Recipients.FirstOrDefault(r => r.Id == _recipient.Id);
            if (deletedRecipient != null)
            {
                db.Recipients.Remove(deletedRecipient);
                db.SaveChanges();
            }
            return RedirectToAction("IndexRecs");
        }



    }
}