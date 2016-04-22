
using System;
using ReactiveUI;
using System.Drawing;
using UIKit;

namespace ReactiveIOSTest.ViewModels
{

	public class ScreenFinalViewModel : BaseViewModel
	{

		private bool _Visible;
		public bool Visible
		{
			get { return _Visible; }
			set { this.RaiseAndSetIfChanged (ref _Visible, value);} 
		}

		public ScreenFinalViewModel () : base ()
		{
			this._Visible = true;
		}
	}
}

