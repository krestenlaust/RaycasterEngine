using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Engine.Tests
{
    [TestClass]
    public class Orientation2DTests
    {
        [TestMethod]
        public void TestRadiansToDegreesNormal()
        {
            // Arrange
            float radians0deg = 0;
            float radians90deg = (float)Math.PI / 2;
            float radians180deg = (float)Math.PI;
            float radians270deg = ((float)Math.PI / 2) * 3;
            
            // Act
            float degrees0 = new Orientation2D(radians0deg).Degrees;
            float degrees90 = new Orientation2D(radians90deg).Degrees;
            float degrees180 = new Orientation2D(radians180deg).Degrees;
            float degrees270 = new Orientation2D(radians270deg).Degrees;

            // Assert
            Assert.AreEqual(0, degrees0, 0.001f);
            Assert.AreEqual(90, degrees90, 0.001f);
            Assert.AreEqual(180, degrees180, 0.001f);
            Assert.AreEqual(270, degrees270, 0.001f);
        }

        [TestMethod]
        public void TestRadiansToDegreesEdgeCases()
        {
            // Arrange
            float radians360deg = (float)Math.PI * 2;
            float radians540deg = (float)Math.PI * 3;
            float radiansNeg180deg = -(float)Math.PI;

            // Act
            float degrees360 = new Orientation2D(radians360deg).Degrees;
            float degrees540 = new Orientation2D(radians540deg).Degrees;
            float degreesNeg180 = new Orientation2D(radiansNeg180deg).Degrees;

            // Assert
            Assert.AreEqual(0, degrees360, 0.001f);
            Assert.AreEqual(180, degrees540, 0.001f); // We expect the value to be convert to 0-360 degrees.
            Assert.AreEqual(180, degreesNeg180, 0.001f); // We expect the value to be convert to 0-360 degrees.
        }

        [TestMethod]
        public void TestDegreesToRadiansNormal()
        {
            // Arrange
            float degrees0 = 0;
            float degrees90 = 90;
            float degrees180 = 180;
            float degrees270 = 270;

            // Act
            float radians0deg = Orientation2D.FromDegrees(degrees0).Radians;
            float radians90deg = Orientation2D.FromDegrees(degrees90).Radians;
            float radians180deg = Orientation2D.FromDegrees(degrees180).Radians;
            float radians270deg = Orientation2D.FromDegrees(degrees270).Radians;

            // Assert
            Assert.AreEqual(0, radians0deg, 0.001f);
            Assert.AreEqual((float)Math.PI / 2, radians90deg, 0.001f);
            Assert.AreEqual((float)Math.PI, radians180deg, 0.001f);
            Assert.AreEqual((float)Math.PI / 2 * 3, radians270deg, 0.001f);
        }

        [TestMethod]
        public void TestDegreesToRadiansEdgeCases()
        {
            // Arrange
            float degrees360 = 360;
            float degrees540 = 540;
            float degreesNeg180 = -180;

            // Act
            float radians360deg = Orientation2D.FromDegrees(degrees360).Radians;
            float radians540deg = Orientation2D.FromDegrees(degrees540).Radians;
            float radiansNeg180deg = Orientation2D.FromDegrees(degreesNeg180).Radians;

            // Assert
            Assert.AreEqual((float)Math.PI * 2, radians360deg, 0.001f);
            Assert.AreEqual((float)Math.PI * 3, radians540deg, 0.001f);
            Assert.AreEqual(-(float)Math.PI, radiansNeg180deg, 0.001f);
        }
    }
}