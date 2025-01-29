using Microsoft.Playwright;

namespace monevotechtest.Pages
{
    internal class ApplicationForm
    {
        private readonly IPage page;

        public ApplicationForm(IPage page)
        {
            this.page = page;
        }

        internal async Task Continue() =>
            await page.GetByRole(AriaRole.Button, new() { Name = "Continue" }).ClickAsync();

        internal async Task LoanValue(string loanValue)
        {
            await page.GetByPlaceholder("£1,000 to £").FillAsync(loanValue);
            await Continue();
        }

        internal async Task LoanTerm()
        {
            await page.GetByRole(AriaRole.Button, new() { Name = "1 year" }).ClickAsync();
            await page.GetByRole(AriaRole.Button, new() { Name = "Debt consolidation" }).ClickAsync();
            await page.GetByRole(AriaRole.Button, new() { Name = "Mr", Exact = true }).ClickAsync();
            await page.Locator("#firstName").FillAsync("Staurt");
            await page.Locator("#lastName").FillAsync("Minion");
            await Continue();
        }

        internal async Task DateOfBirth()
        {
            await page.Locator("#dateOfBirth").FillAsync("10/01/1980");
            await Continue();
        }

        internal async Task EmailAddress()
        {
            await page.Locator("#emailAddress").FillAsync("stuartminion@gmail.com");
            await Continue();
        }

        internal async Task MobileNumber(string mobileNumber)
        {
            await page.Locator("#mobileNumber").FillAsync(mobileNumber);
            await Continue();
        }

        internal async Task MaritalStatusVisiblity() =>
            await Assertions.Expect(page.GetByRole(AriaRole.Heading, new() { Name = "What’s your marital status?" })).ToBeVisibleAsync();

        internal async Task MobileNumberValidationMessage(bool shouldBeVisible) =>
            await (shouldBeVisible
                ? Assertions.Expect(page.GetByText("Enter a valid UK mobile phone")).ToBeVisibleAsync()
                : Assertions.Expect(page.GetByText("Enter a valid UK mobile phone")).ToBeHiddenAsync());
    }
}