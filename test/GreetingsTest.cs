using TryConsole;

namespace test;

public class GreetingsTest
{
    [Fact]
    public void helloShouldReturnHello() {
        string actual = new Greetings("Sam").hello();

        Assert.Equal("Hello, Sam!", actual);
    }
}