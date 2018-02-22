using System;
using Xamarin.Forms;

namespace CustomViewTester.CustomLayouts
{
    public class FabMenuItem
    {
        private CircularImage image;
        public int Index { get; set; }
        public FabMenuItem(String menuTitle, String source, Color menuColor)
        {
            Source = source;
            MenuColor = menuColor;
            createImage();
        }
        private void createImage(){
            image = new CircularImage();
            image.Source = Source;
            AbsoluteLayout.SetLayoutFlags(image, AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutBounds(image, new Rectangle(0.5, 1, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));

            image.HeightRequest = Size;
            image.WidthRequest = Size;
            image.BorderColor = MenuColor;
            image.BackgroundColor = MenuColor;
            image.BorderWidth = 1;
        }

        public ImageSource Source{get;set;}
        public CircularImage View{
            get{
               

                return image;
            }
        }
        private double _size = 50.0;
        public double Size {
            get{
                return _size;
            } set{
                _size = value;
                image.HeightRequest = _size;
                image.WidthRequest = _size;
            } 
        }
        public Color MenuColor { get; set; }
    }
}
