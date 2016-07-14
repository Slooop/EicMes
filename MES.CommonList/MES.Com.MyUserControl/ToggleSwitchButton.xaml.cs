using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MES.Com.MyUserControl
{
    /// <summary>
    /// ToggleSwitchButton.xaml 的交互逻辑
    /// </summary>
    public partial class ToggleSwitchButton : UserControl
    {
        public static readonly DependencyProperty IsCheckedProperty =
            DependencyProperty.Register("IsChecked", typeof(bool), typeof(ToggleSwitchButton), new PropertyMetadata(default(bool), OnIsCheckedChanged));


        public event RoutedEventHandler Checked;
        public event RoutedEventHandler UnChecked;

        public bool IsChecked
        {
            get { return (bool)GetValue(IsCheckedProperty); }
            set { SetValue(IsCheckedProperty, value); }
        }

        [Description("测试一下属性的设置方式")]
        [Category("myTest")]
        public bool myTest
        {
            get;
            set;
        }

        public ToggleSwitchButton()
        {
            InitializeComponent();
            fillRectangle_Off.Visibility = Visibility.Visible;
        }

        private static void OnIsCheckedChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            (obj as ToggleSwitchButton).OnIsCheckedChanged(args);
        }

        private void OnIsCheckedChanged(DependencyPropertyChangedEventArgs args)
        {
            fillRectangle.Visibility = IsChecked ? Visibility.Visible : Visibility.Collapsed;
            fillRectangle_Off.Visibility = !IsChecked ? Visibility.Visible : Visibility.Collapsed;
            slideBorder.HorizontalAlignment = IsChecked ? HorizontalAlignment.Right : HorizontalAlignment.Left;

            if (IsChecked && Checked != null)
            {
                Checked(this, new RoutedEventArgs());
            }

            if (!IsChecked && UnChecked != null)
            {
                UnChecked(this, new RoutedEventArgs());
            }
        }


        protected override void OnMouseLeftButtonUp(MouseButtonEventArgs args)
        {
            args.Handled = true;
            IsChecked ^= true;
            base.OnMouseLeftButtonUp(args);
        }

    }
}