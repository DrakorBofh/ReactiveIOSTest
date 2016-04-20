using System;
using ReactiveUI.Cocoa;
using ReactiveUI;
using CoreGraphics;
using UIKit;
using ReactiveIOSTest.ViewModels;
using GameKit;
using System.Drawing;
using System.Runtime.CompilerServices;
using Cirrious.FluentLayouts.Touch;
using Splat;

namespace ReactiveIOSTest.Views
{
	public class ScreenOne : BaseView<ScreenOneViewModel>
	{
		Router route;
		private UIButton nextScreenButton;
		private UIButton backScreenButton;

		public ScreenOne ( Router route, CGRect frame, ScreenOneViewModel viewModel ) : base()
		{
			this.route = route;
			this.ViewModel = viewModel;
			this.Frame = frame;
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

			backScreenButton = new NavButton ();
			backScreenButton.SetTitle ("To previous Screen", UIControlState.Normal);
			backScreenButton.Events ().TouchUpInside.Subscribe ( _ => this.route.GoToScreenStart ());
			nextScreenButton = new NavButton ();
			nextScreenButton.SetTitle ("To next Screen", UIControlState.Normal);
			nextScreenButton.Events ().TouchUpInside.Subscribe ( _ => this.route.GoToScreenTwo ());

			this.AddSubview (nextScreenButton);
			this.AddSubview (backScreenButton);

			this.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();
			var margin = 50;

			this.AddConstraints (

				nextScreenButton.AtTopOf  (this, margin),
				nextScreenButton.WithSameCenterX (this),
				nextScreenButton.WithRelativeWidth (this, 0.2f),

				backScreenButton.Below  (nextScreenButton, margin),
				backScreenButton.WithSameCenterX (this),
				backScreenButton.WithRelativeWidth (this, 0.3f)
			);
		}
			
	}
}

