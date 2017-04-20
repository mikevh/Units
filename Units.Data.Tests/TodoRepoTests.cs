using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Units.Data.Models;
using Units.Data.Tests.Helpers;

namespace Units.Data.Tests
{
    [TestClass]
    public class TodoRepoTests
    {
        [TestMethod]
        public void OverdueTasks_returns_overdue_tasks()
        {
            var data = new List<Todo>
            {
                new Todo { Id = 1, IsDone = false, Due = DateTime.UtcNow.Date.AddDays(-1), Name = "one" },
                new Todo { Id = 2, IsDone = true, Due = DateTime.UtcNow.Date.AddDays(-3), Name = "two" }
            }.AsQueryable();

            var db = ContextSetup.SetupData(data);
            var repo = new TodoRepo(db.Object);

            var result = repo.OverdueTasks().ToList();

            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(1, result.Single().Id);
        }
    }
}
