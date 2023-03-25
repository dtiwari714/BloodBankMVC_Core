using BloodBankProjectMVCCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BloodBankProjectMVCCore.Controllers
{
    public class StaffController : Controller
    {
        private DataBaseContext _dataBaseContext;
        public StaffController(DataBaseContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;
        }
        StaffModel new_staff = new StaffModel();
        public IActionResult Index()
        {
            new_staff = new StaffModel();
            List<StaffModel> lst = new_staff.getData();
            return View(lst);
        }
        public IActionResult CreateStaff()
        {
            var UserList = (from User in _dataBaseContext.User
                             select new SelectListItem()
                             {
                                 Text = User.Name,
                                 Value = User.UserId.ToString()
                             }).ToList();
            UserList.Insert(0, new SelectListItem()
            {
                Text = "___Select___",
                Value = string.Empty
            });
            var BloodBankList = (from BloodBank in _dataBaseContext.BloodBank
                                 select new SelectListItem()
                                 {
                                     Text = BloodBank.BloodBankName,
                                     Value = BloodBank.BloodBankID.ToString()
                                 }).ToList();
            BloodBankList.Insert(0, new SelectListItem()
            {
                Text = "___Select___",
                Value = string.Empty
            });
            ViewBag.ListOfBloodBank = BloodBankList;
            ViewBag.ListOfUser = UserList;
            return View();
        }
        [HttpPost]
        public IActionResult CreateStaff(StaffModel newStaff)
        {
            
                bool res;
                new_staff = new StaffModel();
                res = new_staff.insert(newStaff);
                return RedirectToAction(nameof(Index));
            
        }
        [HttpGet]
        public IActionResult EditStaff(string id)
        {
            StaffModel NewStaff = new_staff.getData(id);
            var UserList = (from User in _dataBaseContext.User
                            select new SelectListItem()
                            {
                                Text = User.Name,
                                Value = User.UserId.ToString()
                            }).ToList();
            UserList.Insert(0, new SelectListItem()
            {
                Text = "___Select___",
                Value = string.Empty
            });
            var BloodBankList = (from BloodBank in _dataBaseContext.BloodBank
                                 select new SelectListItem()
                                 {
                                     Text = BloodBank.BloodBankName,
                                     Value = BloodBank.BloodBankID.ToString()
                                 }).ToList();
            BloodBankList.Insert(0, new SelectListItem()
            {
                Text = "___Select___",
                Value = string.Empty
            });
            ViewBag.ListOfBloodBank = BloodBankList;
            ViewBag.ListOfUser = UserList;
            return View(NewStaff);
        }
        [HttpPost]
        public IActionResult EditStaff(StaffModel newStaff)
        {
            
                bool result;
                new_staff = new StaffModel();
                result = new_staff.update(newStaff);
                return RedirectToAction(nameof(Index));
            
        }
        [HttpGet]
        public IActionResult DeleteStaff(string id)
        {
            StaffModel oldDonor = new_staff.getData(id);
            return View(oldDonor);
        }
        [HttpPost]
        public IActionResult DeleteStaff(StaffModel newStaff)
        {

            bool res;
            new_staff = new StaffModel();
            res = new_staff.delete(newStaff);

            return RedirectToAction(nameof(Index));

        }
    }
}
