using System;
using UIKit;
using CoreGraphics;
using Cirrious.FluentLayouts.Touch;
using System.Drawing;
using Splat;

namespace ReactiveIOSTest
{
	public class MainButton: UIButton
	{
		public MainButton () : base ()
		{
			this.Font = UIFont.FromName ("Helvetica", 24);
			this.SetTitleColor (UIColor.White, UIControlState.Normal);
			this.BackgroundColor = Color.White.MURAL ().ToNative ();
		}
	};

	public class ScreenStart : UIView
	{
		Router route;
		MainButton launchButton;

		public ScreenStart (Router route, CGRect frame) : base (frame)
		{
			this.route = route;
			this.Initialize ();
		}
			
		protected void Initialize()
		{
			this.BackgroundColor = UIColor.White;
			this.InitView ();
		}

		protected void InitView()
		{
			this.Hidden = false;
			this.launchButton = new MainButton ();
			this.launchButton.SetTitle ("To ScreenOne ->", UIControlState.Normal);
			this.launchButton.Events ().TouchUpInside.Subscribe ( _ => this.route.GoToScreenOne ());
			this.AddSubview (launchButton);

			this.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();
			var margin = 50;

			this.AddConstraints (
				this.launchButton.WithSameCenterX (this),
				this.launchButton.WithSameCenterY (this),
				this.launchButton.WithRelativeWidth (this, 0.2f)
			);
		}
	}
}

