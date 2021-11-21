using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyUI
{
    public class MapGridView : DataGridView
    {
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
            var innerWidth = this.Width;
            for (var i = 0; i < this.DefaultDataColumnCount; i++)
            {
                var headerText = ((i + 1) % 10).ToString();
                this.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    HeaderText = headerText,
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                    ReadOnly = true,
                });
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


        private int _DefaultDataColumnCount = 100;

        [DefaultValue(100)]
        public int DefaultDataColumnCount
        {
            get { return _DefaultDataColumnCount; }
            set { _DefaultDataColumnCount = value; }
        }
    }
}
