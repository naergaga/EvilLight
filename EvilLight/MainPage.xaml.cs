using EvilLight.Model.ViewModel;
using EvilLight.View;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

//“空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409 上有介绍

namespace EvilLight
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            SystemNavigationManager.GetForCurrentView().BackRequested += MainPage_BackRequested;
        }

        private void MainPage_BackRequested(object sender, BackRequestedEventArgs e)
        {
            Frame rootFrame = this.ContentFrame;
            Debug.WriteLine(rootFrame.Name);
            if (rootFrame != null && rootFrame.CanGoBack && e.Handled == false)
            {
                e.Handled = true;
                rootFrame.GoBack();
            }
        }

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            MySplitView.IsPaneOpen = !MySplitView.IsPaneOpen;
        }

        private void ListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var item = e.ClickedItem as MenuItem;

            switch (item.Tag)
            {

                case "Home":
                    ContentFrame.Navigate(typeof(HomePage));
                    break;
                case "Share":
                    ContentFrame.Navigate(typeof(Demo));
                    break;
                case "Favorites":
                    //ContentFrame.Navigate(typeof(FavoritesPage));
                    break;
                case "Setting":
                    //ContentFrame.Navigate(typeof(SettingPage));
                    break;
            }
        }

        private void Page_Loading(FrameworkElement sender, object args)
        {
            this.IconListView.ItemsSource = new List<MenuItem>
            {
                new MenuItem {Tag="Home",Symbol=Symbol.Home,Text="首页" },
                new MenuItem {Tag="Share",Symbol=Symbol.ReShare,Text="共享" },
                new MenuItem {Tag="Favorites",Symbol=Symbol.OutlineStar,Text="收藏" },
                new MenuItem {Tag="Setting",Symbol=Symbol.Setting,Text="设置" }
            };
            this.ContentFrame.Navigate(typeof(HomePage));
        }

        private void ContentFrame_Navigated(object sender, NavigationEventArgs e)
        {
            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = (sender as Frame).CanGoBack ? AppViewBackButtonVisibility.Visible : AppViewBackButtonVisibility.Collapsed;
        }

        private void ContentFrame_Navigating(object sender, NavigatingCancelEventArgs e)
        {
            if (this.ContentFrame.SourcePageType!=null && e.SourcePageType == this.ContentFrame.SourcePageType){
                e.Cancel = true;
            }
        }
    }
}
