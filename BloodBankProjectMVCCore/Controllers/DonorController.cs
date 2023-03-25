using BloodBankProjectMVCCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BloodBankProjectMVCCore.Controllers
{
    public class DonorController : Controller
    {
        private DataBaseContext _dataBaseContext;
        public DonorController(DataBaseContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;
        }
        DonorModel new_donor = new DonorModel();
        public IActionResult Index()
        {
            new_donor = new DonorModel();
            List<DonorModel> lst = new_donor.getData();
            return View(lst);
        }
        public IActionResult CreateDonor()
        {
            var DonorList = (from User in _dataBaseContext.User
                             select new SelectListItem()
                             {
                                 Text = User.Name,
                                 Value = User.UserId.ToString()
                             }).ToList();
            DonorList.Insert(0, new SelectListItem()
            {
                Text = "___Select___",
                Value = string.Empty
            });
            var BloodTypeList = (from BloodType in _dataBaseContext.BloodType
                                 select new SelectListItem()
                             {
                                 Text = BloodType.BloodGroup,
                                 Value = BloodType.BloodTypeID.ToString()
                             }).ToList();
            BloodTypeList.Insert(0, new SelectListItem()
            {
                Text = "___Select___",
                Value = string.Empty
            });
            ViewBag.ListOfBloodType = BloodTypeList;
            ViewBag.ListOfUser = DonorList;
            return View();
        }
        [HttpPost]
        public IActionResult CreateDonor(DonorModel newdonor)
        {
            if (ModelState.IsValid)
            {
                bool res;
                new_donor = new DonorModel();
                res = new_donor.insert(newdonor);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        [HttpGet]
        public IActionResult EditDonor(string id)
        {
            DonorModel NewDonor = new_donor.getData(id);
            var DonorList = (from User in _dataBaseContext.User
                             select new SelectListItem()
                             {
                                 Text = User.Name,
                                 Value = User.UserId.ToString()
                             }).ToList();
            DonorList.Insert(0, new SelectListItem()
            {
                Text = "___Select___",
                Value = string.Empty
            });
            ViewBag.ListOfUse = DonorList;
            return View(NewDonor);
        }
        [HttpPost]
        public IActionResult EditDonor(DonorModel donor_new)
        {
            if (ModelState.IsValid)
            {
                bool result;
                new_donor = new DonorModel();
                result = new_donor.update(donor_new);
                return RedirectToAction(nameof(Index));
            }
            return View(donor_new);
            
        }
        [HttpGet]
        public IActionResult DeleteDonor(string id)
        {
            DonorModel oldDonor = new_donor.getData(id);
            return View(oldDonor);
        }
        [HttpPost]
        public IActionResult DeleteDonor(DonorModel donor_new)
        {
            
                bool res;
                new_donor = new DonorModel();
                res = new_donor.delete(donor_new);

                return RedirectToAction(nameof(Index));
            
        }

    }
}
