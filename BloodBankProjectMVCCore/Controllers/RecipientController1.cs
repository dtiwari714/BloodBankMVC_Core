using BloodBankProjectMVCCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BloodBankProjectMVCCore.Controllers
{
    public class RecipientController1 : Controller
    {
        private DataBaseContext _dataBaseContext;
        public RecipientController1(DataBaseContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;
        }
        RecipientModel new_Recipient = new RecipientModel();
        public IActionResult Index()
        {
            new_Recipient = new RecipientModel();
            List<RecipientModel> lst = new_Recipient.getData();
            return View(lst);
        }
        public IActionResult CreateRecipient()
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
            ViewBag.ListOfUser = UserList;
            return View();
        }
        [HttpPost]
        public IActionResult CreateRecipient(RecipientModel newRecipent)
        {
            if (ModelState.IsValid)
            {
                bool res;
                new_Recipient = new RecipientModel();
                res = new_Recipient.insert(newRecipent);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        public IActionResult EditRecipient(string id)
        {
            RecipientModel NewDonor = new_Recipient.getData(id);
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
            ViewBag.ListOfUse = UserList;
            return View(NewDonor);
        }
        [HttpPost]
        public IActionResult EditRecipient(RecipientModel rec)
        {
            if (ModelState.IsValid)
            {
                bool result;
                new_Recipient = new RecipientModel();
                result = new_Recipient.update(rec);
                return RedirectToAction(nameof(Index));
            }
            return View(rec);

        }
        [HttpGet]
        public IActionResult DeleteRecipient(string id)
        {
            RecipientModel oldrecipent = new_Recipient.getData(id);
            return View(oldrecipent);
        }
        [HttpPost]
        public IActionResult DeleteRecipient(RecipientModel recipent_new)
        {
            bool res;
            new_Recipient = new RecipientModel();
            res = new_Recipient.delete(recipent_new);
            return RedirectToAction(nameof(Index));
        }
    }
}
