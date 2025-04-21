using C_CuoiKi;

namespace quanlibangiay2
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            // Initialize window manager
            var windowManager = new WindowManager();

            // Pass window manager to login form
            var loginForm = new FormLogin(windowManager);

            Application.Run(loginForm);
        }
    }
}