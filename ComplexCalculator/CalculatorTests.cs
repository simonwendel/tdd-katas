using FluentAssertions;
using Moq;

namespace ComplexCalculator;

public class CalculatorTests
{
    private readonly Mock<IComplexNumberConverter> converter;
    private readonly ComplexNumber firstNumber = new(3, 2.5);
    private readonly string firstString = "3+2.5i";

    private readonly ComplexNumber secondNumber = new(1.5, 3.05);
    private readonly string secondString = "1.5+3.05i";

    private readonly Mock<INumberStack> stack;
    private readonly Calculator sut;

    public CalculatorTests()
    {
        stack = new Mock<INumberStack>();

        converter = new Mock<IComplexNumberConverter>();
        converter.Setup(c => c.FromString(firstString)).Returns(firstNumber);
        converter.Setup(c => c.FromString(secondString)).Returns(secondNumber);

        sut = new Calculator(stack.Object, converter.Object);
    }

    [Fact]
    public void Ctor_GivenNullStack_ThrowsException()
    {
#pragma warning disable CA1806
        // ReSharper disable once ObjectCreationAsStatement
        Action constructing = () => new Calculator(null!, Mock.Of<IComplexNumberConverter>());
#pragma warning restore CA1806
        constructing.Should().ThrowExactly<ArgumentNullException>().WithParameterName("stack");
    }

    [Fact]
    public void Ctor_GivenNullConverter_ThrowsException()
    {
#pragma warning disable CA1806
        // ReSharper disable once ObjectCreationAsStatement
        Action constructing = () => new Calculator(Mock.Of<INumberStack>(), null!);
#pragma warning restore CA1806
        constructing.Should().ThrowExactly<ArgumentNullException>().WithParameterName("converter");
    }

    [Fact]
    public void Enter_GivenComplexNumberString_ConvertsNumberStringToComplexNumber()
    {
        sut.Enter(firstString);
        converter.Verify(c => c.FromString(firstString));
    }

    [Fact]
    public void Enter_GivenComplexNumber_PushesNumberToStack()
    {
        sut.Enter(firstString);
        stack.Verify(s => s.Push(firstNumber));
    }

    [Fact]
    public void Add_WhenNoNumberOnStack_DoesNothing()
    {
        stack.Setup(s => s.Count).Returns(0);

        sut.Add();

        stack.Verify(s => s.Pop(), Times.Never);
        stack.Verify(s => s.Push(It.IsAny<ComplexNumber>()), Times.Never);
    }

    [Fact]
    public void Add_WhenOneNumberOnStack_DoesNothing()
    {
        stack.Setup(s => s.Count).Returns(1);
        sut.Enter(firstString);
        stack.Reset();

        sut.Add();

        stack.Verify(s => s.Pop(), Times.Never);
        stack.Verify(s => s.Push(It.IsAny<ComplexNumber>()), Times.Never);
    }

    [Fact]
    public void Add_WhenAtLeastTwoNumbersOnStack_PopsAndAddsThem()
    {
        stack.Setup(s => s.Count).Returns(2);
        stack.SetupSequence(s => s.Pop())
            .Returns(firstNumber)
            .Returns(secondNumber);

        sut.Enter(firstString);
        sut.Enter(secondString);

        sut.Add();

        stack.Verify(s => s.Pop(), Times.Exactly(2));
        stack.Verify(s => s.Push(firstNumber + secondNumber), Times.Once);
    }

    [Fact]
    public void Sub_WhenNoNumberOnStack_DoesNothing()
    {
        stack.Setup(s => s.Count).Returns(0);

        sut.Sub();

        stack.Verify(s => s.Pop(), Times.Never);
        stack.Verify(s => s.Push(It.IsAny<ComplexNumber>()), Times.Never);
    }

    [Fact]
    public void Sub_WhenOneNumberOnStack_DoesNothing()
    {
        stack.Setup(s => s.Count).Returns(1);
        sut.Enter(firstString);
        stack.Reset();

        sut.Sub();

        stack.Verify(s => s.Pop(), Times.Never);
        stack.Verify(s => s.Push(It.IsAny<ComplexNumber>()), Times.Never);
    }

    [Fact]
    public void Sub_WhenAtLeastTwoNumbersOnStack_PopsAndSubtractsThem()
    {
        stack.Setup(s => s.Count).Returns(2);
        stack.SetupSequence(s => s.Pop())
            .Returns(firstNumber)
            .Returns(secondNumber);

        sut.Enter(firstString);
        sut.Enter(secondString);

        sut.Sub();

        stack.Verify(s => s.Pop(), Times.Exactly(2));
        stack.Verify(s => s.Push(firstNumber - secondNumber), Times.Once);
    }
}