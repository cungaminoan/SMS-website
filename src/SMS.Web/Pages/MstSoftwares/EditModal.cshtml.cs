using Microsoft.AspNetCore.Mvc;
using SMS.MstSoftwares;
using System.Threading.Tasks;

namespace SMS.Web.Pages.MstSoftwares
{
    public class EditModalModel : SMSPageModel
    {
        [HiddenInput]
        [BindProperty]
        public int Id { get; set; }
        [BindProperty(SupportsGet = true)]
        public CreateUpdateMstSoftwareDto MstSoftware { get; set; }
        private readonly IMstSoftwareService _mstSoftwareService;
        public EditModalModel(IMstSoftwareService mstSoftwareService)
        {
            _mstSoftwareService = mstSoftwareService;
        }
        public async Task OnGetAsync()
        {
            var mstSoftwareDto = await _mstSoftwareService.GetAsync(Id);
            MstSoftware = ObjectMapper.Map<MstSoftwareDto, CreateUpdateMstSoftwareDto>(mstSoftwareDto);
        }
        public async Task<IActionResult> OnPostAsync()
        {
            await _mstSoftwareService.UpdateAsync(Id, MstSoftware);
            return NoContent();
        }
    }
}
