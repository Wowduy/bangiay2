// WindowManager.cs
using System;
using System.Windows.Forms;
using System.Reflection;

public class WindowManager : IAppWindowManager
{
    public void ShowMainWindow()
    {
        dynamic mainForm = CreateFormInstance("C_CuoiKi", "C_CuoiKi.MainForm");
        mainForm?.Show();
    }

    public void ShowForgotPasswordWindow()
    {
        dynamic forgotForm = CreateFormInstance("quanlibangiay2", "quanlibangiay2.quenmatkhau");
        forgotForm?.Show();
    }

    public void ShowWindow(Type windowType)
    {
        dynamic form = CreateFormInstance(windowType.Namespace, windowType.FullName);
        form?.Show();
    }

    private dynamic CreateFormInstance(string assemblyName, string fullTypeName)
    {
        try
        {
            var assembly = Assembly.Load(assemblyName);
            return assembly.CreateInstance(fullTypeName);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Không thể mở cửa sổ: {ex.Message}");
            return null;
        }
    }
}