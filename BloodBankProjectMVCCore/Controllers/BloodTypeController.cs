using BloodBankProjectMVCCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace BloodBankProjectMVCCore.Controllers
{
    public class BloodTypeController : Controller
    {
        BloodTypeModel bloodObj = new BloodTypeModel();
        public IActionResult Index()
        {
            bloodObj = new BloodTypeModel();
            List<BloodTypeModel> lst = bloodObj.getData();
            return View(lst);
        }
        public IActionResult AddBloodType()
        {
            return View();
        }
    }
}
