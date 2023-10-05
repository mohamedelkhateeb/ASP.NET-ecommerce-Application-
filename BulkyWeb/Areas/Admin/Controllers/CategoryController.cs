using Bulky.DataAccess.Repository.IRepository;
using BulkyWeb.Data;
using BulkyWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            var categoryData = _unitOfWork.CategoryRepository.All();
            return View(categoryData);
        }
        //Create
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category obj)
        {
            //Validation Before Adding To the Database
            if (ModelState.IsValid)
            {
                //_db.Categories.Add(obj);
                _unitOfWork.CategoryRepository.Add(obj);
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View();
        }
        //Update
        public IActionResult Edit(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Category? category = _unitOfWork.CategoryRepository.GetById(id);

            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }
        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            //Validation Before Adding To the Database
            if (ModelState.IsValid)
            {
                _unitOfWork.CategoryRepository.Update(obj);
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View();
        }
        //Delete
        public IActionResult Delete(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Category? category = _unitOfWork.CategoryRepository.GetById(id);

            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int id)
        {
            var obj = _unitOfWork.CategoryRepository.GetById(id);

            _unitOfWork.CategoryRepository.Remove(obj);
            _unitOfWork.Save();

            return RedirectToAction("Index");
        }
    }
}
