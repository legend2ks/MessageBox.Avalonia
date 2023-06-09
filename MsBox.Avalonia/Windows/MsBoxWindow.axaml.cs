using Avalonia.Controls;
using Avalonia.Threading;

namespace MsBox.Avalonia.Windows;

public partial class MsBoxWindow : Window
{
    public MsBoxWindow()
    {
        InitializeComponent();
        ShowInTaskbar = false;
        CanResize = false;
        if (!Design.IsDesignMode)
            Win32.UseImmersiveDarkMode(TryGetPlatformHandle()!.Handle, true);
    }

    public async void CloseSafe()
    {
        await Dispatcher.UIThread.InvokeAsync(Close);
    }
}