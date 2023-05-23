
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TMS.Context;
using TMS.Interface;
using TMS.Models;

namespace TMS.Controllers
{
    public class RequestController : Controller
    {
        private readonly MyDBContext _db;
        private readonly IRequest _irq;
        private readonly IUser _user;
        private readonly IBatch _batch;

        public RequestController(MyDBContext db, IRequest irq, IBatch batch, IUser user)
        {
            _user = user;
            _batch = batch;
            _db = db;
            _irq = irq;
        }

        public IActionResult Index()
        {
            return View(_irq.GetReqData());
        }

        public IActionResult IndexManager()
        {
            return View(_irq.GetReqData());
        }

        public IActionResult IndexE()
        {
            return View(_irq.GetReqData());
        }

        public IActionResult IndexEmployee()
        {
            ViewData["Batches"] = new SelectList(_batch.GetBatch(), "BatchId", "BatchName");
            ViewData["Users"] = new SelectList(_user.GetUser(), "UId", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult IndexEmployee(Request request)
        {
            _irq.Create(request);
            return RedirectToAction("IndexE");
        }

        public IActionResult Create()
        {
            ViewData["Batches"] = new SelectList(_batch.GetBatch(), "BatchId", "BatchName");
            ViewData["Users"] = new SelectList(_user.GetUser(), "UId", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Request request)
        { 
               _irq.Create(request);
            return RedirectToAction("Index");
        }

        public IActionResult Accept(int id)
        {
            _irq.Accept(id);
            return RedirectToAction("Index");
        }

        public IActionResult Reject(int id)
        {
            _irq.Reject(id);
            return RedirectToAction("Index");
        }

        public IActionResult Set()
        {
            return View();
        }

    }
}
