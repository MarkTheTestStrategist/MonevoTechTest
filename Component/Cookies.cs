using Microsoft.Playwright;

namespace monevotechtest.Component
{
    internal static class Cookies
    {
        internal static async Task AcceptAllCookies(IPage page)
        {
            if (page == null)
            {
                throw new ArgumentNullException(nameof(page));
            }

            try
            {
                await Task.Delay(1000);

                var isCookieVisible = await page.GetByRole(AriaRole.Heading, new() { Name = "Cookies", Exact = true }).IsVisibleAsync();

                if (!isCookieVisible)
                {
                    return;
                }

                await page.GetByRole(AriaRole.Button, new() { Name = "Accept All Cookies" }).ClickAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}