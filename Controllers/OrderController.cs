using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq.Expressions;
using WebTestVersta.Models;

namespace WebTestVersta.Controllers
{
    public class OrderController : Controller
    {

        private SuppliesDbContext db;

        public OrderController(SuppliesDbContext supplies)
        {
            db = supplies;
        }

        public async Task<IActionResult> IndexOrders()
        {
            ViewData["Title"] = "Таблица отправителей";
            if (db.Orders.Count() != 0) return View(await db.Orders.ToListAsync());
            return View();
        }
        [HttpGet]
        public IActionResult CreateOrder()
        {
            Order _order = new Order();
            return View(_order);
        }

        [HttpPost]

        public IActionResult CreateOrder(Order model)
        {
            model.OrderNum = model.GenerateOrderNum();
            Sender _sender = null;
            Recipient _rec = null;

            try
            {
                 _sender = db.Senders.FirstOrDefault(s => s.SenderAddress == model.Sender.SenderAddress);

            }
            catch (Exception)
            {

                //throw ;
            }            
                
            if (_sender != null)
            {
                model.Sender = _sender;
                model.SenderId = _sender.Id;
            }
            try
            {
                _rec = db.Recipients.FirstOrDefault(s => s.RecAddress == model.Rec.RecAddress);

            }
            catch (Exception)
            {

                //throw;
            }            
            if (_rec != null)
            {
                model.Rec= _rec;
                model.RecId = _rec.Id;
            }

            if (ModelState.IsValid)
            {
                if (model.Id != 0)
                {
                    db.Orders.Update(model);
                }
                else
                {
                    db.Add(model);
                }
                db.SaveChanges();
                return RedirectToAction("IndexOrders");
            }
            else
                return View();
        }

        public IActionResult OpenReadOnly(Order _order)
        {
            if (_order != null)
            {
                db.Entry(_order).State = EntityState.Unchanged;
                db.Entry(_order).Reference(o => o.Rec).Load();
                db.Entry(_order).Reference(o => o.Sender).Load();

                return View("OpenReadOnly", _order);
            }
            else
                return NotFound();

        }
        public IActionResult Delete(Order _order)
        {
            var deletedOrder = db.Orders.FirstOrDefault(o => o.Id == _order.Id);
            if (deletedOrder != null)
            {
                db.Orders.Remove(deletedOrder);
                db.SaveChanges();
            }
            return RedirectToAction("IndexOrdes");
        }

    }
}