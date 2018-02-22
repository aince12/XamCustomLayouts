using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using CustomViewTester.CustomLayouts;
using Xamarin.Forms;

namespace CustomViewTester
{
    public partial class FabMenu : ContentView
    {
        private enum MenuDirection
        {
            TOP,
            BOTTOM
        }
        private int MENU_SEPARATION_PADDING = 10;
        bool isOpen = false;
        private MenuDirection direction = MenuDirection.TOP;

        public FabMenu()
        {
            InitializeComponent();
            VerticalOptions = LayoutOptions.End; //set to default
        }

        void MenuTapped(object sender, System.EventArgs e)
        {
            if (!isOpen)
                openMenu();
            else closeMenu();


        }

        private void openMenu(){
            //menu1.TranslateTo(0, 0 - (1 * (fabMenu.Height + MENU_SEPARATION_PADDING)), 100, Easing.Linear);
            //menu2.TranslateTo(0, 0 - (2 * (fabMenu.Height + MENU_SEPARATION_PADDING)), 150, Easing.Linear);
            //menu3.TranslateTo(0, 0 - (3 * (menu1.Height + MENU_SEPARATION_PADDING)), 200, Easing.Linear);


            menuWrapper.HeightRequest = (menuWrapper.Children.Count * (fabMenu.Height + MENU_SEPARATION_PADDING)); //4= fab items + fab menu
                                                                                                                   //menuWrapper.TranslateTo(0,0- (menuWrapper.HeightRequest/2));


            if (this.VerticalOptions.Equals(LayoutOptions.Center))
                this.TranslateTo(0, 0 - ((menuWrapper.Height / 2) - (fabMenu.Height / 2)), 0, Easing.Linear);
            else if (this.VerticalOptions.Equals(LayoutOptions.End))
            {
                this.TranslateTo(0, 0, 0, Easing.Linear);
            }
            else if (this.VerticalOptions.Equals(LayoutOptions.Start))
            {

                this.TranslateTo(0, 0, 0, Easing.Linear);
                direction = MenuDirection.BOTTOM;
                foreach (View v in menuWrapper.Children)
                {
                    AbsoluteLayout.SetLayoutBounds(v, new Rectangle(0.5, 0, fabMenu.WidthRequest, fabMenu.HeightRequest));
                    AbsoluteLayout.SetLayoutFlags(v, AbsoluteLayoutFlags.PositionProportional);
                }
            }

            uint animDuration = 50;
            for (int index = 0; index < menuWrapper.Children.Count; index++, animDuration += 30)
            {
                View v = menuWrapper.Children[index];

                if (v != fabMenu)
                {
                    if (direction == MenuDirection.TOP)
                        v.TranslateTo(0, 0 - ((index + 1) * (fabMenu.Height + MENU_SEPARATION_PADDING)), animDuration, Easing.Linear );
                    else if (direction == MenuDirection.BOTTOM)
                        v.TranslateTo(0, 0 + ((index + 1) * (fabMenu.Height + MENU_SEPARATION_PADDING)), animDuration, Easing.Linear);
                }
            }

            isOpen = true;
        }
        private void closeMenu(){

            uint duration = 100;
            for (int index = 0; index < menuWrapper.Children.Count; index++, duration -=5)
            {
                View v = menuWrapper.Children[index];

                if (v != fabMenu)
                {
                    v.TranslateTo(0, 0, duration, Easing.Linear);
                }
            }

            menuWrapper.TranslateTo(0, 0);
            menuWrapper.HeightRequest = fabMenu.Height;
            this.TranslateTo(0, 0, 0, Easing.Linear);
            isOpen = false;
        }

        private ObservableCollection<FabMenuItem> _fabMenus;

        public FabMenu addMenuItem(FabMenuItem item)
        {

            if (_fabMenus == null)
            {
                _fabMenus = new ObservableCollection<FabMenuItem>();
            }
            _fabMenus.Add(item);

            refreshView();
            return this;
        }

        private void refreshView()
        {
            menuWrapper.Children.Clear();

            if (_fabMenus == null)
                return;
            int tag = 0;
            foreach (FabMenuItem item in _fabMenus)
            {
                item.Size = FabSize * .9; // 90% of menu size
                addGesture(item, tag);
                menuWrapper.Children.Add(item.View);
                tag++;

                System.Diagnostics.Debug.WriteLine("Items: " + menuWrapper.Children.Count + " -- " + item.Size);
            }

            menuWrapper.Children.Add(fabMenu);
            menuWrapper.ForceLayout();
        }

        void addGesture(FabMenuItem item, int index)
        {
            item.View.GestureRecognizers.Clear();

            item.View.TAG = index;
            TapGestureRecognizer tap = new TapGestureRecognizer();
            tap.Tapped += MenuItemTapped;
            item.View.GestureRecognizers.Add(tap);
        }

        private double _size = 50.0;
        public double FabSize
        {
            get
            {
                return _size;
            }
            set
            {
                _size = value;
                fabMenu.HeightRequest = _size;
                fabMenu.WidthRequest = _size;
                refreshView();
            }
        }

        void MenuItemTapped(object sender, System.EventArgs e)
        {
            closeMenu();
            CircularImage view = sender as CircularImage;
            if (view == null)
                return;
            FabMenuEventArgs ev = new FabMenuEventArgs();
            ev.menuIndex = view.TAG;
            MenuItemSelected.Invoke(sender, ev);

            System.Diagnostics.Debug.WriteLine("Index: " + view.TAG);
        }

        public EventHandler MenuItemSelected { get; set; }

        public class FabMenuEventArgs : EventArgs
        {
            public int menuIndex { get; set; }
        }

    }
}
