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

        [TestMethod]
        public void TestUpperhalfProperty()
        {
            // I'm not testing values outside 0 and 360.

            float upperhalf1deg = 1;
            float upperhalf179deg = 179;
            float lowerhalf181deg = 181;
            float lowerHalf359deg = 359;

            bool deg1 = Orientation2D.FromDegrees(upperhalf1deg).Upperhalf;
            bool deg179 = Orientation2D.FromDegrees(upperhalf179deg).Upperhalf;
            bool deg181 = Orientation2D.FromDegrees(lowerhalf181deg).Upperhalf;
            bool deg359 = Orientation2D.FromDegrees(lowerHalf359deg).Upperhalf;

            Assert.AreEqual(true, deg1);
            Assert.AreEqual(true, deg179);
            Assert.AreEqual(false, deg181);
            Assert.AreEqual(false, deg359);
        }

        [TestMethod]
        public void TestLefthalfProperty()
        {
            // I'm not testing values outside 0 and 360.

            float lefthalf91deg = 91;
            float lefthalf269deg = 269;
            float righthalf89deg = 89;
            float rightHalf271deg = 271;

            bool deg91 = Orientation2D.FromDegrees(lefthalf91deg).Lefthalf;
            bool deg269 = Orientation2D.FromDegrees(lefthalf269deg).Lefthalf;
            bool deg89 = Orientation2D.FromDegrees(righthalf89deg).Lefthalf;
            bool deg271 = Orientation2D.FromDegrees(rightHalf271deg).Lefthalf;

            Assert.AreEqual(true, deg91);
            Assert.AreEqual(true, deg269);
            Assert.AreEqual(false, deg89);
            Assert.AreEqual(false, deg271);
        }
    }
}