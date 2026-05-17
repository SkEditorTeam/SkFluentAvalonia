using System.Runtime.CompilerServices;
using FluentAvalonia.Interop;
using FluentAvalonia.Interop.Win32;
using static FluentAvalonia.Interop.Win32Interop;

namespace FluentAvalonia.UI.Windowing;

public partial class FAAppWindow
{
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void InitializeAppWindow()
    {
        IsWindows = true;
        IsWindows11 = OSVersionHelper.IsWindows11();

        _win32Manager = new Win32WindowManager(this);
        
        // Force AppWindow into darkmode at the system level
        ApplyTheme(_win32Manager.Hwnd, true);
        
        if (IsWindows11)
        {
            SuppressWin11CaptionRendering(_win32Manager.Hwnd);
        }
        
        PseudoClasses.Add(":windows");
        PlatformFeatures = new Win32AppWindowFeatures(this);
    }
    
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static unsafe void SuppressWin11CaptionRendering(HWND hwnd)
    {
        var colorNone = 0xFFFFFFFE;
        DwmSetWindowAttribute(hwnd, DWMWINDOWATTRIBUTE.DWMWA_CAPTION_COLOR, &colorNone, sizeof(uint));
        DwmSetWindowAttribute(hwnd, DWMWINDOWATTRIBUTE.DWMWA_TEXT_COLOR, &colorNone, sizeof(uint));
    }

    private Win32WindowManager _win32Manager;
}
