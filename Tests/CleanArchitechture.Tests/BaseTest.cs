using System.Reflection;
using I = CleanArchitechture.Infrastructure;
using A = CleanArchitechture.Application;
using D = CleanArchitechture.Domain;
using CleanArchitechture.Domain.Entities;

namespace CleanArchitechture.Tests
{
    public abstract class BaseTest
    {
        public static Assembly ApplicationAssemply => typeof(A.DependencyInjection).Assembly;
        public static Assembly InfrastructureAssembly => typeof(I.DependencyInjection).Assembly;
        public static Assembly DomainAssembly => typeof(D.Entities.Entity).Assembly;
        protected static readonly IEnumerable<Assembly> DomainAssemblies = new[]
   {
        typeof(User).Assembly,
    };

        protected static readonly IEnumerable<Assembly> ApplicationAssemblies = new[]
        {
        typeof(A.DependencyInjection).Assembly
    };
    }
}
