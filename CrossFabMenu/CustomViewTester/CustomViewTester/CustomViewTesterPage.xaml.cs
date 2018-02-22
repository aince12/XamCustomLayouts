using System;
using CustomViewTester.CustomLayouts;
using Xamarin.Forms;
using static CustomViewTester.FabMenu;

namespace CustomViewTester
{
    public partial class CustomViewTesterPage : ContentPage
    {
        
        public CustomViewTesterPage()
        {
            InitializeComponent();


            fab.addMenuItem(new FabMenuItem("","ic_menu_white", Color.Blue));
            fab.addMenuItem(new FabMenuItem("", "ic_menu_white", Color.Beige));
            fab.addMenuItem(new FabMenuItem("", "ic_menu_white", Color.Cyan));
            fab.addMenuItem(new FabMenuItem("", "ic_menu_white", Color.Orange));

            fab.MenuItemSelected += (sender, e) => {

                System.Diagnostics.Debug.WriteLine("Event Index: " + (e as FabMenuEventArgs).menuIndex);


            };
        }


    }
}
