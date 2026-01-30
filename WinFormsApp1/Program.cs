using WinFormsApp1.Assets;

namespace WinFormsApp1
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            CustomFont.InitCustomFont();
            Application.SetDefaultFont(CustomFont.GetCustomFontBySize(10));
            Application.SetCompatibleTextRenderingDefault(true);
            Application.Run(new MainForm());
        }

    }
}