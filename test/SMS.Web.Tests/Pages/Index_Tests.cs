using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace SMS.Pages;

public class Index_Tests : SMSWebTestBase
{
    [Fact]
    public async Task Welcome_Page()
    {
        var response = await GetResponseAsStringAsync("/");
        response.ShouldNotBeNull();
    }
}
