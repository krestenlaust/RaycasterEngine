using Engine.MathTypes;

namespace Engine.Tests.MathTypes
{
    [TestClass]
    public class AngleTests
    {
        [DataRow(0, 0)]
        [DataRow((float)Math.PI / 2, 90)]
        [DataRow((float)Math.PI, 180)]
        [DataRow((float)Math.PI / 2 * 3, 270)]
        [DataRow((float)Math.PI * 2, 360)]
        [DataRow((float)Math.PI * 3, 540)]
        [DataRow(-(float)Math.PI, -180)]
        [DataTestMethod]
        public void TestRadiansToDegrees(float radians, float expectedDegrees)
        {
            // Arrange & Act
            float actualDegrees = new Angle(radians).Degrees;

            // Assert
            Assert.AreEqual(expectedDegrees, actualDegrees, 0.001f);
        }

        [DataRow(360, 0)]
        [DataRow(540, 180)]
        [DataRow(-180, 180)]
        [DataTestMethod]
        public void TestNormalize(float degrees, float expectedDegrees)
        {
            // Arrange & Act
            float actualDegrees = Angle.FromDegrees(degrees).Normalized.Degrees;

            // Assert
            Assert.AreEqual(expectedDegrees, actualDegrees, 0.001f);
        }


        [DataRow(0, 0)]
        [DataRow(90, (float)Math.PI / 2)]
        [DataRow(180, (float)Math.PI)]
        [DataRow(270, (float)Math.PI / 2 * 3)]
        [DataRow(360, (float)Math.PI * 2)]
        [DataRow(540, (float)Math.PI * 3)]
        [DataRow(-180, -(float)Math.PI)]
        [DataTestMethod]
        public void TestDegreesToRadians(float degree, float expectedRadians)
        {
            // Arrange & Act
            float actualRadians = Angle.FromDegrees(degree).Radians;

            // Assert
            Assert.AreEqual(expectedRadians, actualRadians, 0.001f);
        }

        // TODO: Test values outside 0 and 360.
        [DataRow(1, true)]
        [DataRow(179, true)]
        [DataRow(181, false)]
        [DataRow(359, false)]
        [DataTestMethod]
        public void TestUpperhalfProperty(float degree, bool expectedUpperHalf)
        {
            bool actualUpperHalf = Angle.FromDegrees(degree).Upperhalf;

            Assert.AreEqual(expectedUpperHalf, actualUpperHalf);
        }

        // TODO: Test values outside 0 and 360.
        [DataRow(91, true)]
        [DataRow(269, true)]
        [DataRow(89, false)]
        [DataRow(271, false)]
        [DataTestMethod]
        public void TestLefthalfProperty(float degree, bool expectedLeftHalf)
        {
            bool actualLefthalf = Angle.FromDegrees(degree).Lefthalf;

            Assert.AreEqual(expectedLeftHalf, actualLefthalf);
        }

        [DataRow(MathF.PI / 2, 0, 1)] // Angle.Up
        [DataRow(MathF.PI * 2 - MathF.PI / 2, 0, -1)] // Angle.Down
        [DataRow(MathF.PI, -1, 0)] // Angle.Left
        [DataRow(0, 1, 0)] // Angle.Right
        [DataTestMethod]
        public void TestAngleToVector(float angleRad, float unitX, float unitY)
        {
            Angle angle = new(angleRad);

            Vector2D unitVector = angle.Vector;

            Assert.AreEqual(unitX, unitVector.X, 0.00001f);
            Assert.AreEqual(unitY, unitVector.Y, 0.00001f);
        }
    }
}