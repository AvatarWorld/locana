﻿using Locana.Utility;
using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media.Imaging;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace Locana.Controls
{
    public sealed partial class EllipseButton : UserControl
    {
        public EllipseButton()
        {
            this.InitializeComponent();
        }

        public BitmapImage Icon { set { this._Icon.Source = value; } }
        public DataTemplate IconTemplate { set { this.IconContent.ContentTemplate = value; } }
        public event Action<object> Clicked;

        private bool _Enabled = true;
        public bool Enabled
        {
            get { return _Enabled; }
            set
            {
                _Enabled = value;
                if (value)
                {
                    _Icon.Opacity = 0.9;
                }
                else
                {
                    _Icon.Opacity = 0.5;
                }
            }
        }

        private void LayoutRoot_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (Enabled) { Clicked?.Invoke(this); }
        }

        private void LayoutRoot_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            _Ellipse.Fill = ResourceManager.SystemControlForegroundAccentBrush;
        }

        private void LayoutRoot_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            _Ellipse.Fill = ResourceManager.BackGroundBrush;
        }
    }
}
