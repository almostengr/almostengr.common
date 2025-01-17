using Almostengr.Common.OperationResult;

namespace Almostengr.Common.Tests;

public class ResultTest
{
    [Fact]
    public void TestSuccess()
    {
        string testingEnttiy = "entity correct";

        Result<string> result = Result<string>.Success(testingEnttiy);

        Assert.Equal("entity correct", result.Entity);
    }

    [Fact]
    public void TestException()
    {
        Exception exception = new Exception("I just threw an exception");

        Result<string> result = Result<string>.Failure(exception);

        Assert.Single(result.Errors);
    }
}