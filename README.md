# Overview
This repo contains two tests for checking the phone number input field in an application form on the Monevo website, where each entry is incremental. 

The tests check for a valid uk mobile number & an invalid uk mobile number.

The tests do not go beyond the Marital Status stage of the application process. 


# Tracer
I have added code that will run a trace everytime the test is run. This is extremely useful for debugging issues and also allows you to view images of each page visited. 


# Codegen
There is a file called `runCodegen.ps1` which will run the codegen command. 

>Playwright comes with the ability to generate tests for you as you perform actions in the browser and is a great way to quickly get started with testing. Playwright will look at your page and figure out the best locator, prioritizing role, text and test id locators. If the generator finds multiple elements matching the locator, it will improve the locator to make it resilient that uniquely identify the target element."

For further reading on Codegen, visit: https://playwright.dev/dotnet/docs/codegen 
