using System;
using FakeItEasy;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PortsAndAdapters.Core.Ports.Secondary.StorageEngine.Queriers;
using PortsAndAdapters.Core.UseCaseInputs.Shared.Reads;
using PortsAndAdapters.Core.UseCases.Shared.Reads;
using PortsAndAdapters.Core.UtilityTypes;
using PortsAndAdapters.Core.Views;

namespace PortsAndAdapters.Core.Tests.Unit.UseCases.Shared.Reads
{
    public class GetSampleByIdUseCaseTests
    {
        [TestClass]
        public class Constructors
        {
            [TestMethod]
            public void Valid()
            {
                #region Arrange

                var querier = A.Fake<ISampleQuerier>();

                #endregion Arrange

                #region Act

                var usecase = new GetSampleByIdUseCase(querier);

                #endregion Act

                #region Assert

                usecase.Should().NotBeNull();
                usecase.Should().BeAssignableTo<IUseCase<ISampleIdInputs, ISampleView>>();
                usecase.Should().BeOfType<GetSampleByIdUseCase>();

                #endregion Assert
            }

            [TestMethod]
            [ExpectedException(typeof(ArgumentNullException))]
            public void Invalid()
            {
                #region Arrange

                ISampleQuerier querier = null;

                #endregion Arrange

                #region Act/Assert

                var usecase = new GetSampleByIdUseCase(querier);

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

                var id = Guid.NewGuid();
                var findId = new SampleIdInputs(id);

                var foundSample = new SampleView(id, "Kellee Maize", "New Age", DateTime.Now);
                

                var querier = A.Fake<ISampleQuerier>();
                
                A.CallTo(() => querier.GetWithId(findId)).Returns(foundSample);

                var usecase = new GetSampleByIdUseCase(querier);
                usecase.Should().NotBeNull();

                #endregion Arrange

                #region Act

                var sample = usecase.Execute(findId);

                #endregion Act

                #region Assert

                sample.Should().NotBeNull();
                sample.ShouldBeEquivalentTo(foundSample);

                A.CallTo(() => querier.GetWithId(findId)).MustHaveHappened(Repeated.Exactly.Once);
                
                #endregion Assert
            }
        }
    }
}
