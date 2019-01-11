using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CartesianPlane
{
    public partial class Form1 : Form
    {
        int thick = 1; // 테두리의 두께

        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 그래프의 경계선을 그린다.
        /// </summary>
        private void DrawEdge()
        {
            Graphics graphics = this.graph_panel.CreateGraphics();
            Pen pen = new Pen(Color.Black, thick);
            int startPointX = 0; // 테두리를 그리는 시작점의 x 좌표
            int startPointY = 0; // 테두리를 그리는 시작점의 y 좌표
            int width = this.graph_panel.Width;
            int height = this.graph_panel.Height;
            graphics.DrawRectangle(pen, startPointX, startPointY, width - (thick + startPointX), height - (thick + startPointY));
            graphics.Dispose();
        }
        

        /// <summary>
        /// 그래프를 패널에 그린다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void graph_panel_Paint(object sender, PaintEventArgs e)
        {
            // 그래프 경계선을 그린다.
            DrawEdge();

            XYGraph graph = new XYGraph();
            // 그래프의 X축과 Y축을 그린다.
            int graphPadding = 10; // 그래프 안쪽 간격
            int outerPadding = graphPadding + thick; // 패널 모서리에서부터 그래프 영역 사이의 거리
            graph.DrawAxis(this.graph_panel, outerPadding);
            // y = x 그래프를 그린다.
            graph.DrawGraph(this.graph_panel, outerPadding);
        }

        
    }

    public class XYGraph
    {
        float x = 0.0f; // X 축의 x 좌표
        float y = 0.0f; // X 축의 y 좌표

        /// <summary>
        /// X축과 Y축을 그린다.
        /// </summary>
        /// <param name="panel">그래프를 그릴 패널</param>
        /// <param name="outerPadding">패널 모서리에서부터 그래프 영역 사이의 거리</param>
        public void DrawAxis(Panel panel, float outerPadding)
        {

            Graphics graphics = panel.CreateGraphics();
            Pen pen = new Pen(Color.Black);

            float width = panel.Width; // 패널의 너비
            float height = panel.Height; // 패널의 너비
            float graphWidth = width - outerPadding; // 그래프의 너비
            float graphHeight = height - outerPadding; // 그래프의 높이
            float startingPointX = x + outerPadding; // 원점의 x 좌표
            float startingPointY = height - outerPadding; // 원점의 y 좌표

            // X축을 그린다.
            graphics.DrawLine(pen, startingPointX, startingPointY, graphWidth, graphHeight);

            // Y축을 그린다.
            graphics.DrawLine(pen, x + outerPadding, y + outerPadding, x + outerPadding, graphHeight);

            graphics.Dispose();
        }

        /// <summary>
        /// 패널에 y = x 그래프를 그린다.
        /// </summary>
        /// <param name="panel">그래프를 그릴 패널</param>
        /// <param name="padding">그래프 안쪽 간격</param>
        /// <param name="thick">그래프 두께</param>
        public void DrawGraph(Panel panel, float outerPadding)
        {
            // 그래프의 시작점
            PointF graphStartingPoint = new PointF(0.0f, 0.0f);
            // 그래프의 끝점
            PointF graphEndPoint = new PointF(440.0f, 417.0f);
            // 패널에 표시한 그래프의 시작점(원점)을 구한다.
            PointF startingPoint = GetStartingPoint(panel, graphStartingPoint, outerPadding);
            // 패널에 표시한 그래프의 끝점을 구한다.
            PointF endPoint = GetEndPoint(panel, graphEndPoint, outerPadding);
            Graphics graphics = panel.CreateGraphics();
            Pen pen = new Pen(Color.Black);

            // 원점을 그린다.
            graphics.DrawLine(pen, startingPoint, endPoint);
        }

        /// <summary>
        /// 패널에 표시할 그래프의 끝점을 구한다.
        /// </summary>
        /// <param name="graphEndPoint">그래프의 끝점</param>
        public PointF GetEndPoint(Panel panel, PointF graphEndPoint, float outerPadding)
        {
            PointF endPoint = new PointF();
            // 그래프 끝점의 x좌표를 구한다.
            endPoint.X = GetEndPointX(graphEndPoint.X, outerPadding);
            // 그래프 끝점의 y좌표를 구한다.
            endPoint.Y = GetEndPointY(graphEndPoint.Y, outerPadding, panel.Height);
            return endPoint;
        }

        /// <summary>
        /// 그래프 끝점의 y좌표를 구한다.
        /// </summary>
        /// <param name="graphEndPointY">그래프의 끝점의 y 좌표</param>
        /// <param name="outerPadding">패널 모서리에서부터 그래프 영역 사이의 거리</param>
        /// <param name="panelHeight">패널의 높이</param>
        /// <returns></returns>
        public float GetEndPointY(float graphEndPointY, float outerPadding, float panelHeight)
        {
            float endPointY = panelHeight - outerPadding - graphEndPointY;
            return endPointY;
        }

        /// <summary>
        /// 그래프 끝점의 x좌표를 구한다.
        /// </summary>
        /// <param name="graphEndPointX">그래프의 끝점의 x 좌표</param>
        /// <param name="outerPadding">패널 모서리에서부터 그래프 영역 사이의 거리</param>
        /// <param name="panelWidth">패널의 너비</param>
        /// <returns>그래프 끝점의 x좌표</returns>
        public float GetEndPointX(float graphEndPointX, float outerPadding)
        {
            float endPointX = graphEndPointX;
            return endPointX;
        }

        /// <summary>
        /// 패널에 표시할 그래프 시작점을 구한다.
        /// </summary>
        /// <param name="graphStartingPoint">그래프 시작점</param>
        public PointF GetStartingPoint(Panel panel, PointF graphStartingPoint, float outerPadding)
        {
            PointF startingPoint = new PointF();
            // 그래프 시작점의 x좌표를 구한다.
            startingPoint.X = GetStartingPointX(graphStartingPoint.X, outerPadding, panel.Width);
            // 그래프 시작점의 y좌표를 구한다.
            startingPoint.Y = GetStartingPointY(graphStartingPoint.Y, outerPadding, panel.Height);
            return startingPoint;
        }

        /// <summary>
        /// 패널에 표시할 그래프 시작점의 y좌표를 구한다.
        /// </summary>
        /// <param name="graphStartingPointY">그래프 시작점의 x 좌표</param>
        /// <param name="outerPadding">패널 모서리에서부터 그래프 영역 사이의 거리</param>
        /// <returns>패널에 표시할 그래프 시작점의 y좌표</returns>
        public float GetStartingPointY(float graphStartingPointY, float outerPadding, float panelHeight)
        {
            float startingPointY = graphStartingPointY + panelHeight - outerPadding;
            return startingPointY;
        }

        /// <summary>
        /// 패널에 표시할 그래프 시작점의 x좌표를 구한다.
        /// </summary>
        /// <param name="graphStartingPointX">그래프 시작점의 x 좌표</param>
        /// <param name="outerPadding">패널 모서리에서부터 그래프 영역 사이의 거리</param>
        /// <returns>패널에 표시할 그래프 시작점의 x좌표</returns>
        public float GetStartingPointX(float graphStartingPointX, float outerPadding, float panelWidth)
        {
            float startingPointX = graphStartingPointX + outerPadding;
            return startingPointX;
        }
    }
}
