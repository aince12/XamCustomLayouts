using System;
using CustomViews;
using CustomViews.iOS;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CorneredView), typeof(CorneredViewRenderer))]
namespace CustomViews.iOS
{
	public class CorneredViewRenderer:VisualElementRenderer<ContentView>
	{


		protected override void OnElementChanged(ElementChangedEventArgs<ContentView> e)
		{
			base.OnElementChanged(e);

			if (e.OldElement != null)
			{
				return;
			}

			Layer.CornerRadius = ((CorneredView)Element).CornerRadius;
			Layer.BorderWidth = ((CorneredView)Element).BorderWidth;
			Layer.BorderColor = ((CorneredView)Element).BorderColor.ToUIColor().CGColor;
		}



	}
}
