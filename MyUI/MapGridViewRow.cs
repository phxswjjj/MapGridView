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
    public class MapGridViewRow : DataGridViewRow
    {
        public MapGridViewRow()
        {
        }

        //
        // 摘要:
        //     取得填入資料列的儲存格集合。
        //
        // 傳回:
        //     System.Windows.Forms.DataGridViewCellCollection，包含資料列中的所有儲存格。
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public IEnumerable<DataGridViewCell> DataCells
        {
            get
            {
                var cells = this.Cells.Cast<DataGridViewCell>();
                return cells.Where(c => !(c is MapGridViewTailerCell));
            }
        }

        [Browsable(false)]
        public MapGridViewTailerCell TailerCell
        {
            get
            {
                var cells = this.Cells.Cast<DataGridViewCell>();
                return (MapGridViewTailerCell)cells.First(c => c is MapGridViewTailerCell);
            }
        }
    }
}
