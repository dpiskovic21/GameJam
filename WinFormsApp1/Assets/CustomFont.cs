using System.Drawing.Text;
using System.Runtime.InteropServices;

namespace WinFormsApp1.Assets
{
    public static class CustomFont
    {
        private static PrivateFontCollection? pfc = null;
        private static Dictionary<int, Font> _store = new();

        public static void InitCustomFont()
        {
            pfc = new PrivateFontCollection();

            int fontLength = Properties.Resources.Resoft.Length;
            byte[] fontdata = Properties.Resources.Resoft;

            System.IntPtr data = Marshal.AllocCoTaskMem(fontLength);

            Marshal.Copy(fontdata, 0, data, fontLength);

            pfc.AddMemoryFont(data, fontLength);
        }

        public static Font GetCustomFontBySize(int size)
        {
            if (pfc == null)
            {
                InitCustomFont();
            }

            if (!_store.ContainsKey(size))
            {
                var font = new Font(pfc!.Families[0], size);
                _store[size] = font;
            }

            return _store[size];
        }
    }
}
