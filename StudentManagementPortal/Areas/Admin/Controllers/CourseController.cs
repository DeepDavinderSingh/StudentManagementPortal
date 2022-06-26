using Microsoft.AspNetCore.Mvc;
using StudentManagement.DataAccessLayer.Repository.IRepository;
using StudentManagement.Model;

namespace StudentManagementPortal.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CourseController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CourseController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<Course> objCourseList = _unitOfWork.Course.GetAll();
            return View(objCourseList);
        }

        //GET
        public IActionResult AddCourse()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddCourse(Course _course)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Course.Add(_course);
                _unitOfWork.Save();
                TempData["success"] = "Course Added successfully!!";
                return RedirectToAction("Index");
            }
            return View(_course);
        }

        //GET
        public IActionResult EditCourse(long? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            //var courseFromDb = _dbContext.Courses.Find(id);
            var courseFromDb = _unitOfWork.Course.GetFirstOrDefault(x => x.Id == id);

            if (courseFromDb == null)
            {
                return NotFound();
            }
            return View(courseFromDb);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditCourse(Course _course)
        {
            //if (obj.Name == obj.DisplayOrder.ToString())
            //{
            //    ModelState.AddModelError("Name", "The DisplayOrder cannot exactly match the name");
            //}
            if (ModelState.IsValid)
            {
                _unitOfWork.Course.Update(_course);
                _unitOfWork.Save();
                TempData["success"] = "Course Updated successfully!!";
                return RedirectToAction("Index");
            }
            return View(_course);
        }


        //GET
        public IActionResult DeleteCourse(long? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            //var courseFromDb = _dbContext.Courses.Find(id);
            var courseFromDb = _unitOfWork.Course.GetFirstOrDefault(x => x.Id == id);


            if (courseFromDb == null)
            {
                return NotFound();
            }
            return View(courseFromDb);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(long? id)
        {
            //var courseFromDb=_dbContext.GetFirstOrDefault(x=>x.Id== id);    
            var courseFromDb = _unitOfWork.Course.GetFirstOrDefault(x => x.Id == id);

            if (courseFromDb == null)
            {
                return NotFound();
            }
            _unitOfWork.Course.Remove(courseFromDb);
            _unitOfWork.Save();
            TempData["success"] = "Course Deleted successfully!!";
            return RedirectToAction("Index");
        }
    }
}
