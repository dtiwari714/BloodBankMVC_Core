using BloodBankProjectMVCCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BloodBankProjectMVCCore.Controllers
{
    public class StockController : Controller
    {
        StockModel new_Stock = new StockModel();
        private DataBaseContext _dataBaseContext;
        public StockController(DataBaseContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;
        }
        public IActionResult Index()
        {
            new_Stock = new StockModel();
            List<StockModel> lst = new_Stock.getData();
            return View(lst);
        }
        public IActionResult CreateStock()
        {
            var BlodTypeList = (from BloodType in _dataBaseContext.BloodType
                                select new SelectListItem()
                             {
                                 Text = BloodType.BloodGroup,
                                 Value = BloodType.BloodTypeID.ToString()
                             }).ToList();
            BlodTypeList.Insert(0, new SelectListItem()
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
            ViewBag.ListOfBloodType = BlodTypeList;
            ViewBag.ListOfBloodBank = BloodBankList;
            return View();
        }
        [HttpPost]
        public IActionResult CreateStock(StockModel newStock)
        {
            
                bool res;
                new_Stock = new StockModel();
                res = new_Stock.insert(newStock);
                return RedirectToAction(nameof(Index));
            
        }
        [HttpGet]
        public IActionResult EditStock(string id)
        {
            StockModel NewStock = new_Stock.getData(id);
            var BlodTypeList = (from BloodType in _dataBaseContext.BloodType
                                select new SelectListItem()
                                {
                                    Text = BloodType.BloodGroup,
                                    Value = BloodType.BloodTypeID.ToString()
                                }).ToList();
            BlodTypeList.Insert(0, new SelectListItem()
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
            ViewBag.ListOfBloodType = BlodTypeList;
            ViewBag.ListOfBloodBank = BloodBankList;
            return View(NewStock);
        }
        [HttpPost]
        public IActionResult EditStock(StockModel stock_new)
        {
            
                bool result;
                new_Stock = new StockModel();
                result = new_Stock.update(stock_new);
                return RedirectToAction(nameof(Index));
            

        }
        [HttpGet]
        public IActionResult DeleteStock(string id)
        {
            StockModel oldDonor = new_Stock.getData(id);
            return View(oldDonor);
        }
        [HttpPost]
        public IActionResult DeleteStock(StockModel stock_new)
        {

            bool res;
            new_Stock = new StockModel();
            res = new_Stock.delete(stock_new);

            return RedirectToAction(nameof(Index));

        }
    }
}
