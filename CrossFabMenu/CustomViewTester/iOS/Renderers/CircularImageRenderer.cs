using System;
using System.Diagnostics;
using CustomViewTester;
using CustomViewTester.iOS.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CircularImage), typeof(CircularImageRenderer))]
namespace CustomViewTester.iOS.Renderers
{
    public class CircularImageRenderer:ImageRenderer
    {
        public CircularImageRenderer()
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Image> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null || Element == null)
                return;

            CreateCircle();
        }


        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);



            if (e.PropertyName == VisualElement.HeightProperty.PropertyName ||
                 e.PropertyName == VisualElement.WidthProperty.PropertyName)
            {
                CreateCircle();
            }
        }


        private void CreateCircle()
        {
            var fImage = (CircularImage)this.Element;

            try
            {
                double min = Math.Min(Element.Width, Element.Height);
                Control.Layer.CornerRadius = (float)(min / 2.0);
                Control.Layer.MasksToBounds = false;
                Control.Layer.BorderColor = fImage.BorderColor.ToCGColor();
                Control.Layer.BorderWidth = fImage.BorderWidth;
                Control.ClipsToBounds = true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Unable to create circle image: " + ex);

            }
        }
    }
}
