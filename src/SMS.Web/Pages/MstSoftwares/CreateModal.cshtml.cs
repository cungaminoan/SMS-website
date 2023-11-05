using Microsoft.AspNetCore.Mvc;
using SMS.MstSoftwares;
using System.Threading.Tasks;

namespace SMS.Web.Pages.MstSoftwares
{
    public class CreateModalModel : SMSPageModel
    {
        
        [BindProperty]
        public CreateUpdateMstSoftwareDto MstSoftware { get; set; }
        private readonly IMstSoftwareService _MstSoftwareService;
        public CreateModalModel(IMstSoftwareService mstSoftwareService)
        {
            _MstSoftwareService = mstSoftwareService;
        }
        public void OnGet()
        {
            MstSoftware = new CreateUpdateMstSoftwareDto();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _MstSoftwareService.CreateAsync(MstSoftware);
            return NoContent();
        }
    }
    
}
