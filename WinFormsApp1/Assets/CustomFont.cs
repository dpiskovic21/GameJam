using System.Drawing.Text;
using System.Runtime.InteropServices;

namespace WinFormsApp1.Assets
{
    public static class CustomFont
    {
        public static PrivateFontCollection pfc;

        public static void InitCustomFont()
        {
            pfc = new PrivateFontCollection();

            int fontLength = Properties.Resources.Resoft.Length;
            byte[] fontdata = Properties.Resources.Resoft;

            System.IntPtr data = Marshal.AllocCoTaskMem(fontLength);

            Marshal.Copy(fontdata, 0, data, fontLength);

            pfc.AddMemoryFont(data, fontLength);
        }
    }
}
