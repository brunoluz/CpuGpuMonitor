namespace CpuGpuMonitor.UserInterface
{
    partial class FormGraphics
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            plotView1 = new OxyPlot.WindowsForms.PlotView();
            timerUpdateSeries = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // plotView1
            // 
            plotView1.Dock = DockStyle.Fill;
            plotView1.Location = new Point(0, 0);
            plotView1.Name = "plotView1";
            plotView1.PanCursor = Cursors.Hand;
            plotView1.Size = new Size(1745, 795);
            plotView1.TabIndex = 0;
            plotView1.Text = "plotView1";
            plotView1.ZoomHorizontalCursor = Cursors.SizeWE;
            plotView1.ZoomRectangleCursor = Cursors.SizeNWSE;
            plotView1.ZoomVerticalCursor = Cursors.SizeNS;
            // 
            // timerUpdateSeries
            // 
            timerUpdateSeries.Interval = 1000;
            timerUpdateSeries.Tick += timerUpdateSeries_Tick;
            // 
            // FormGraphics
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1745, 795);
            Controls.Add(plotView1);
            Name = "FormGraphics";
            Text = "CPU GPU Temp Monitor";
            Load += Form1_Load;
            ResumeLayout(false);
        }

        #endregion

        private OxyPlot.WindowsForms.PlotView plotView1;
        private System.Windows.Forms.Timer timerUpdateSeries;
    }
}
