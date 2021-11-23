using MyUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            InitializeGridView();
        }

        private void InitializeGridView()
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var rnd = new Random();
            var list = new Queue<string>();
            for (var i = 0; i < 500000; i++)
            {
                var c = "---#"[rnd.Next(0, 4)];
                list.Enqueue(c.ToString());
            }
            while (list.Count > 0)
            {
                var row = (MapGridViewRow)mapGridView1.RowTemplate.Clone();
                mapGridView1.Rows.Add(row);

                var lastRowIndex = mapGridView1.Rows.Count - 1;
                row = (MapGridViewRow)mapGridView1.Rows[lastRowIndex];
                foreach (DataGridViewCell cell in row.DataCells)
                {
                    if (list.Count == 0)
                        break;
                    var data = list.Dequeue();
                    cell.Value = data;
                }
            }

            //First Piece Number
            if (mapGridView1.RowHeadersVisible)
            {
                foreach (MapGridViewRow row in mapGridView1.Rows)
                {
                    var sn = row.Index * 100 + 1;
                    row.HeaderCell.Value = sn.ToString("000000");
                }
            }

            //NG count
            if (mapGridView1.RowTailersVisible)
            {
                foreach (MapGridViewRow row in mapGridView1.Rows)
                {
                    var cells = row.DataCells;
                    var ngCount = cells.Count(c => (string)c.Value == "#");
                    row.TailerCell.Value = ngCount;
                }
            }
        }
    }
}
