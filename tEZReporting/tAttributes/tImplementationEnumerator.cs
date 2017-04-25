using System.Linq;
using EZReporting.Implementation;
using EZReporting.Interface;
using EZReporting.Location;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace tEZReporting.tAttributes {

    [TestClass]
    public class tImplementationEnumerator {

        [TestMethod]
        public void tLocateRenderer() {
            var result = ImplementationEnumerator.Locate(ImplementationCategory.Renderer);
            Assert.IsTrue(result.Contains(typeof(DefaultRenderer)));
        }

        [TestMethod]
        public void tLocate() {
            var result = ImplementationEnumerator.Locate(typeof(IFormatter));
            Assert.IsTrue(result.Contains(typeof(DefaultFormatter)));
        }

        [TestMethod]
        public void tLocateDataProvider() {
            var result = ImplementationEnumerator.Locate(typeof(IDataProvider));
            Assert.IsTrue(result.Contains(typeof(DefaultDataProvider)));
        }

        [TestMethod]
        public void tLocateConverter() {
            var result = ImplementationEnumerator.Locate(typeof(IConverter));
            Assert.IsTrue(result.Contains(typeof(DefaultConverter)));
        }
    }
}
