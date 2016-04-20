using System;
using ReactiveUI;
using System.Drawing;

namespace ReactiveIOSTest.ViewModels
{

	public class ScreenOneViewModel : BaseViewModel
	{

		private bool _Visible;
		public bool Visible
		{
			get { return _Visible; }
			set { this.RaiseAndSetIfChanged (ref _Visible, value);} 
		}
			
		public ScreenOneViewModel () : base ()
		{
			this._Visible = true;
		}
	}
}

