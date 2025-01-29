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

            await SetupParameters.AddTracer(Page);
        }

        [TearDown]
        public async Task Teardown()
        {
            await SetupParameters.StopTracer(Page);

            await Page.CloseAsync();
            await Context.CloseAsync();
            await Browser.CloseAsync();
        }

        [Test]
        [Description("Check application form accepts a valid mobile number")]
        public async Task ValidMobileNumber()
        {
            await Navigate.ApplicationForm(Page);
            await Cookies.AcceptAllCookies(Page);
            await ApplicationForm.LoanValue(Page, "10000");
            await ApplicationForm.LoanTerm(Page);
            await ApplicationForm.DateOfBirth(Page);
            await ApplicationForm.EmailAddress(Page);

            // The mobile number you provided was not accepted as a valid number : 07897641544
            // I have had to use an existing phone number, as even using the TV & Film (e.g. 07700901126) number invokes validation.
            await ApplicationForm.PhoneNumber(Page, "07974905111");
            await ApplicationForm.MaritalStatusVisiblity(Page);
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
            await ApplicationForm.PhoneNumber(Page, "310-323-258");
            await ApplicationForm.PhoneNumberValidationMessage(Page);
        }
    }
}
