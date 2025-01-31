# Overview
This repository contains two tests for verifying the phone number input field in an application form on the Monevo website. Each entry is incremental.

The tests validate both a valid UK mobile number and an invalid UK mobile number.

The tests do not proceed beyond the Marital Status stage of the application process.

# How to Run the Tests
## Option 1 - Via Viusal Studio
1. [Clone the repository](https://github.com/MarkTheTestStrategist/MonevoTechTest)
1. Open the solution in Visual Studio
1. Open Test Explorer from the Test menu or use shortcut `Ctrl+E, T`
1. Click the play button to run all of the tests. Alternatively, you can run each test individually by clicking the play button next to the test name.

## Option 2 - Via PowerShell
1. [Clone the repository](https://github.com/MarkTheTestStrategist/MonevoTechTest)
1. Enter the following on the CMD line:

     `dotnet test`

1. To run tests in headed mode, use:

    `$env:HEADED="1"`
    
    `dotnet test`

1. To run tests in headed mode with a specific browser, use:

    `$env:HEADED="1" $env:BROWSER="firefox" dotnet test`

1. To run tests on different browsers:

    `$env:BROWSER="webkit"`

    `dotnet test`

       
> Note: Ensure you have the .NET SDK installed and the necessary dependencies restored before running the tests.

You can also run from the CMD line as well. 

For further reading and instructions, visit Playwright [Running and Debugging Tests](https://playwright.dev/dotnet/docs/intro#running-and-debugging-tests)

    

# Tracer
Code has been added to run a trace every time a test is executed. This is extremely useful for debugging issues and allows you to view images of each page visited.

# Codegen
A file named `runCodegen.ps1` is included to run the codegen command.

> Playwright can generate tests as you perform actions in the browser, making it a great way to quickly start testing. Playwright will analyze your page and determine the best locator, prioritizing role, text, and test ID locators. If multiple elements match the locator, it will refine the locator to uniquely identify the target element.

For further reading on Codegen, visit: [Playwright Codegen Documentation](https://playwright.dev/dotnet/docs/codegen)
