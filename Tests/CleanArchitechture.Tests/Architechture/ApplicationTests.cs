using CleanArchitechture.Application.Abstraction;
using FluentValidation;
using MediatR;

namespace CleanArchitechture.Tests.Architechture
{
    public class ApplicationTests: BaseTest
    {
        #region Naming

        [Theory]
        public void Commands_ShouldHave_NameEndingWith_Command()
        {
            TestResult? result = Types
                .InAssemblies(ApplicationAssemblies)
                .That()
                .ImplementInterface(typeof(ICommandBase))
                .Or()
                .ImplementInterface(typeof(ICommandBase<>))
                .Should()
                .HaveNameEndingWith("Command")
                .GetResult();

            result.IsSuccessful.Should().BeTrue();
        }

        [Theory]
        public void CommandHandlers_ShouldHave_NameEndingWith_CommandHandler()
        {
            TestResult? result = Types
                .InAssemblies(ApplicationAssemblies)
                .That()
                .ImplementInterface(typeof(ICommandHandler<,>))
                .Should()
                .HaveNameEndingWith("CommandHandler")
                .GetResult();

            result.IsSuccessful.Should().BeTrue();
        }

        [Theory]
        public void Queries_ShouldHave_NameEndingWith_Query()
        {
            TestResult? result = Types
                .InAssemblies(ApplicationAssemblies)
                .That()
                .ImplementInterface(typeof(IQueryBase<>))
                .Should()
                .HaveNameEndingWith("Query")
                .GetResult();

            result.IsSuccessful.Should().BeTrue();
        }

        [Theory]
        public void QueryHandlers_ShouldHave_NameEndingWith_QueryHandler()
        {
            TestResult? result = Types
                .InAssemblies(ApplicationAssemblies)
                .That()
                .ImplementInterface(typeof(IQueryHandler<,>))
                .Should()
                .HaveNameEndingWith("QueryHandler")
                .GetResult();

            result.IsSuccessful.Should().BeTrue();
        }
       
        [Theory]
        public void Validators_ShouldHave_NameEndingWith_Validator()
        {
            TestResult? result = Types
                .InAssemblies(ApplicationAssemblies)
                .That()
                .Inherit(typeof(AbstractValidator<>))
                .Should()
                .HaveNameEndingWith("Validator")
                .GetResult();

            result.IsSuccessful.Should().BeTrue();
        }

        [Theory]
        public void Behaviors_ShouldHave_NameEndingWith_Behavior()
        {
            TestResult? result = Types
                .InAssemblies(ApplicationAssemblies)
                .That()
                .ImplementInterface(typeof(IPipelineBehavior<,>))
                .Should()
                .HaveNameEndingWith("Behavior")
                .GetResult();

            result.IsSuccessful.Should().BeTrue();
        }   

        #endregion

        #region Modifier

        [Theory]
        public void CommandHandlers_Should_NotBePublic()
        {
            TestResult? result = Types
                .InAssemblies(ApplicationAssemblies)
                .That()
                .ImplementInterface(typeof(ICommandHandler<,>))
                .Should()
                .NotBePublic()
                .GetResult();

            result.IsSuccessful.Should().BeTrue();
        }

        [Theory]
        public void CommandHandlers_Should_BeSealed()
        {
            TestResult? result = Types
                .InAssemblies(ApplicationAssemblies)
                .That()
                .ImplementInterface(typeof(ICommandHandler<,>))
                .Should()
                .BeSealed()
                .GetResult();

            result.IsSuccessful.Should().BeTrue();
        }

        #endregion
    }
}
