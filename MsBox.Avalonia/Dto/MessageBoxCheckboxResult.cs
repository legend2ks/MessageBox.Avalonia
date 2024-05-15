using MsBox.Avalonia.Enums;

namespace MsBox.Avalonia.Dto;

public class MessageBoxCheckboxResult
{
    public MessageBoxCheckboxResult(bool isCheckboxChecked, ButtonResult button)
    {
        IsCheckboxChecked = isCheckboxChecked;
        Button = button;
    }

    /// <summary>
    /// Checkbox state
    /// </summary>
    public bool IsCheckboxChecked { get; }
    
    /// <summary>
    /// Clicked button
    /// </summary>
    public ButtonResult Button { get; }
}