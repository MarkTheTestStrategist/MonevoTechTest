using Microsoft.Playwright;

namespace monevotechtest.Pages
{
    internal static class ApplicationForm
    {
        //private static IPage? page;
        //internal static void Initialize(IPage pageInstance) => 
        //    page = pageInstance;

        internal static async Task Continue(IPage page) =>
            await page.GetByRole(AriaRole.Button, new() { Name = "Continue" }).ClickAsync();

        internal static async Task LoanValue(IPage page, string loanValue)
        {
            await page.GetByRole(AriaRole.Textbox).ClickAsync();
            await page.GetByPlaceholder("£1,000 to £").FillAsync(loanValue);
            await Continue(page);
        }

        internal static async Task LoanTerm(IPage page)
        {
            await page.GetByRole(AriaRole.Button, new() { Name = "1 year" }).ClickAsync();
            await page.GetByRole(AriaRole.Button, new() { Name = "Debt consolidation" }).ClickAsync();
            await page.GetByRole(AriaRole.Button, new() { Name = "Mr", Exact = true }).ClickAsync();
            await page.Locator("#firstName").FillAsync("Staurt");
            await page.Locator("#lastName").FillAsync("Minion");
            await Continue(page);
        }

        internal static async Task DateOfBirth(IPage page)
        {
            await page.Locator("#dateOfBirth").FillAsync("10/01/1980");
            await Continue(page);
        }

        internal static async Task EmailAddress(IPage page)
        {
            await page.Locator("#emailAddress").FillAsync("stuartminion@gmail.com");
            await Continue(page);
        }

        internal static async Task MobileNumber(IPage page, string mobileNumber)
        {
            await page.Locator("#mobileNumber").FillAsync(mobileNumber);
            await Continue(page);
        }

        internal static async Task MaritalStatusVisiblity(IPage page) =>
            await Assertions.Expect(page.GetByRole(AriaRole.Heading, new() { Name = "What’s your marital status?" })).ToBeVisibleAsync();

        internal static async Task MobileNumberValidationMessage(IPage page, bool shouldBeVisible) =>
            await (shouldBeVisible
                ? Assertions.Expect(page.GetByText("Enter a valid UK mobile phone")).ToBeVisibleAsync()
                : Assertions.Expect(page.GetByText("Enter a valid UK mobile phone")).ToBeHiddenAsync());
    }
}