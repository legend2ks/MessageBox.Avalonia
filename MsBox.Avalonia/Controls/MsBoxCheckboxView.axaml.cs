using System;
using System.Threading.Tasks;

using Avalonia.Controls;
using Avalonia.Interactivity;
using MsBox.Avalonia.Base;
using MsBox.Avalonia.Dto;
using MsBox.Avalonia.Enums;
using MsBox.Avalonia.ViewModels;

namespace MsBox.Avalonia.Controls;

public partial class MsBoxCheckboxView : UserControl, IFullApi<MessageBoxCheckboxResult>, ISetCloseAction
{
    private MessageBoxCheckboxResult _buttonResult = new(false, ButtonResult.None);
    private Action _closeAction;

    public MsBoxCheckboxView()
    {
        InitializeComponent();
    }

    public void SetButtonResult(MessageBoxCheckboxResult bdName)
    {
        _buttonResult = bdName;
    }

    public MessageBoxCheckboxResult GetButtonResult()
    {
        return _buttonResult;
    }

    public Task Copy()
    {
        var clipboard = TopLevel.GetTopLevel(this).Clipboard;
        var text = ContentTextBox.SelectedText;
        if (string.IsNullOrEmpty(text))
        {
            text = (DataContext as AbstractMsBoxViewModel)?.ContentMessage;
        }
        return clipboard?.SetTextAsync(text);
    }

    public void Close()
    {
        _closeAction?.Invoke();
    }

    public void CloseWindow(object sender, EventArgs eventArgs)
    {
        ((IClose)this).Close();
    }

    public void SetCloseAction(Action closeAction)
    {
        _closeAction = closeAction;
    }

    protected override void OnLoaded(RoutedEventArgs e)
    {
        base.OnLoaded(e);
        var checkbox = this.FindControl<CheckBox>("Checkbox");
        checkbox!.Focus();
    }
}