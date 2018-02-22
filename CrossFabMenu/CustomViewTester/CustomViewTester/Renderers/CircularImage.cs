
using System;

using Xamarin.Forms;

namespace CustomViewTester
{
	public class CircularImage : Image
	{
		
		public CircularImage()
		{
            
		}

		public int BorderWidth
		{
			get; set;
		}
		public Color BorderColor
		{
			get; set;
		}

        public int TAG { get; set; }
	}
}

