using Microsoft.Playwright;
using monevotechtest.HelperFiles;

namespace monevotechtest.Tests
{
    internal class PhoneInputField
    {
        public required IPage Page { get; set; }

        private IBrowser Browser { get; set; }
        private IBrowserContext Context { get; set; }

        [SetUp]
        public async Task Setup()
        {
            var playwright = await Playwright.CreateAsync();
            Browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false });
            Context = await Browser.NewContextAsync();
            Page = await Context.NewPageAsync();
        }

        [TearDown]
        public async Task Teardown()
        {
            await Page.CloseAsync();
            await Context.CloseAsync();
            await Browser.CloseAsync();
        }

        [Test]
        [Description("Check application form aceepts a valid mobile number")]
        public async Task ValidMobileNumber()
        {
            await Navigate.ApplicationForm(Page);
            await Cookies.AcceptAllCookies(Page);
            await ApplicationForm.LoanValue(Page, "10000");
            await ApplicationForm.LoanTerm(Page);
            await ApplicationForm.DateOfBirth(Page);
            await ApplicationForm.EmailAddress(Page);
            await ApplicationForm.PhoneNumber(Page, true);
            await ApplicationForm.MaritalStatus(Page);
        }

        [Test]
        [Description("Check application form does not accept an invalid mobile number")]
        public async Task InValidMobileNumber()
        {
            await Navigate.ApplicationForm(Page);
            await Cookies.AcceptAllCookies(Page);
            await ApplicationForm.LoanValue(Page, "10000");
            await ApplicationForm.LoanTerm(Page);
            await ApplicationForm.DateOfBirth(Page);
            await ApplicationForm.EmailAddress(Page);
            await ApplicationForm.PhoneNumber(Page, false);
        }
    }
}
