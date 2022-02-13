using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EKNyilvantarto
{
   
    class LVRendez:IComparer
    {
        private int fejlecIndex;
        private SortOrder rendezes;
        private CaseInsensitiveComparer adatHasonlit;

        public int FejlecIndex 
        { 
            get => fejlecIndex; 
            set => fejlecIndex = value; 
        }
        public SortOrder Rendezes 
        { 
            get => rendezes; 
            set => rendezes = value; 
        }

        public LVRendez()
        {
            fejlecIndex = 0;
            rendezes = SortOrder.None;
            adatHasonlit = new CaseInsensitiveComparer();
        }

        public int Compare(object x, object y)
        {
            int compareResult;
            ListViewItem listviewX, listviewY;

            listviewX = (ListViewItem)x;
            listviewY = (ListViewItem)y;
            compareResult = adatHasonlit.Compare(listviewX.SubItems[fejlecIndex].Text, listviewY.SubItems[fejlecIndex].Text);
            if (rendezes==SortOrder.Ascending)
            {
                return compareResult;
            }
            else if (rendezes==SortOrder.Descending)
            {
                return (-compareResult);
            }
            else
            {
                return 0;
            }
        }

    }
}
