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
            graph.DrawAxis(this.graph_panel, 10, thick);
            // y = x 그래프를 그린다.
            graph.DrawGraph();
        }

        
    }

    public class XYGraph
    {
        int x = 0; // X 축의 x 좌표
        int y = 0; // X 축의 y 좌표

        /// <summary>
        /// X축과 Y축을 그린다.
        /// </summary>
        /// <param name="panel">그래프를 그릴 패널</param>
        /// <param name="padding">그래프 안쪽 간격</param>
        /// <param name="thick">그래프 두께</param>
        public void DrawAxis(Panel panel, int padding, int thick)
        {

            Graphics graphics = panel.CreateGraphics();
            Pen pen = new Pen(Color.Black);
           
            int outerPadding = padding + thick;
            int width = panel.Width; // 패널의 너비
            int height = panel.Height; // 패널의 너비

            // X축을 그린다.
            graphics.DrawLine(pen, x + outerPadding, height - outerPadding, width - outerPadding, height - outerPadding);

            // Y축을 그린다.
            graphics.DrawLine(pen, x + outerPadding, y + outerPadding, x + outerPadding, height - outerPadding);

            graphics.Dispose();
        }

        /// <summary>
        /// y = x 그래프를 그린다.
        /// </summary>
        public void DrawGraph()
        {
            // 그래프의 시작점
            Point graphStartingPoint = new Point();
            // 그래프의 끝점
            Point graphEndPoint = new Point();
            // 패널에 표시한 그래프의 시작점(원점)을 구한다.
            Point startingPoint = GetStartingPoint(graphStartingPoint);
            // 패널에 표시한 그래프의 끝점을 구한다.
            Point endPoint = GetEndPoint(graphEndPoint);
        }

        /// <summary>
        /// 패널에 표시한 그래프의 끝점을 구한다.
        /// </summary>
        /// <param name="graphEndPoint">그래프의 끝점</param>
        private Point GetEndPoint(Point graphEndPoint)
        {
            Point endPoint = new Point();
            return endPoint;
        }

        /// <summary>
        /// 패널에 표시한 그래프의 시작점을 구한다.
        /// </summary>
        /// <param name="startingPoint">그래프의 시작점</param>
        private Point GetStartingPoint(Point graphStartingPoint)
        {
            Point startingPoint = new Point();
            return startingPoint;
        }
    }
}
