using System;
using Microsoft.Extensions.Logging;
namespace TCGCollector.Helpers
{
    public class TestHelper
    {
        private readonly ILogger<TestHelper> _logger;
        public TestHelper(ILogger<TestHelper> log)
        {
            _logger = log;
        }

        public string BuildString()
        {
            _logger.LogInformation("Hello");
            return "Hello";
        }
    }
}
