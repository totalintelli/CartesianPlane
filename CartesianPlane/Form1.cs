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
        /// X축과 Y축을 그린다.
        /// </summary>
        private void DrawAxis(int padding)
        {
            Graphics graphics = this.graph_panel.CreateGraphics();
            Pen pen = new Pen(Color.Black);
            int x = 0; // X 축의 x 좌표
            int y = 0; // X 축의 y 좌표
            int outerPadding = padding + thick;
            int width = this.graph_panel.Width;
            int height = this.graph_panel.Height;

            // X축을 그린다.
            graphics.DrawLine(pen, x + outerPadding, height - outerPadding, width - outerPadding, height - outerPadding);

            // Y축을 그린다.
            graphics.DrawLine(pen, x + outerPadding, y + outerPadding, x + outerPadding, height - outerPadding);

            graphics.Dispose();
        }

        private void graph_panel_Paint(object sender, PaintEventArgs e)
        {
            // 그래프 경계선을 그린다.
            DrawEdge();

            // 그래프의 X축과 Y축을 그린다.
            DrawAxis(10);
        }
    }
}
