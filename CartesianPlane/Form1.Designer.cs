﻿namespace CartesianPlane
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.graph_panel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // graph_panel
            // 
            this.graph_panel.Location = new System.Drawing.Point(12, 12);
            this.graph_panel.Name = "graph_panel";
            this.graph_panel.Size = new System.Drawing.Size(460, 437);
            this.graph_panel.TabIndex = 0;
            this.graph_panel.Paint += new System.Windows.Forms.PaintEventHandler(this.graph_panel_Paint);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 461);
            this.Controls.Add(this.graph_panel);
            this.Name = "Form1";
            this.Text = "2차원 평면 그리기";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel graph_panel;
    }
}

