using BlazorFS.Access;

namespace BlazorFS.Test.Access;

internal class TestService : IExampleService
{
    public string GetMessage() => "This is a test message";
}