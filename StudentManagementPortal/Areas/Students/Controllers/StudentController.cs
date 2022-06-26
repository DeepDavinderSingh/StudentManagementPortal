using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentManagement.DataAccessLayer.Repository.IRepository;
using StudentManagement.Model;

namespace StudentManagementPortal.Areas.Students.Controllers
{
    [Area("Students")]
    public class StudentController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public StudentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            IEnumerable<Student> objStudentList = _unitOfWork.Student.GetAll();
            return View(objStudentList);
        }

        public IActionResult GetDetails(long id)
        {
            var objStudentList = _unitOfWork.Student.GetAll().Where(x => x.Id == id);
            return View(objStudentList);
        }

        //GET
        public IActionResult AddStudent()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddStudent(Student _student)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Student.Add(_student);
                _unitOfWork.Save();
                TempData["success"] = "Student Added successfully!!";
                return RedirectToAction("Index");
            }
            return View(_student);
        }

        //GET
        public IActionResult EditStudent(long? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            //var studentFromDb = _dbContext.Students.Find(id);
            var studentFromDb = _unitOfWork.Student.GetFirstOrDefault(x => x.Id == id);

            if (studentFromDb == null)
            {
                return NotFound();
            }
            return View(studentFromDb);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditStudent(Student _student)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Student.Update(_student);
                _unitOfWork.Save();
                TempData["success"] = "Student Updated successfully!!";
                return RedirectToAction("Index");
            }
            return View(_student);
        }

        //GET
        public IActionResult DeleteStudent(long? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            //var studentFromDb = _dbContext.Students.Find(id);
            var studentFromDb = _unitOfWork.Student.GetFirstOrDefault(x => x.Id == id);

            if (studentFromDb == null)
            {
                return NotFound();
            }
            return View(studentFromDb);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(long? id)
        {
            //var studentFromDb = _dbContext.Students.Find(id);
            var studentFromDb = _unitOfWork.Student.GetFirstOrDefault(x => x.Id == id);

            if (studentFromDb == null)
            {
                return NotFound();
            }
            _unitOfWork.Student.Remove(studentFromDb);
            _unitOfWork.Save();
            TempData["success"] = "Student Deleted successfully!!";
            return RedirectToAction("Index");
        }
    }
}
