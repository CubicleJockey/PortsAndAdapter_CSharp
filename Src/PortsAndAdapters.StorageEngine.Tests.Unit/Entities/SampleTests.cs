using System;
using FakeItEasy;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PortsAndAdapters.Core.Views;
using PortsAndAdapters.StorageEngine.Entities;

namespace PortsAndAdapters.StorageEngine.Tests.Unit.Entities
{
    public class SampleTests
    {
        [TestClass]
        public class Constructors
        {
            [TestMethod]
            public void Valid()
            {
                #region Arrange

                var Id = Guid.NewGuid();
                const string Name = "Slater-Kenney";
                const string Description = "Olympia Band";
                var Date = DateTime.Now;

                #endregion Arrange

                #region Act

                var sample = new Sample(Id, Name, Description, Date);

                #endregion Act

                #region Assert

                sample.Should().NotBeNull();
                sample.Should().BeAssignableTo<IMongoEntity>();
                sample.Should().BeAssignableTo<MongoEntity>();
                sample.Should().BeOfType<Sample>();

                #endregion Assert
            }

            [TestMethod]
            [ExpectedException(typeof(ArgumentException))]
            public void Invalid_IdIsEmptyGuid()
            {
                #region Arrange
                var Id = Guid.Empty;
                const string Name = "Slater-Kenney";
                const string Description = "Olympia Band";
                var Date = DateTime.Now;

                #endregion Arrange

                #region Act/Assert

                var sample = new Sample(Id, Name, Description, Date);

                #endregion Act/Assert
            }

            [TestMethod]
            [ExpectedException(typeof(ArgumentException))]
            public void Invalid_NameIsNull()
            {
                #region Arrange
                var Id = Guid.NewGuid();
                const string Name = null;
                const string Description = "Olympia Band";
                var Date = DateTime.Now;

                #endregion Arrange

                #region Act/Assert

                var sample = new Sample(Id, Name, Description, Date);

                #endregion Act/Assert
            }

            [TestMethod]
            [ExpectedException(typeof(ArgumentException))]
            public void Invalid_NameIsEmptyString()
            {
                #region Arrange
                var Id = Guid.NewGuid();
                var Name = string.Empty;
                const string Description = "Olympia Band";
                var Date = DateTime.Now;

                #endregion Arrange

                #region Act/Assert

                var sample = new Sample(Id, Name, Description, Date);

                #endregion Act/Assert
            }

            [TestMethod]
            [ExpectedException(typeof(ArgumentException))]
            public void Invalid_NameIsWhitespace()
            {
                #region Arrange
                var Id = Guid.NewGuid();
                const string Name = "          ";
                const string Description = "Olympia Band";
                var Date = DateTime.Now;

                #endregion Arrange

                #region Act/Assert

                var sample = new Sample(Id, Name, Description, Date);

                #endregion Act/Assert
            }

            [TestMethod]
            [ExpectedException(typeof(ArgumentException))]
            public void Invalid_DescriptionIsNull()
            {
                #region Arrange
                var Id = Guid.NewGuid();
                const string Name = "Muse";
                const string Description = null;
                var Date = DateTime.Now;

                #endregion Arrange

                #region Act/Assert

                var sample = new Sample(Id, Name, Description, Date);

                #endregion Act/Assert
            }

            [TestMethod]
            [ExpectedException(typeof(ArgumentException))]
            public void Invalid_DescriptionIsEmptyString()
            {
                #region Arrange
                var Id = Guid.NewGuid();
                const string Name = "Muse";
                var Description = string.Empty;
                var Date = DateTime.Now;

                #endregion Arrange

                #region Act/Assert

                var sample = new Sample(Id, Name, Description, Date);

                #endregion Act/Assert
            }

            [TestMethod]
            [ExpectedException(typeof(ArgumentException))]
            public void Invalid_DescriptionIsWhitespace()
            {
                #region Arrange
                var Id = Guid.NewGuid();
                const string Name = "Muse";
                const string Description = "         ";
                var Date = DateTime.Now;

                #endregion Arrange

                #region Act/Assert

                var sample = new Sample(Id, Name, Description, Date);

                #endregion Act/Assert
            }

        }

        [TestClass]
        public class Properties
        {
            [TestMethod]
            public void SetCorrectly()
            {
                #region Arrange

                var Id = Guid.NewGuid();
                const string Name = "Slater-Kenney";
                const string Description = "Olympia Band";
                var Date = DateTime.Now;

                #endregion Arrange

                #region Act

                var sample = new Sample(Id, Name, Description, Date);

                #endregion Act

                #region Assert

                sample.Should().NotBeNull();

                sample.Id.ShouldBeEquivalentTo(Id);
                sample.Name.ShouldAllBeEquivalentTo(Name);
                sample.Description.ShouldBeEquivalentTo(Description);
                sample.CreatedOn.ShouldBeEquivalentTo(Date);

                #endregion Assert
            }
        }

        [TestClass]
        public class Methods
        {
            [TestMethod]
            public void ToISampleView()
            {
                #region Arrange

                var Id = Guid.NewGuid();
                const string Name = "Slater-Kenney";
                const string Description = "Olympia Band";
                var Date = DateTime.Now;

                var sample = new Sample(Id, Name, Description, Date);
                sample.Should().NotBeNull();

                #endregion Arrange

                #region Act

                var iSampleView = sample.ToISampleView();

                #endregion Act

                #region Assert

                iSampleView.Should().NotBeNull();
                iSampleView.Should().BeAssignableTo<ISampleView>();
                iSampleView.Should().BeOfType<SampleView>();

                #endregion Assert
            }
        }
    }
}
