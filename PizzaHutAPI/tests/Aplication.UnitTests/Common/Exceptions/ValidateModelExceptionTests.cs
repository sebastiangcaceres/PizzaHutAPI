using FluentAssertions;
using NUnit.Framework;
using PizzaHutAPI.Application.Common.Exceptions;
using System;

namespace PizzaHutAPI.Application.UnitTests.Common.Exceptions
{
    public class ValidateModelExceptionTests
    {
        [Test]
        public void DefaultConstructorCreatesAnEmptyErrorDictionary()
        {
            var actual = new ValidateModelException().Errors;

            actual.Keys.Should().BeEquivalentTo(Array.Empty<string>());
        }

    }
}
