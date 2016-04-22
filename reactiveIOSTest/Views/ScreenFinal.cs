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


namespace ReactiveIOSTest
{
	public class ScreenFinal : BaseView<ScreenFinalViewModel>
	{
		Router route;
		private UIButton backScreenButton;

		public ScreenFinal ( Router route, CGRect frame, ScreenFinalViewModel viewModel) : base()
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
			backScreenButton.Events ().TouchUpInside.Subscribe ( _ => this.route.GoToScreenTwo ());

			this.AddSubview (backScreenButton);

			this.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();
			var margin = 50;

			this.AddConstraints (
				backScreenButton.AtTopOf  (this, margin),
				backScreenButton.WithSameCenterX (this),
				backScreenButton.WithRelativeWidth (this, 0.3f)
			);
		}

	}

}

