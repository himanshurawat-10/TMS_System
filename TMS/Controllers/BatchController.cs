using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TMS.Interface;
using TMS.Models;

namespace TMS.Controllers
{
    public class BatchController : Controller
    {
        
            IBatch _repo;
            ICourse _repo1;
            public BatchController(IBatch repo, ICourse repo1)
            {
                _repo = repo;
                _repo1 = repo1;
            }
            public IActionResult Index()
            {
                return View(_repo.GetBatches());
            }
            public IActionResult Details(int id)
            {
                return View(_repo.GetBatchById(id));
            }
            public IActionResult Edit(int id)
            {
            ViewData["Courses"] = new SelectList(_repo1.GetCourses(), "CourseId", "CourseName");
            Batch obj = _repo.GetBatchById(id);
                return View(obj);
            }
            [HttpPost]
            public IActionResult Edit(int id, Batch batch)
            {
                _repo.Edit(id, batch);
                return RedirectToAction("index");
            }
            public IActionResult Create()
            {
                ViewData["Courses"] = new SelectList(_repo1.GetCourses(), "CourseId", "CourseName");

                return View();
            }
            [HttpPost]
            public IActionResult Create(Batch batch)
            {
                _repo.Create(batch);
                return RedirectToAction("index");
            }

        }
    }
