using System;
using UIKit;
using CoreGraphics;
using System.Collections.Generic;
using ReactiveUI;
using System.Reactive.Linq;
using System.Threading.Tasks;
using Foundation;
using System.Linq;
using Splat;

namespace ReactiveIOSTest.Views
{
	public class ApplicationViewController : UIViewController
	{
		public  Router Router { get; set; }

		public ApplicationViewController()
		{
		}

		public override async void ViewDidLoad()
		{
			base.ViewDidLoad ();
			this.View.BackgroundColor = new UIColor (232 / 255f, 232 / 255f, 232 / 255f, 1);

			while (this.Router == null)
				await Task.Delay (10);

			Locator.CurrentMutable.RegisterConstant(
				new ColorToIosNativeConverter(), typeof(IBindingTypeConverter));

			this.Router.GoToScreenStart ();
		}

		public CGRect ViewSize
		{
			get
			{
				var size = this.View.Frame.Size;
				var max = (nfloat)Math.Max(size.Width, size.Height);
				var min = (nfloat)Math.Min(size.Width, size.Height);
				return  new CGRect(0, 0, max, min) ;
			}
		}
	}
}