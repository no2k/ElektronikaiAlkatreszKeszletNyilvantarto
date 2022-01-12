using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EKNyilvantarto.Elemek
{
    class SajatListView :ListView
    {
        private const int egerHSCROLL = 0x114;
        private const int egerVSCROLL = 0x115;
        
        public event EventHandler Scroll;

        protected void OnScroll()
        {
            if (this.Scroll != null)
                this.Scroll(this, EventArgs.Empty);
        }

        protected override void WndProc(ref System.Windows.Forms.Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == egerHSCROLL || m.Msg == egerVSCROLL ||m.Msg==0x000c2c9)
                this.OnScroll();
        }

    }
}
