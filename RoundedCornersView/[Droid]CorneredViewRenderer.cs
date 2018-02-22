using System;
using CustomViews;
using CustomViews.Droid;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Util;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CorneredView), typeof(CorneredViewRenderer))]
namespace CustomViews.Droid
{
	public class CorneredViewRenderer:VisualElementRenderer<ContentView>
	{



				private float _cornerRadius;
				private RectF _bounds;
				private Path _path;

				
				//private RectF _borderBounds;
				//private Path _borderPath;
				private CorneredView corneredView;

				protected override void OnElementChanged(ElementChangedEventArgs<ContentView> e)
				{
					base.OnElementChanged(e);

					if (e.OldElement != null)
					{
						return;
					}

					corneredView = (CorneredView)Element;

					_cornerRadius = TypedValue.ApplyDimension(ComplexUnitType.Dip, corneredView.CornerRadius,
						Context.Resources.DisplayMetrics);
				}

				protected override void OnSizeChanged(int w, int h, int oldw, int oldh)
				{
					base.OnSizeChanged(w, h, oldw, oldh);
					if (w != oldw && h != oldh)
					{
						_bounds = new RectF(0, 0, w, h);
					}

					_path = new Path();
					_path.Reset();
					_path.AddRoundRect(_bounds, _cornerRadius, _cornerRadius, Path.Direction.Cw);
					_path.Close();

					//for border remove if not running 
					//_borderBounds = new RectF(0, 0, w - corneredView.BorderWidth, h - corneredView.BorderWidth);

					//_borderPath = new Path();
					//_borderPath.AddRoundRect(_borderBounds, _cornerRadius, _cornerRadius, Path.Direction.Cw);
					//_borderPath.Close();

					int pad = (int)corneredView.BorderWidth;
					GradientDrawable gd = new GradientDrawable();
					gd.SetCornerRadius(_cornerRadius);
					gd.SetColor(corneredView.BackgroundColor.ToAndroid().ToArgb());
					gd.SetStroke(pad, corneredView.BorderColor.ToAndroid());


					SetPadding(pad, pad, pad, pad);
					//SetClipToPadding(true);
					SetBackgroundDrawable(gd);
					
					
					
				}

				public override void Draw(Canvas canvas)
				{
					canvas.Save();
			try
			{
				canvas.ClipPath(_path);
			}
			catch (Exception e) { Log.e("TAG", e.Message); }
			//canvas.ClipPath(_borderPath);

			//create border paint
			//Paint bPaint = new Paint();
			//bPaint.Color = corneredView.BorderColor.ToAndroid();
			//bPaint.StrokeWidth = corneredView.BorderWidth;
			//bPaint.SetStyle(Paint.Style.Stroke);

			//canvas.DrawPath(_borderPath, bPaint);

					base.Draw(canvas);
					canvas.Restore();
				}



	}
}
