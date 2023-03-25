using BloodBankProjectMVCCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace BloodBankProjectMVCCore.Controllers
{
    public class UserController : Controller
    {
        UserModel new_user = new UserModel();
        public IActionResult Index()
        {
            new_user = new UserModel();
            List<UserModel> listOfUser = new_user.getData();
            return View(listOfUser);
        }
        [HttpGet]
        public IActionResult CreateUser()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateUser(UserModel user)
        {
            if (ModelState.IsValid)
            {
                bool res;
                new_user = new UserModel();
                res = new_user.insert(user);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        [HttpGet]
        public IActionResult UpdateUser(String Id)
        {
            UserModel NewDonor = new_user.getData(Id);
            return View(NewDonor);
        }
        [HttpPost]
        public IActionResult UpdateUser(UserModel user)
        {
            if (ModelState.IsValid)
            {
                bool result;
                new_user = new UserModel();
                result = new_user.update(user);
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }
        [HttpGet]
        public IActionResult DeleteUser(string id)
        {
            UserModel user = new_user.getData(id);
            return View(user);
        }
        [HttpPost]
        public IActionResult DeleteUser(UserModel user)
        {

            bool res;
            new_user = new UserModel();
            res = new_user.delete(user);

            return RedirectToAction(nameof(Index));

        }
    }
}
