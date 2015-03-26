using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PortsAndAdapters.Core.UseCaseInputs.Shared.Reads;

namespace PortsAndAdapters.Core.Tests.Unit.UseCaseInputs.Shared.Reads
{
    public class SampleIdInputsTests
    {
        [TestClass]
        public class Constructors
        {
            [TestMethod]
            public void Valid()
            {
                #region Arrange

                var id = Guid.NewGuid();

                #endregion Arrange

                #region Act

                var sampleIdInputs = new SampleIdInputs(id);

                #endregion Act

                #region Assert

                sampleIdInputs.Should().NotBeNull();
                sampleIdInputs.Should().BeAssignableTo<ISampleIdInputs>();
                sampleIdInputs.Should().BeAssignableTo<SampleIdInputs>();

                #endregion Assert
            }

            [TestMethod]
            [ExpectedException(typeof(ArgumentException))]
            public void Invalid()
            {
                #region Arrange

                var id = Guid.Empty;

                #endregion Arrange

                #region Act/Assert

                var sampleIdInputs = new SampleIdInputs(id);

                #endregion Act/Assert
            }
        }
    }
}
