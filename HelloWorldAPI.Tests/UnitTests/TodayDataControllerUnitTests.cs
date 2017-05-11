

namespace HelloWorldAPI.Tests.UnitTests
{
    using System.Configuration;
    using System.IO;
    using Controllers;
    using HelloWorldInfrastructure.Models;
    using HelloWorldInfrastructure.Services;
    using Moq;
    using NUnit.Framework;

    /// <summary>
    ///     Unit tests for the Today's Data Controller
    /// </summary>
    [TestFixture]
    public class TodayDataControllerUnitTests
    {
        /// <summary>
        ///     The mocked data service
        /// </summary>
        private Mock<IDataService> dataServiceMock;

        /// <summary>
        ///     The implementation to test
        /// </summary>
        private DataController todaysDataController;

        /// <summary>
        ///     Initialize the test fixture (runs one time)
        /// </summary>
        [TestFixtureSetUp]
        public void InitTestSuite()
        {
            // Setup mocked dependencies
            this.dataServiceMock = new Mock<IDataService>();

            // Create object to test
            this.todaysDataController = new DataController(this.dataServiceMock.Object);
        }

        #region Get Tests
        /// <summary>
        ///     Tests the controller's get method for success
        /// </summary>
        [Test]
        public void UnitTestTodaysDataControllerGetSuccess()
        {
            // Create the expected result
            var expectedResult = GetSampleTodaysData();

            // Set up dependencies
            this.dataServiceMock.Setup(m => m.GetTodaysData()).Returns(expectedResult);

            // Call the method to test
            var result = this.todaysDataController.Get();

            // Check values
            Assert.NotNull(result);
            Assert.AreEqual(result.Data, expectedResult.Data);
        }

        /// <summary>
        ///     Tests the controller's get method for a SettingsPropertyNotFoundException
        /// </summary>
        [Test]
        [ExpectedException(ExpectedException = typeof(SettingsPropertyNotFoundException))]
        public void UnitTestTodaysDataControllerGetSettingsPropertyNotFoundException()
        {
            // Set up dependencies
            this.dataServiceMock.Setup(m => m.GetTodaysData()).Throws(new SettingsPropertyNotFoundException("Error!"));

            // Call the method to test
            this.todaysDataController.Get();
        }

        /// <summary>
        ///     Tests the controller's get method for an IOException
        /// </summary>
        [Test]
        [ExpectedException(ExpectedException = typeof(IOException))]
        public void UnitTestTodaysDataControllerGetIOException()
        {
            // Set up dependencies
            this.dataServiceMock.Setup(m => m.GetTodaysData()).Throws(new IOException("Error!"));

            // Call the method to test
            this.todaysDataController.Get();
        }
        #endregion

        #region Helper Methods
        /// <summary>
        ///     Gets a sample TodaysData model
        /// </summary>
        /// <returns>A sample TodaysData model</returns>
        private static TodaysData GetSampleTodaysData()
        {
            return new TodaysData()
            {
                Data = "Hello World!"
            };
        }
        #endregion
    }
}