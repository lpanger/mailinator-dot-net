using System.Threading.Tasks;
using NUnit.Framework;

namespace Tests
{
    /// <summary>
    /// These are integration tests that have no validation and require updates before using.
    /// Used as a tool to manually verify methods are working.
    /// </summary>
    [TestFixture]
    class Integration
    {
        private string _token = "PUT_YOUR_API_ID_HERE";
        private string _testEmail = "PUT_YOUR_TEST_EMAIL_ADDRESS_HERE";
        private string _testEmailId = "PUT_YOUR_TEST_EMAIL_ID_HERE";

        [Test]
        public void GetInboxEmailList()
        {
            var mailinator = new Mailinator.Client(_token);
            var test = mailinator.GetInboxAsync(_testEmail);
            var result = test.Result;
        }

        [Test]
        public void GetEmail()
        {
            var mailinator = new Mailinator.Client(_token);
            var test = mailinator.GetEmailAsync(_testEmailId);
            var result = test.Result;
        }

        [Test]
        public void DeleteEmail()
        {
            var mailinator = new Mailinator.Client(_token);
            var test = mailinator.DeleteEmailAsync(_testEmailId);
            var result = test.Result;
        }
    }
}
