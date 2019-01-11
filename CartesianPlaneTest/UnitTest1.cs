using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;
using CartesianPlane;

namespace CartesianPlaneTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void When0_StartPointXShouldReturn10()
        {
            // Arrange
            XYGraph graph = new XYGraph();
            float outerPadding = 10; // 패널 모서리에서부터 그래프 영역 사이의 거리
            float panelWidth = 460; // 패널의 너비
            const float pointXExpect = 10;

            // Act
            float pointXResult = graph.GetStartingPointX(0, outerPadding, panelWidth);

            // Assert
            Assert.AreEqual(pointXExpect, pointXResult, delta: pointXExpect / 1000);
        }

        [TestMethod]
        public void When0_StartPointYShouldReturn427()
        {
            // Arrange
            XYGraph graph = new XYGraph();
            float outerPadding = 10; // 패널 모서리에서부터 그래프 영역 사이의 거리
            float panelHeight = 437; // 그래프가 그려지는 패널의 높이
            const float pointYExpect = 427;

            // Act
            float pointYResult = graph.GetStartingPointY(0, outerPadding, panelHeight);

            // Assert
            Assert.AreEqual(pointYExpect, pointYResult, delta: pointYExpect / 1000);
        }

        [TestMethod]
        public void When440_EndPointXShouldReturn440()
        {
            // Arrange
            XYGraph graph = new XYGraph();
            float outerPadding = 10; // 패널 모서리에서부터 그래프 영역 사이의 거리
            const float pointXExpect = 440;

            // Act
            float pointXResult = graph.GetEndPointX(440, outerPadding);

            // Assert
            Assert.AreEqual(pointXExpect, pointXResult, delta: pointXExpect / 1000);
        }

        [TestMethod]
        public void When417_EndPointYShouldReturn10()
        {
            // Arrange
            XYGraph graph = new XYGraph();
            float outerPadding = 10; // 패널 모서리에서부터 그래프 영역 사이의 거리
            const float pointYExpect = 10;
            float panelHeight = 437;

            // Act
            float pointYResult = graph.GetEndPointY(417, outerPadding, panelHeight);

            // Assert
            Assert.AreEqual(pointYExpect, pointYResult, delta: pointYExpect / 1000);
        }
    }
}
