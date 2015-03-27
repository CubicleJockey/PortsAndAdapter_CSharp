using System;
using System.Collections.Generic;
using System.Linq;
using FakeItEasy;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PortsAndAdapters.Core.Ports.Secondary.StorageEngine.Queriers;
using PortsAndAdapters.Core.UseCaseInputs;
using PortsAndAdapters.Core.UseCases.Shared.Reads;
using PortsAndAdapters.Core.UtilityTypes;
using PortsAndAdapters.Core.Views;

namespace PortsAndAdapters.Core.Tests.Unit.UseCases.Shared.Reads
{
    public class GetAllSamplesUseCaseTests
    {
        [TestClass]
        public class Constructors
        {
            [TestMethod]
            public void Valid()
            {
                #region Arrange

                var fakeSampleQuerier = A.Fake<ISampleQuerier>();

                #endregion Arrange

                #region Act

                var usecase = new GetAllSamplesUseCase(fakeSampleQuerier);

                #endregion Act

                #region Assert

                usecase.Should().NotBeNull();
                usecase.Should().BeAssignableTo<IUseCase<IEmptyInput, IEnumerable<ISampleView>>>();
                usecase.Should().BeOfType<GetAllSamplesUseCase>();

                #endregion Assert
            }

            [TestMethod]
            [ExpectedException(typeof(ArgumentNullException))]
            public void Invalid()
            {
                #region Arrange

                ISampleQuerier sampleQuerier = null;

                #endregion Arrange

                #region Act/Assert

                var usecase = new GetAllSamplesUseCase(sampleQuerier);

                #endregion Act/Assert
            }
        }

        [TestClass]
        public class Methods
        {
            [TestMethod]
            public void Execute()
            {
                #region Arrange

                IEnumerable<ISampleView> samplesValue = new[]
                {
                    new SampleView(Guid.NewGuid(), "Batman", "DarkNight", DateTime.Now),
                    new SampleView(Guid.NewGuid(), "Optimus Rhyme", "NerdCore", DateTime.Now) 
                };

                var sampleQuerier = A.Fake<ISampleQuerier>();
                A.CallTo(() => sampleQuerier.GetAll()).Returns(samplesValue);

                var usecase = new GetAllSamplesUseCase(sampleQuerier);
                usecase.Should().NotBeNull();

                #endregion Arrange

                #region Act

                var result = usecase.Execute(new EmptyInput()).ToArray();

                #endregion Act

                #region Assert

                result.Should().NotBeNullOrEmpty();
                result.Length.ShouldBeEquivalentTo(samplesValue.Count());

                for (var i = 0; i < result.Length; i++)
                {
                    result.Contains(samplesValue.ElementAt(i)).Should().BeTrue();
                }

                #endregion Assert
            }
        }
    }
}
