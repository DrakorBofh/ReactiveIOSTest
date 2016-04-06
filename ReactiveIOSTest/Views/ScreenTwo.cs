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
	public class RotativeButton: UIButton
	{
		public RotativeButton () : base ()
		{
			this.Font = UIFont.FromName ("Helvetica", 24);
			this.SetTitleColor (UIColor.White, UIControlState.Normal);
		}
	};
		
	public class ScreenTwo : BaseView<ScreenTwoViewModel>
	{
		Router route;
	
		private RotativeButton sqrRotationA;
		private RotativeButton sqrRotationB;
		private RotativeButton sqrRotationC;
		private RotativeButton sqrRotationD;
		private UIView separator;
		private UITextView informationText;
		private UIButton backScreenButton;

		public ScreenTwo ( Router route, CGRect frame, ScreenTwoViewModel viewModel) : base()
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
			sqrRotationA = new RotativeButton (){BackgroundColor = Color.White.SMooth().ToNative()};
			sqrRotationA.SetTitle ( ((int)ScreenTwoViewModel.Incrementals.SQRA).ToString (), UIControlState.Normal);
			sqrRotationB = new RotativeButton (){BackgroundColor = Color.White.FResh().ToNative()};
			sqrRotationB.SetTitle ( ((int)ScreenTwoViewModel.Incrementals.SQRB).ToString (), UIControlState.Normal);
			sqrRotationC = new RotativeButton (){BackgroundColor = Color.White.Micadormissador().ToNative()};
			sqrRotationC.SetTitle ( ((int)ScreenTwoViewModel.Incrementals.SQRC).ToString (), UIControlState.Normal);
			sqrRotationD = new RotativeButton (){BackgroundColor = Color.White.GIMME().ToNative()};
			sqrRotationD.SetTitle ( ((int)ScreenTwoViewModel.Incrementals.SQRD).ToString (), UIControlState.Normal);

			separator = new UIView (){ BackgroundColor = UIColor.Gray };
			informationText = new UITextView (){ Text = "Just tap a box to rotate the adyacents. Each box rotates different. Try to aligne all the boxes, if you can.", TextColor = UIColor.DarkGray, Font = UIFont.FromName ("Helvetica",24), TextAlignment = UITextAlignment.Center, ScrollEnabled = false };
			backScreenButton = new NavButton ();
			backScreenButton.SetTitle ("To previous Screen", UIControlState.Normal);
			backScreenButton.Events ().TouchUpInside.Subscribe ( _ => this.route.GoToScreenOne ());

			this.AddSubview (sqrRotationA);
			this.AddSubview (sqrRotationB);
			this.AddSubview (sqrRotationC);
			this.AddSubview (sqrRotationD);
			this.AddSubview (separator);
			this.AddSubview (informationText);
			this.AddSubview (backScreenButton);

			this.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();
			var margin = 50;

			this.AddConstraints (

				informationText.AtTopOf  (this, margin),
				informationText.AtLeftOf (this, margin),
				informationText.AtRightOf (this, margin),
				informationText.WithRelativeHeight (sqrRotationA, 0.5f),

				sqrRotationA.Below  (informationText, margin),
				sqrRotationA.WithRelativeWidth (this, 0.15f),
				sqrRotationA.Height ().EqualTo ().WidthOf (sqrRotationA),
				sqrRotationA.Right ().EqualTo (-margin).CenterXOf (this),

				sqrRotationB.WithSameCenterY(sqrRotationA),
				sqrRotationB.WithSameWidth (sqrRotationA),
				sqrRotationB.WithSameHeight (sqrRotationA),
				sqrRotationB.Left ().EqualTo (margin).CenterXOf (this),

				sqrRotationC.Below (sqrRotationA, margin),
				sqrRotationC.WithSameWidth (sqrRotationA),
				sqrRotationC.WithSameHeight (sqrRotationA),
				sqrRotationC.WithSameCenterX (sqrRotationA),

				sqrRotationD.WithSameWidth (sqrRotationA),
				sqrRotationD.WithSameHeight (sqrRotationA),
				sqrRotationD.WithSameCenterX (sqrRotationB),
				sqrRotationD.WithSameCenterY (sqrRotationC),

				separator.Below  (sqrRotationC, margin),
				separator.AtLeftOf (this, margin),
				separator.AtRightOf (this, margin),
				separator.Height ().EqualTo (3f),

				backScreenButton.Below  (separator, margin),
				backScreenButton.WithSameCenterX (this),
				backScreenButton.WithRelativeWidth (this, 0.3f)
			);
		}

		protected virtual void SubscribeToViewModel ()
		{
			this.WhenActivated(dispose =>
				{
					dispose(this.BindCommand(this.ViewModel, vm => vm.RotateAdyACommand, v => v.sqrRotationA));
					dispose(this.BindCommand(this.ViewModel, vm => vm.RotateAdyBCommand, v => v.sqrRotationB));
					dispose(this.BindCommand(this.ViewModel, vm => vm.RotateAdyCCommand, v => v.sqrRotationC));
					dispose(this.BindCommand(this.ViewModel, vm => vm.RotateAdyDCommand, v => v.sqrRotationD));
					dispose(this.WhenAnyValue ( v => v.ViewModel.SqrRotationA).Subscribe ( x => this.OnSqrRotationChanged(sqrRotationA, x)));
					dispose(this.WhenAnyValue ( v => v.ViewModel.SqrRotationB).Subscribe ( x => this.OnSqrRotationChanged(sqrRotationB, x)));
					dispose(this.WhenAnyValue ( v => v.ViewModel.SqrRotationC).Subscribe ( x => this.OnSqrRotationChanged(sqrRotationC, x)));
					dispose(this.WhenAnyValue ( v => v.ViewModel.SqrRotationD).Subscribe ( x => this.OnSqrRotationChanged(sqrRotationD, x)));
				});
		}

		public void OnSqrRotationChanged(UIButton sqr, float rotation)
		{
			sqr.Transform = CGAffineTransform.MakeIdentity ();
			sqr.Transform = CGAffineTransform.MakeRotation (rotation);
		}
	}

}

