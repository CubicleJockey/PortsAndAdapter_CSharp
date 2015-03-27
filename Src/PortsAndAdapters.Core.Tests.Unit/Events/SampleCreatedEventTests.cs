using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PortsAndAdapters.Core.Events;
using PortsAndAdapters.Core.UseCaseInputs.Shared.Creates;

namespace PortsAndAdapters.Core.Tests.Unit.Events
{
    public class SampleCreatedEventTests
    {
        [TestClass]
        public class Constructors
        {
            [TestMethod]
            public void Valid()
            {
                var inputs = new SampleCreateInputs("Name", "Description");

                var sampleCreatedEvent = new SampleCreatedEvent(inputs);
                sampleCreatedEvent.Should().NotBeNull();
                sampleCreatedEvent.Should().BeAssignableTo<ISampleCreatedEvent>();
                sampleCreatedEvent.Should().BeOfType<SampleCreatedEvent>();
            }


            [TestMethod]
            [ExpectedException(typeof (ArgumentNullException))]
            public void Invalid_InputIsNull()
            {
                var sampleCreatedEvent = new SampleCreatedEvent(null);
            }
        }

        [TestClass]
        public class Properties
        {
            [TestMethod]
            public void SetCorrectly()
            {
                #region Arrange

                const string name = "McFrontALot";
                const string description = "Creator of NerdCore Rapping";

                var inputs = new SampleCreateInputs(name, description);

                #endregion Arrange

                #region Act

                var sampleCreatedEvent = new SampleCreatedEvent(inputs);

                #endregion Act

                #region Assert

                sampleCreatedEvent.Id.Should().NotBeEmpty();
                sampleCreatedEvent.Name.ShouldAllBeEquivalentTo(name);
                sampleCreatedEvent.Description.ShouldAllBeEquivalentTo(description);
                sampleCreatedEvent.CreatedOn.Year.ShouldBeEquivalentTo(DateTime.Now.Year);
                sampleCreatedEvent.CreatedOn.Month.ShouldBeEquivalentTo(DateTime.Now.Month);
                sampleCreatedEvent.CreatedOn.Day.ShouldBeEquivalentTo(DateTime.Now.Day);

                #endregion Assert
            }
        }
    }
}