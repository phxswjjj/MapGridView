using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyUI
{
    public class MapGridView : DataGridView
    {
        const int DATA_COLUMN_COUNT = 100;

        Task ResizeTask = null;
        Task PaintTask = null;
        bool AllowPaint = true;
        DateTime AllowPaintTime = DateTime.Now;
        bool Initialized = false;

        public MapGridView()
        {
            //reset
            this.RowHeadersVisible = false;
            DoubleBuffered = true;
            this.AllowUserToAddRows = false;
            this.AllowUserToDeleteRows = false;
            this.AllowUserToResizeRows = false;
            this.AllowUserToResizeColumns = false;
            this.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            this.PaintTask = Task.Delay(1000).ContinueWith(t =>
            {
                while (true)
                {
                    if (!this.InvokeRequired) break;
                    this.Invoke(new Action(() =>
                    {
                        if (!AllowPaint && DateTime.Now >= AllowPaintTime)
                        {
                            AllowPaint = true;
                            this.Refresh();
                        }
                    }));
                    System.Threading.Thread.Sleep(200);
                }
            });
        }

        protected override void InitLayout()
        {
            var defaultFont = new Font("Times New Roman", 10f, GraphicsUnit.Pixel);
            var defaultCellStyle = new DataGridViewCellStyle()
            {
                Font = defaultFont,
                Alignment = DataGridViewContentAlignment.MiddleCenter,
            };
            var textSize = TextRenderer.MeasureText("0", defaultFont);

            for (var i = 0; i < DATA_COLUMN_COUNT; i++)
            {
                var headerText = ((i + 1) % 10).ToString();

                var col = new DataGridViewTextBoxColumn()
                {
                    HeaderText = headerText,
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                    MinimumWidth = textSize.Width,
                    DividerWidth = 0,
                    ReadOnly = true,
                    DefaultCellStyle = defaultCellStyle,
                    SortMode = DataGridViewColumnSortMode.NotSortable,
                };
                col.HeaderCell.Style = defaultCellStyle;
                this.Columns.Add(col);
            }
            base.InitLayout();

            Initialized = true;
        }

        protected override void OnClientSizeChanged(EventArgs e)
        {
            base.OnClientSizeChanged(e);

            if (Initialized && (ResizeTask == null || ResizeTask.IsCompleted))
            {
                ResizeTask = Task.Run(() =>
                    {
                        while (Control.MouseButtons.HasFlag(MouseButtons.Left))
                            System.Threading.Thread.Sleep(200);
                    })
                    .ContinueWith(t => this.Invoke(new Action(RefreshColumnWidth)));
            }
        }

        private void RefreshColumnWidth()
        {
            if (this.HorizontalScrollBar.Visible)
            {
                foreach (DataGridViewColumn col in this.Columns)
                {
                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    col.Width = 1;
                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (AllowPaint)
            {
                base.OnPaint(e);
                Console.WriteLine("Paint");
                Console.WriteLine(DateTime.Now);
            }
        }

        protected override void OnScroll(ScrollEventArgs e)
        {
            AllowPaint = false;
            AllowPaintTime = DateTime.Now.AddMilliseconds(200);
            base.OnScroll(e);
        }
    }
}
