using System;
using System.Collections.Generic;
using CoreGraphics;
using ReactiveIOSTest.Views;
using ReactiveIOSTest.ViewModels;
using System.Threading.Tasks;
using System.Reactive.Linq;
using ReactiveUI;
using System.Linq;
using System.Runtime.Serialization;
using UIKit;
using Splat;
using System.Drawing;
using Cirrious.FluentLayouts.Touch;
using Foundation;

namespace ReactiveIOSTest
{
	public class Router : ReactiveObject
	{
		private readonly UIView context;
		private readonly CGRect viewSize;
		private readonly ApplicationViewController controller;

		public string OpenMuralRequestCode { set; private get; }

		public Router (ApplicationViewController controller)
		{
			this.controller = controller;
			this.context = controller.View;
			this.viewSize = controller.ViewSize;
			this.controller.Router = this;
		}

		public void GoToScreenStart ()
		{
			this.GoTo<ScreenStart> ();
		}
			
		public void GoToScreenOne ()
		{
			var viewModel = new ScreenOneViewModel();
			this.GoTo<ScreenOne> (viewModel);
		}

		public void GoToScreenTwo ()
		{
			var viewModel = new ScreenTwoViewModel();
			this.GoTo<ScreenTwo> (viewModel);
		}

		public void GoToScreenFinal ()
		{
			var viewModel = new ScreenFinalViewModel();
			this.GoTo<ScreenFinal> (viewModel);
		}


		private void GoTo<T> (params object[] args) where T : UIView
		{
			//DisposableHelper.Current.ClearAll ();
			this.Go<T> (args);
		}

		private void Go<T> (params object[] args) where T : UIView
		{
			Console.WriteLine ("GO TO " + typeof(T).ToString ());

			var options = new object[] { this, viewSize }.Concat (args).ToArray ();
			var view = (T)Activator.CreateInstance (typeof(T), options);
			context.AddSubview (view);
			context.Subviews.Where (v => v != view).ToList().ForEach(v => v.DisposeEx());
			GC.Collect ();
		}
	}
}