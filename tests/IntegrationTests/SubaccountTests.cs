using System;
using System.Configuration;
using NUnit.Framework;

namespace Mandrill.Tests.IntegrationTests
{
    [TestFixture]
    public class SubaccountTests
    {
        [Test]
        public void Add_Subaccount_Returns_Saved_Subaccount()
        {
            // Setup
            var apiKey = ConfigurationManager.AppSettings["APIKey"];

            var subaccount = new SubaccountInfo { Id = Guid.NewGuid().ToString(), CustomQuota = 10, Name = "subaccount1" };

            var notes = subaccount.Name + " notes";

            // Exercise
            var api = new MandrillApi(apiKey);

            var result = api.AddSubaccount(subaccount, notes);

            // Verify
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Id, subaccount.Id);
            Assert.AreEqual(result.Name, subaccount.Name);
            Assert.AreEqual(result.CustomQuota, subaccount.CustomQuota);
            Assert.AreEqual(result.Status, "active");
        }

        [Test]
        public void List_Subaccounts_Contains_Added_Subaccount()
        {
            // Setup
            var apiKey = ConfigurationManager.AppSettings["APIKey"];

            var subaccount = new SubaccountInfo { Id = Guid.NewGuid().ToString(), CustomQuota = 10, Name = "subaccount1" };
            
            // Exercise
            var api = new MandrillApi(apiKey);
            var addedSubaccount = api.AddSubaccount(subaccount);

            var result = api.ListSubaccounts();
            
            // Verify
            Assert.IsNotNull(result);
            Assert.IsNotEmpty(result);
            Assert.IsNotNull(result.Find(s => s.Id == addedSubaccount.Id));
        }

        [Test]
        public void Delete_Subaccount_Returns_Deleted_Subaccount()
        {
            // Setup
            var apiKey = ConfigurationManager.AppSettings["APIKey"];

            var subaccount = new SubaccountInfo { Id = Guid.NewGuid().ToString(), CustomQuota = 10, Name = "subaccount1" };
            
            // Exercise
            var api = new MandrillApi(apiKey);

            var result = api.AddSubaccount(subaccount);

            var deletedSubaccount = api.DeleteSubaccount(result.Id);

            // Verify
            Assert.IsNotNull(deletedSubaccount);
            Assert.AreEqual(deletedSubaccount.Id, subaccount.Id);
        }

        [Test]
        public void Delete_Subaccount_Is_No_Longer_Listed()
        {
            // Setup
            var apiKey = ConfigurationManager.AppSettings["APIKey"];

            var subaccount = new SubaccountInfo { Id = Guid.NewGuid().ToString(), CustomQuota = 10, Name = "subaccount1" };

            // Exercise
            var api = new MandrillApi(apiKey);

            var result = api.AddSubaccount(subaccount);

            var deletedSubaccount = api.DeleteSubaccount(result.Id);

            var list = api.ListSubaccounts();

            // Verify
            Assert.IsNull(list.Find(s => s.Id == deletedSubaccount.Id));
        }

        [Test]
        public void Subaccount_Info_Returns_Subaccount()
        {
            // Setup
            var apiKey = ConfigurationManager.AppSettings["APIKey"];

            var subaccount = new SubaccountInfo { Id = Guid.NewGuid().ToString(), CustomQuota = 10, Name = "subaccount1" };

            // Exercise
            var api = new MandrillApi(apiKey);

            var result = api.AddSubaccount(subaccount);

            var infoSubaccount = api.SubaccountInfo(subaccount.Id);

            // Verify
            Assert.IsNotNull(infoSubaccount);
            Assert.AreEqual(infoSubaccount.Id, subaccount.Id);
        }

        [Test]
        public void Pause_Subaccount_Returns_Subaccount()
        {
            // Setup
            var apiKey = ConfigurationManager.AppSettings["APIKey"];

            var subaccount = new SubaccountInfo { Id = Guid.NewGuid().ToString(), CustomQuota = 10, Name = "subaccount1" };

            // Exercise
            var api = new MandrillApi(apiKey);

            var result = api.AddSubaccount(subaccount);

            var paused = api.PauseSubaccount(subaccount.Id);

            // Verify
            Assert.IsNotNull(paused);
            Assert.AreEqual(paused.Id, subaccount.Id);
            Assert.AreEqual(paused.Status, "paused");
        }

        [Test]
        public void Resume_Subaccount_Returns_Subaccount()
        {
            // Setup
            var apiKey = ConfigurationManager.AppSettings["APIKey"];

            var subaccount = new SubaccountInfo { Id = Guid.NewGuid().ToString(), CustomQuota = 10, Name = "subaccount1" };

            // Exercise
            var api = new MandrillApi(apiKey);

            var result = api.AddSubaccount(subaccount);

            var resumed = api.ResumeSubaccount(subaccount.Id);

            // Verify
            Assert.IsNotNull(resumed);
            Assert.AreEqual(resumed.Id, subaccount.Id);
            Assert.AreEqual(resumed.Status, "active");
        }

        [Test]
        public void Update_Subaccount_Returns_Updated_Subaccount()
        {
            // Setup
            var apiKey = ConfigurationManager.AppSettings["APIKey"];

            var subaccount = new SubaccountInfo { Id = Guid.NewGuid().ToString(), CustomQuota = 10, Name = "subaccount1" };

            // Exercise
            var api = new MandrillApi(apiKey);

            var result = api.AddSubaccount(subaccount);

            var newName = result.Name + "2";
            result.Name = newName;

            var updated = api.UpdateSubaccount(result);

            // Verify
            Assert.IsNotNull(updated);
            Assert.AreEqual(updated.Id, subaccount.Id);
            Assert.AreEqual(updated.Name, newName);
        }
    }
}