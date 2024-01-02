using Microsoft.AspNetCore.Mvc;
using VABookWeb.Data;
using VABookWeb.Models;

namespace VABookWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        #region DataBase
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Category> objCategorise=_db.Categories;
            return View(objCategorise);
        }
        #endregion
        #region Create
        //Get
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if (obj.Name==obj.Displayorder.ToString())
            {
                ModelState.AddModelError("name", "They Can not be at the same with each other");

            }
            if (ModelState.IsValid) { 
            _db.Categories.Add(obj);
            _db.SaveChanges();
                TempData["success"] = "create successfully";
            return RedirectToAction("Index");
                                                }
            return View(obj);   
        }
        #endregion
        #region Edit
        public IActionResult Edit(int ? Id)
        {
            if(Id== null || Id == 0)
            {
                return NotFound();
            }
            var CategoryFromDb = _db.Categories.Find(Id);
            if (CategoryFromDb == null)
            {
                return NotFound();
            }
            return View(CategoryFromDb);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (obj.Name == obj.Displayorder.ToString())
            {
                ModelState.AddModelError("name", "They Can not be at the same with each other");

            }
            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Edit successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        #endregion
        #region Delete
        public IActionResult Delete(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var CategoryFromDb = _db.Categories.Find(Id);
            if (CategoryFromDb == null)
            {
                return NotFound();
            }
            return View(CategoryFromDb);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj=_db.Categories.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Remove(obj);
                _db.SaveChanges();
                TempData["success"] = "Delete successfully";
                return RedirectToAction("Index");
            }

            return View(obj);
        }
        #endregion
    }
}
