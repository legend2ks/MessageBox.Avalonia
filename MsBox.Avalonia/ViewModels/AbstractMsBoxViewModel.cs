using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Media;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using MsBox.Avalonia.Base;
using MsBox.Avalonia.Dto;
using MsBox.Avalonia.Enums;

namespace MsBox.Avalonia.ViewModels;

public abstract class AbstractMsBoxViewModel : INotifyPropertyChanged
{
    private  ICopy _copy;
    
    protected void SetCopy(ICopy copy)
    {
        _copy = copy;
    }
    protected AbstractMsBoxViewModel(AbstractMessageBoxParams @params, Icon icon = Icon.None, Bitmap bitmap = null)
    {

        if (bitmap != null)
        {
            ImagePath = bitmap;
        }
        else if (icon != Icon.None)
        {
            ImagePath = new Bitmap(AssetLoader
                .Open(new Uri(
                    $" avares://MsBox.Avalonia/Assets/{icon.ToString().ToLowerInvariant()}.png")));
        }

        MinWidth = @params.MinWidth;
        MaxWidth = @params.MaxWidth;
        Width = @params.Width;
        MinHeight = @params.MinHeight;
        MaxHeight = @params.MaxHeight;
        Height = @params.Height;
        CanResize = @params.CanResize;
        FontFamily = @params.FontFamily;
        ContentTitle = @params.ContentTitle;
        ContentHeader = @params.ContentHeader;
        ContentMessage = @params.ContentMessage;
        Markdown = @params.Markdown;
        WindowIconPath = @params.WindowIcon;
        SizeToContent = @params.SizeToContent;
        LocationOfMyWindow = @params.WindowStartupLocation;
        SystemDecorations = @params.SystemDecorations;
        Topmost = @params.Topmost;
    }

    public bool CanResize { get; }
    public bool HasHeader => !string.IsNullOrEmpty(ContentHeader);
    public bool HasIcon => ImagePath is not null;
    public FontFamily FontFamily { get; }
    public string ContentTitle { get; }
    public string ContentHeader { get; }
    public string ContentMessage { get; set; }
    public bool Markdown { get; set; }
    public WindowIcon WindowIconPath { get; }
    public Bitmap ImagePath { get; }
    public double MinWidth { get; set; }
    public double MaxWidth { get; set; }
    public double Width { get; set; }

    public double MinHeight { get; set; }
    public double MaxHeight { get; set; }
    public double Height { get; set; }

    public SystemDecorations SystemDecorations { get; set; }
    public bool Topmost { get; set; }

    public SizeToContent SizeToContent { get; set; } = SizeToContent.Height;

    public WindowStartupLocation LocationOfMyWindow { get; }

    public event PropertyChangedEventHandler PropertyChanged;

    public Task Copy()
    {
        return _copy.Copy();
    }

    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}