using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ErsarServiceEmployers
{
    public static class Instances
    {
        public static Form1 MP;
        public static ArchiveControl ARCHIVEPAGE;
        public static Saisir SAISIRPAGE;
        public static DataControl DATAPAGE;
    }
    public static class Function
    {
        public static void EnumerateChildren(Control root)
        {
            int num = 0;
            foreach (Control control in root.Controls)
            {
                control.TabStop = true;
                num++;
                if (control.Controls != null)
                {
                    EnumerateChildren(control);
                }
            }
        }
    }
}
