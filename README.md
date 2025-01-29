# Overview
This repository contains two tests for verifying the phone number input field in an application form on the Monevo website. Each entry is incremental.

The tests validate both a valid UK mobile number and an invalid UK mobile number.

The tests do not proceed beyond the Marital Status stage of the application process.

# Tracer
Code has been added to run a trace every time a test is executed. This is extremely useful for debugging issues and allows you to view images of each page visited.

# Codegen
A file named `runCodegen.ps1` is included to run the codegen command.

> Playwright can generate tests as you perform actions in the browser, making it a great way to quickly start testing. Playwright will analyze your page and determine the best locator, prioritizing role, text, and test ID locators. If multiple elements match the locator, it will refine the locator to uniquely identify the target element.

For further reading on Codegen, visit: [Playwright Codegen Documentation](https://playwright.dev/dotnet/docs/codegen)
