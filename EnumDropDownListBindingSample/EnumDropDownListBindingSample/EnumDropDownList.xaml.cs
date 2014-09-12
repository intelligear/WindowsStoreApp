

namespace EnumDropDownListBindingSample
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using Windows.Foundation;
    using Windows.Foundation.Collections;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Controls.Primitives;
    using Windows.UI.Xaml.Data;
    using Windows.UI.Xaml.Input;
    using Windows.UI.Xaml.Media;
    using Windows.UI.Xaml.Navigation;

    public sealed partial class EnumDropDownList : UserControl
    {
        public SelectionMode SelectionMode
        {
            get { return (SelectionMode)GetValue(SelectionModeProperty); }
            set { SetValue(SelectionModeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SelectionMode.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectionModeProperty =
            DependencyProperty.Register("SelectionMode", typeof(SelectionMode), typeof(EnumDropDownList), new PropertyMetadata(0));


        public object DataSource
        {
            get { return (object)GetValue(DataSourceProperty); }
            set { SetValue(DataSourceProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DataSource.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DataSourceProperty =
            DependencyProperty.Register("DataSource", typeof(object), typeof(EnumDropDownList), new PropertyMetadata(0));


        public EnumDropDownList()
        {
            this.InitializeComponent();
        }

        private void itemsList_LostFocus(object sender, RoutedEventArgs e)
        {
            popUp.IsOpen = false;
        }


        private void txtSelections_Tapped(object sender, TappedRoutedEventArgs e)
        {
            popUp.IsOpen = true;
        }

        private void itemsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            txtSelections.Text = string.Join<object>(", ", itemsList.SelectedItems);
            Type enumType = EnumTypeHelper.GetEnumType(DataSource);
            if (enumType != null)
            {
                List<object> enumItemList = new List<object>();
                foreach (var item in itemsList.SelectedItems)
                {
                    enumItemList.Add(Enum.Parse(enumType, item.ToString()));
                }
                var method = typeof(Enumerable).GetRuntimeMethod("Cast", new Type[] { typeof(IEnumerable) }).MakeGenericMethod(enumType);
                this.DataSource = method.Invoke(null, new object[] { enumItemList });
            }
        }
    }
}
