using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Data.Entity;
using System.Linq;
using Units.Data.Models;

namespace Units.Data.Tests
{
    [TestClass]
    public class TodoRepoTests
    {
        private static Mock<DbContext> SetupData<T>(IQueryable<T> data) where T : class
        {
            var set = new Mock<DbSet<T>>();
            set.As<IQueryable<T>>().Setup(m => m.Provider).Returns(data.Provider);
            set.As<IQueryable<T>>().Setup(m => m.Expression).Returns(data.Expression);
            set.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(data.ElementType);
            set.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator);

            var ctx = new Mock<DbContext>();
            ctx.Setup(x => x.Set<T>()).Returns(set.Object);

            return ctx;
        }

        [TestMethod]
        public void OverdueTasks_returns_overdue_tasks()
        {
            var data = new List<Todo>
            {
                new Todo { Id = 1, IsDone = false, Due = DateTime.UtcNow.Date.AddDays(-1), Name = "one" },
                new Todo { Id = 2, IsDone = true, Due = DateTime.UtcNow.Date.AddDays(-3), Name = "two" }
            }.AsQueryable();

            var db = SetupData(data);
            var repo = new TodoRepo(db.Object);

            var result = repo.OverdueTasks().ToList();

            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(1, result.Single().Id);
        }
    }
}
