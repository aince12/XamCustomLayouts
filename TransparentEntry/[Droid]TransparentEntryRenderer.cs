using System;
using CustomViews;
using CustomViews.Droid;
using Android.Support.V4.Content;
using Android.Views;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(TransparentEntry), typeof(TransparentEntryRenderer))]
namespace CustomViews.Droid
{
	public class TransparentEntryRenderer:EntryRenderer
	{
		TransparentEntry fControl;
		EntryEditText nControl;


		protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
		{

			base.OnElementChanged(e);
			Log.e("TAG", "RENDERER");
			if (Control != null)
			{
				fControl = (TransparentEntry) Element;
				nControl = this.Control;


				//Control.Background = Resources.GetDrawable(Resource.Drawable.RoundedEntry);
				//Control.SetBackgroundColor(Color.Transparent.ToAndroid());

				Control.SetBackground(ContextCompat.GetDrawable(this.Context, Android.Resource.Color.Transparent));
				Control.SetPadding(1, 3, 1, 1);

			

			}

		}
		protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged(sender, e);


			switch (fControl.TextGravityAlignment)
				{

					//leftmost
					case TransparentEntry.TextGravity.START_TOP:
						Control.Gravity = (GravityFlags.Start | GravityFlags.Top);
						break;
					case TransparentEntry.TextGravity.START_CENTER:
						Control.Gravity = (GravityFlags.Start | GravityFlags.CenterVertical);
						break;
					case TransparentEntry.TextGravity.START_BOTTOM:
						Control.Gravity = (GravityFlags.Start | GravityFlags.Bottom);
						break;

						//center

					case TransparentEntry.TextGravity.CENTER_TOP:
						Control.Gravity = (GravityFlags.CenterHorizontal | GravityFlags.Top);

						break;
					case TransparentEntry.TextGravity.CENTER:
					//Control.SetForegroundGravity(GravityFlags.Center);
						Control.Gravity = (GravityFlags.Center);

					break;
					case TransparentEntry.TextGravity.CENTER_BOTTOM:
						Control.Gravity = (GravityFlags.CenterHorizontal | GravityFlags.Bottom);

					break;

						//rightmost
					case TransparentEntry.TextGravity.END_TOP:
						Control.Gravity = (GravityFlags.End | GravityFlags.Top);
						break;
					case TransparentEntry.TextGravity.END_CENTER:
						Control.Gravity = (GravityFlags.End | GravityFlags.CenterVertical);
						break;
					case TransparentEntry.TextGravity.END_BOTTOM:
						Control.Gravity = (GravityFlags.End | GravityFlags.Bottom);
						break;

				}
		}
	
	}
}
