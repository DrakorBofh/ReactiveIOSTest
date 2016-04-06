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

		private UIButton sqrColorA;
		private UIButton sqrColorB;
		private UIButton sqrColorC;
		private UIView separator;
		private UITextView informationText;
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
			this.SubscribeToViewModel ();
		}

		protected void InitView()
		{
			this.Hidden = false;
			sqrColorA = new UIButton ();
			sqrColorB = new UIButton ();
			sqrColorC = new UIButton ();

			backScreenButton = new NavButton ();
			backScreenButton.SetTitle ("To previous Screen", UIControlState.Normal);
			backScreenButton.Events ().TouchUpInside.Subscribe ( _ => this.route.GoToScreenStart ());

			separator = new UIView (){ BackgroundColor = UIColor.Gray };
			informationText = new UITextView (){ Text = "Just tap on any color box to aleatory change color of other color box.", TextColor = UIColor.DarkGray, Font = UIFont.FromName ("Helvetica",24), TextAlignment = UITextAlignment.Center, ScrollEnabled = false };
			nextScreenButton = new NavButton ();
			nextScreenButton.SetTitle ("To next Screen", UIControlState.Normal);
			nextScreenButton.Events ().TouchUpInside.Subscribe ( _ => this.route.GoToScreenTwo ());

			this.AddSubview (sqrColorA);
			this.AddSubview (sqrColorB);
			this.AddSubview (sqrColorC);
			this.AddSubview (separator);
			this.AddSubview (informationText);
			this.AddSubview (nextScreenButton);
			this.AddSubview (backScreenButton);

			this.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();
			var margin = 50;

			this.AddConstraints (

				informationText.AtTopOf  (this, margin),
				informationText.AtLeftOf (this, margin),
				informationText.AtRightOf (this, margin),
				informationText.WithRelativeHeight (sqrColorA, 0.5f),

				sqrColorA.AtTopOf  (informationText, margin),
				sqrColorA.WithRelativeWidth (this, 0.2f),
				sqrColorA.Height ().EqualTo ().WidthOf (sqrColorA),
				sqrColorA.AtLeftOf (this, margin),

				sqrColorB.WithSameCenterY(sqrColorA),
				sqrColorB.WithSameWidth (sqrColorA),
				sqrColorB.WithSameHeight (sqrColorA),
				sqrColorB.WithSameCenterX (this),

				sqrColorC.WithSameCenterY(sqrColorA),
				sqrColorC.WithSameWidth (sqrColorA),
				sqrColorC.WithSameHeight (sqrColorA),
				sqrColorC.AtRightOf (this, margin ),

				separator.AtBottomOf  (sqrColorB, -margin),
				separator.AtLeftOf (this, margin),
				separator.AtRightOf (this, margin),
				separator.Height ().EqualTo (5f),

				nextScreenButton.AtBottomOf  (separator, -margin * 3),
				nextScreenButton.WithSameCenterX (this),
				nextScreenButton.WithRelativeWidth (this, 0.2f),

				backScreenButton.Below  (nextScreenButton, margin),
				backScreenButton.WithSameCenterX (this),
				backScreenButton.WithRelativeWidth (this, 0.3f)
			);
		}
			

		protected virtual void SubscribeToViewModel ()
		{
			this.WhenActivated(dispose =>
				{
					dispose(this.BindCommand(this.ViewModel, vm => vm.ChangeRandomColorCommand, v => v.sqrColorA));
					dispose(this.BindCommand(this.ViewModel, vm => vm.ChangeRandomColorCommand, v => v.sqrColorB));
					dispose(this.BindCommand(this.ViewModel, vm => vm.ChangeRandomColorCommand, v => v.sqrColorC));
					dispose(this.OneWayBind(this.ViewModel, vm => vm.SqrColorA, v => v.sqrColorA.BackgroundColor));
					dispose(this.OneWayBind(this.ViewModel, vm => vm.SqrColorB, v => v.sqrColorB.BackgroundColor));
					dispose(this.OneWayBind(this.ViewModel, vm => vm.SqrColorC, v => v.sqrColorC.BackgroundColor));
				});
		}
	}
}

