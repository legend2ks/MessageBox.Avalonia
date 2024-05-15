using MsBox.Avalonia.Enums;

namespace MsBox.Avalonia.Dto;

public class MessageBoxCheckboxParams : AbstractMessageBoxParams
{
    /// <summary>
    /// Icon of window
    /// </summary>
    public Icon Icon { get; set; } = Icon.None;

    /// <summary>
    /// Default buttons
    /// </summary>
    public ButtonEnum ButtonDefinitions { get; set; } = ButtonEnum.Ok;
    
    /// <summary>
    /// Default state of the checkbox
    /// </summary>
    public bool CheckboxDefaultState { get; set; }
    
    /// <summary>
    /// Text of the checkbox
    /// </summary>
    public string CheckboxText { get; set; }

    public ClickEnum EnterDefaultButton { get; set; } = ClickEnum.Default;
    public ClickEnum EscDefaultButton { get; set; } = ClickEnum.Default;
}