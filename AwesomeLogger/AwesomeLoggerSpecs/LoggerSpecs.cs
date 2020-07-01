using System;
using AwesomeLogger;
using log4net;
using Moq;
using NUnit.Framework;

namespace AwesomeLoggerSpecs
{
    [TestFixture]
    public class LoggerSpecs
    {
        [Test]
        public void When_logging_an_error()
        {
            var mockLogger = new Mock<ILog>();
            mockLogger.Setup(log => log.IsErrorEnabled).Returns(true);

            var logger = new Logger<LoggerSpecs>(mockLogger.Object);

            logger.Error("Bad things happened", new Exception());

            mockLogger.Verify(log => log.Error(It.IsAny<string>(), It.IsAny<Exception>()));
        }
    }
}
