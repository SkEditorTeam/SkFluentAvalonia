﻿using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace FluentAvaloniaSamples.Pages.NVSamplePages;

public partial class NVSamplePageSettings : UserControl
{
    public NVSamplePageSettings()
    {
        this.InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}