using System;
using FakeItEasy;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PortsAndAdapters.Core.UseCaseInputs.Shared.Creates;

namespace PortsAndAdapters.Core.Tests.Unit.UseCaseInputs.Shared.Creates
{
    public class SampleCreateInputsTests
    {
        [TestClass]
        public class Constructors
        {
            [TestMethod]
            public void Valid()
            {
                #region Arrange

                const string NAME = "Avenged Sevenfold";
                const string DESCRIPTION = "Rock";

                #endregion Arrange

                #region Act

                var inputs = new SampleCreateInputs(NAME, DESCRIPTION);

                #endregion Act

                #region Assert

                inputs.Should().NotBeNull();
                inputs.Should().BeAssignableTo<ISampleCreateInputs>();
                inputs.Should().BeOfType<SampleCreateInputs>();

                #endregion Assert
            }

            [TestMethod]
            [ExpectedException(typeof(ArgumentException))]
            public void Invalid_NameIsNull()
            {
                #region Arrange

                string name = null;
                var description = A.Dummy<string>();

                #endregion Arrange

                #region Act/Assert

                var input = new SampleCreateInputs(name, description);

                #endregion Act/Assert
            }

            [TestMethod]
            [ExpectedException(typeof(ArgumentException))]
            public void Invalid_NameIsEmptyString()
            {
                #region Arrange

                var name = string.Empty;
                var description = A.Dummy<string>();

                #endregion Arrange

                #region Act/Assert

                var input = new SampleCreateInputs(name, description);

                #endregion Act/Assert
            }

            [TestMethod]
            [ExpectedException(typeof(ArgumentException))]
            public void Invalid_NameIsWhitespace()
            {
                #region Arrange

                const string name = "           ";
                var description = A.Dummy<string>();

                #endregion Arrange

                #region Act/Assert

                var input = new SampleCreateInputs(name, description);

                #endregion Act/Assert
            }

            [TestMethod]
            [ExpectedException(typeof(ArgumentException))]
            public void Invalid_DescriptionIsNull()
            {
                #region Arrange

                const string NAME = "Wolverine";
                string description = null;

                #endregion Arrange

                #region Act/Assert

                var input = new SampleCreateInputs(NAME, description);

                #endregion Act/Assert
            }

            [TestMethod]
            [ExpectedException(typeof(ArgumentException))]
            public void Invalid_DescriptionIsEmptyString()
            {
                #region Arrange

                const string NAME = "Wolverine";
                var description = string.Empty;

                #endregion Arrange

                #region Act/Assert

                var input = new SampleCreateInputs(NAME, description);

                #endregion Act/Assert
            }

            [TestMethod]
            [ExpectedException(typeof(ArgumentException))]
            public void Invalid_DescriptionIsWhitespace()
            {
                #region Arrange

                const string NAME = "Wolverine";
                const string description = "                 ";

                #endregion Arrange

                #region Act/Assert

                var input = new SampleCreateInputs(NAME, description);

                #endregion Act/Assert
            }
        }
    }
}
