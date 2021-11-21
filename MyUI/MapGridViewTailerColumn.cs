using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyUI
{
    public class MapGridViewTailerColumn : DataGridViewColumn
    {
        public MapGridViewTailerColumn()
        {
            AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            DividerWidth = 0;
            ReadOnly = true;
            SortMode = DataGridViewColumnSortMode.NotSortable;

            this.CellTemplate = new MapGridViewTailerCell();
        }
    }
}
