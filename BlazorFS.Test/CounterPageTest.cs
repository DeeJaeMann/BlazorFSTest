using System.Text.RegularExpressions;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using BlazorFS.Test.Infrastructure;

namespace BlazorFS.Test;

[TestFixture]
public class CounterTests : BlazorTest
{
    [Test]
    public async Task Count_Increments_When_Button_Is_Clicked()
    {
        //await Page.PauseAsync();

        await Page.GotoAsync(RootUri.AbsoluteUri, new() { WaitUntil = WaitUntilState.NetworkIdle });
        await Page.GetByRole(AriaRole.Link, new() { Name = "Counter" }).ClickAsync();
        await Page.GetByRole(AriaRole.Button, new() { Name = "Click me" }).ClickAsync();
        // The test was checking before the button had updated.
        // The correct style of call needs to be made here
        await Page.PauseAsync();
        await Expect(Page.GetByRole(AriaRole.Status)).ToHaveTextAsync("Current count: 1");
    }
}