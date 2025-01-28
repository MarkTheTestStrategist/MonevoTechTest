using Microsoft.Playwright;

public static class SetupParameters
{
    public static async Task AddTracer(IPage page)
    {
        await page.Context.Tracing.StartAsync(new TracingStartOptions
        {
            Title = $"{TestContext.CurrentContext.Test.ClassName}.{TestContext.CurrentContext.Test.Name}",
            Screenshots = true,
            Snapshots = true,
            Sources = true
        });
    }

    public static async Task StopTracer(IPage page)
    {
        string playwrightTraces = "playwright-traces";
        await page.Context.Tracing.StopAsync(new TracingStopOptions
        {
            Path = Path.Combine(
                TestContext.CurrentContext.WorkDirectory,
                playwrightTraces,
                $"{TestContext.CurrentContext.Test.ClassName}.{TestContext.CurrentContext.Test.Name}.zip"
            )
        });
    }
}