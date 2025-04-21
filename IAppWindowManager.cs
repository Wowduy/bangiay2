// IAppWindowManager.cs
public interface IAppWindowManager
{
    void ShowMainWindow();
    void ShowForgotPasswordWindow();
    void ShowWindow(Type windowType);
}