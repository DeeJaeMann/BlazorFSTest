using System.Text.RegularExpressions;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using BlazorFS.Test.Infrastructure;

namespace BlazorFS.Test;

[TestFixture]
public class CounterTests : BlazorTest
{
    [Test]
    public async Task Counter_Page_Has_Heading()
    {
        // Uncomment this when using headed mode to debug test
        //await Page.PauseAsync();

        await Page.GotoAsync(RootUri.AbsoluteUri, new() { WaitUntil = WaitUntilState.NetworkIdle });
        await Page.GetByRole(AriaRole.Link, new() { Name = "Counter" }).ClickAsync();
        await Expect(Page.GetByRole(AriaRole.Heading)).ToHaveTextAsync("Counter");
    }
    [Test]
    public async Task Count_Increments_When_Button_Is_Clicked()
    {
        // Uncomment this when using headed mode to debug test
        //await Page.PauseAsync();

        await Page.GotoAsync(RootUri.AbsoluteUri, new() { WaitUntil = WaitUntilState.NetworkIdle });
        await Page.GetByRole(AriaRole.Link, new() { Name = "Counter" }).ClickAsync();
        await Page.GetByRole(AriaRole.Button, new() { Name = "Click me" }).ClickAsync();
        // This is intermittantly failing
        // It seems that there may need to be an increase in the delay before checking
        // adding a Pause.Async() only passes some of the time so that is not the correct solution
        await Expect(Page.GetByRole(AriaRole.Status)).ToHaveTextAsync("Current count: 1");
    }
}