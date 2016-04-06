using System;
using ReactiveUI.Cocoa;
using ReactiveUI;
using UIKit;



namespace ReactiveIOSTest
{
	public class BaseView<T> : ReactiveView, IViewFor<T> where T : BaseViewModel //BaseView : ReactiveView
	{

		T _ViewModel;

		public T ViewModel
		{
			get { return _ViewModel; }
			set { this.RaiseAndSetIfChanged (ref _ViewModel, value);}
		}

		object IViewFor.ViewModel
		{
			get { return ViewModel; }
			set { ViewModel = (T)value; }
		}

		public BaseView ()
		{
		}
			
		public override void RemoveFromSuperview ()
		{
			base.RemoveFromSuperview ();

			var frame = this.Frame;
			frame.Y = 0;
			this.Frame = frame;

			this.EndEditing (true);
		}

	}
}

