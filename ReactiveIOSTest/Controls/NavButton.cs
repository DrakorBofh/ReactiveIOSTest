using System;
using UIKit;
using System.Drawing;
using Splat;

namespace ReactiveIOSTest
{
	public class NavButton: UIButton
	{
		public NavButton () : base ()
		{
			this.Font = UIFont.FromName ("Helvetica", 24);
			this.BackgroundColor = Color.White.MURAL ().ToNative ();
			this.SetTitleColor (UIColor.White, UIControlState.Normal);
		}
	}
}

