using System;
using Xamarin.Forms;

namespace CustomViews
{
	public class CorneredView : ContentView
	{
		public static readonly BindableProperty CornerRaidusProperty =
		BindableProperty.Create<CorneredView, float>(x => x.CornerRadius, 0);

		public static readonly BindableProperty BorderColorProperty =
			BindableProperty.Create<CorneredView, Color>(x => x.BorderColor, Color.Transparent);

		public static readonly BindableProperty BorderWidthProperty =
		BindableProperty.Create<CorneredView, float>(x => x.BorderWidth, 0);

		public float CornerRadius
		{
			get { return (float)GetValue(CornerRaidusProperty); }
			set { SetValue(CornerRaidusProperty, value); }
		}
		public Color BorderColor
		{
			get { return (Color)GetValue(BorderColorProperty); }
			set { SetValue(BorderColorProperty, value); }
		}
		public float BorderWidth
		{
			get { return (float)GetValue(BorderWidthProperty); }
			set { SetValue(BorderWidthProperty, value); }


		}
		protected override void OnChildAdded(Element child)
		{
			base.OnChildAdded(Resizer.scaleChild(child));
		}
	}
}
