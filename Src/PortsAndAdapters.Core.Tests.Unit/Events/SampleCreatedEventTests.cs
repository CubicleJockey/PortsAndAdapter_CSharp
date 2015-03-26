using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PortsAndAdapters.Core.Events;

namespace PortsAndAdapters.Core.Tests.Unit.Events
{
    public class SampleCreatedEventTests
    {
        [TestClass]
        public class Constructors
        {
            private readonly Guid ID = Guid.NewGuid();

            [TestMethod]
            public void Valid()
            {
                var sampleCreatedEvent = new SampleCreatedEvent(ID, "Name", "Description");
                sampleCreatedEvent.Should().NotBeNull();
                sampleCreatedEvent.Should().BeAssignableTo<ISampleCreatedEvent>();
                sampleCreatedEvent.Should().BeOfType<SampleCreatedEvent>();
            }

            [TestMethod]
            [ExpectedException(typeof (ArgumentException))]
            public void InvalidIdParamater()
            {
                var sampleCreatedEvent = new SampleCreatedEvent(Guid.Empty, "Name", "Description");
            }

            [TestMethod]
            [ExpectedException(typeof (ArgumentException))]
            public void InvalidNameParamater()
            {
                var sampleCreatedEvent = new SampleCreatedEvent(ID, null, "Description");
            }

            [TestMethod]
            [ExpectedException(typeof (ArgumentException))]
            public void InvalidDescriptionParameter()
            {
                var sampleCreatedEvent = new SampleCreatedEvent(ID, "Name", null);
            }
        }

        [TestClass]
        public class Properties
        {
            [TestMethod]
            public void SetCorrectly()
            {
                #region Arrange

                var id = Guid.NewGuid();
                const string name = "McFrontALot";
                const string description = "Creator of NerdCore Rapping";

                #endregion Arrange

                #region Act

                var sampleCreatedEvent = new SampleCreatedEvent(id, name, description);

                #endregion Act

                #region Assert

                sampleCreatedEvent.Id.ShouldBeEquivalentTo(id);
                sampleCreatedEvent.Name.ShouldAllBeEquivalentTo(name);
                sampleCreatedEvent.Description.ShouldAllBeEquivalentTo(description);

                #endregion Assert
            }
        }
    }
}