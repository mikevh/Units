using System.Data.Entity;
using System.Linq;
using Moq;

namespace Units.Data.Tests.Helpers
{
    public class ContextSetup
    {
        public static Mock<DbContext> SetupData<T>(IQueryable<T> data) where T : class
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
    }
}
