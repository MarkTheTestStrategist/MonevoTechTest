using Microsoft.Playwright;

namespace monevotechtest.HelperFiles
{
    internal static class ApplicationForm
    {
        internal static async Task Continue(IPage Page) =>
            await Page.GetByRole(AriaRole.Button, new() { Name = "Continue" }).ClickAsync();

        internal static async Task LoanValue(IPage Page, string loanValue)
        {
            await Page.GetByRole(AriaRole.Textbox).ClickAsync();
            await Page.GetByPlaceholder("£1,000 to £").FillAsync(loanValue);
            await Continue(Page);
        }

        internal static async Task LoanTerm(IPage Page)
        {
            await Page.GetByRole(AriaRole.Button, new() { Name = "1 year" }).ClickAsync();
            await Page.GetByRole(AriaRole.Button, new() { Name = "Debt consolidation" }).ClickAsync();
            await Page.GetByRole(AriaRole.Button, new() { Name = "Mr", Exact = true }).ClickAsync();
            await Page.Locator("#firstName").ClickAsync();
            await Page.Locator("#firstName").FillAsync("Staurt");
            await Page.Locator("#lastName").ClickAsync();
            await Page.Locator("#lastName").FillAsync("Minion");
            await Continue(Page);
        }

        internal static async Task DateOfBirth(IPage Page)
        {
            await Page.Locator("#dateOfBirth").FillAsync("10/01/1980");
            await Continue(Page);
        }

        internal static async Task EmailAddress(IPage Page)
        {
            await Page.Locator("#emailAddress").FillAsync("stuartminion@gmail.com");
            await Continue(Page);
        }

        internal static async Task MobileNumber(IPage Page, string mobileNumber)
        {
            await Page.Locator("#mobileNumber").FillAsync(mobileNumber);
            await Continue(Page);
        }

        internal static async Task MaritalStatusVisiblity(IPage Page) =>
            await Assertions.Expect(Page.GetByRole(AriaRole.Heading, new() { Name = "What’s your marital status?" })).ToBeVisibleAsync();

        internal static async Task MobileNumberValidationMessage(IPage Page, bool shouldBeVisible) =>
            await (shouldBeVisible
                ? Assertions.Expect(Page.GetByText("Enter a valid UK mobile phone")).ToBeVisibleAsync()
                : Assertions.Expect(Page.GetByText("Enter a valid UK mobile phone")).ToBeHiddenAsync());
    }
}