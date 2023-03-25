using Microsoft.AspNetCore.Mvc.Rendering;

namespace BloodBankProjectMVCCore.Models
{
    public class UserViewModel
    {
        public String UserId { get; set; }
        public List<SelectListItem> ListOfUser { get; set; }
    }
}
