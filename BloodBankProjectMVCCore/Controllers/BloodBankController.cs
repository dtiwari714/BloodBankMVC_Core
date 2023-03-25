using BloodBankProjectMVCCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace BloodBankProjectMVCCore.Controllers
{
    public class BloodBankController : Controller
    {
        BloodBankModel bloodbankObj = new BloodBankModel();
        public IActionResult Index()
        {
            bloodbankObj = new BloodBankModel();
            List<BloodBankModel> lst = bloodbankObj.getData();
            return View(lst);
        }
        public IActionResult AddBloodBank()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddBloodBank(BloodBankModel blood)
        {
            bool res;
            //if (ModelState.IsValid)
            //{
            bloodbankObj = new BloodBankModel();
            res = bloodbankObj.insert(blood);
            if (res)
            {
                TempData["msg"] = "Added successfully";
            }
            //}
            else
            {
                TempData["msg"] = "Not Added. something went wrong..!!";
            }
            return View();
        }
        [HttpGet]
        public IActionResult EditBloodBannk(string id)
        {
            BloodBankModel emp = bloodbankObj.getData(id);
            return View(emp);
        }
    }
}
