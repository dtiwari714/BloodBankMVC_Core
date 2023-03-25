using BloodBankProjectMVCCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BloodBankProjectMVCCore.Controllers
{
    public class BloodBankController : Controller
    {
        BloodBankModel new_bloodBank = new BloodBankModel();
        public IActionResult Index()
        {
            new_bloodBank = new BloodBankModel();
            List<BloodBankModel> listOfBloodBank= new_bloodBank.getData();
            return View(listOfBloodBank);
        }
        public IActionResult CreateBloodBank()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateBloodBank(BloodBankModel newBB)
        {
            if (ModelState.IsValid)
            {
                bool res;
                new_bloodBank = new BloodBankModel();
                res = new_bloodBank.insert(newBB);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        public IActionResult UpdateBloodBank(string? id)
        {
            BloodBankModel NewBB = new_bloodBank.getData(id);
            return View(NewBB);
        }
        [HttpPost]
        public IActionResult UpdateBloodBank(BloodBankModel NewBB)
        {
            if (ModelState.IsValid)
            {
                bool result;
                new_bloodBank = new BloodBankModel();
                result = new_bloodBank.update(NewBB);
                return RedirectToAction(nameof(Index));
           }
            return View(NewBB);
        }
        [HttpGet]
        public IActionResult DeleteDonor(string id)
        {
            BloodBankModel oldDonor = new_bloodBank.getData(id);
            return View(oldDonor);
        }
        [HttpPost]
        public IActionResult DeleteDonor(BloodBankModel newBB)
        {

            bool res;
            new_bloodBank = new BloodBankModel();
            res = new_bloodBank.delete(newBB);

            return RedirectToAction(nameof(Index));

        }
    }
}
