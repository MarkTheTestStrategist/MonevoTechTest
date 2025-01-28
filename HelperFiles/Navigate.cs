using Microsoft.Playwright;

namespace monevotechtest.HelperFiles
{
    internal class Navigate
    {
        internal static async Task ApplicationForm(IPage page) =>
            await page.GotoAsync("https://money.monevo.co.uk/");
    }
}