using Microsoft.Toolkit.Uwp.UI.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace SimpleAnimation
{
    public sealed partial class SecondPage : Page
    {
        private ObservableCollection<string> itemList = new ObservableCollection<string>();

        public SecondPage()
        {
            this.InitializeComponent();

            for (int i = 0; i < 100; i++)
            {
                itemList.Add($"Item {i + 1}");
            }

            MainListView.ItemsSource = itemList;


        }

        private void SlidableListItem_RightCommandRequested(object sender, EventArgs e)
        {
            var item = sender as SlidableListItem;
            itemList.Remove(item.RightCommandParameter as string);
        }

        private void SlidableListItem_LeftCommandRequested(object sender, EventArgs e)
        {

        }

        private async void MainListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var listView = sender as ListView;
            var listViewItem = listView.ContainerFromItem(e.ClickedItem) as ListViewItem;
            var slidableItem = listViewItem.ContentTemplateRoot as SlidableListItem;

            if (slidableItem.SwipeStatus != SwipeStatus.Idle) return;

            MessageDialog msg = new MessageDialog(e.ClickedItem.ToString());
            await msg.ShowAsync();
        }
    }
}
