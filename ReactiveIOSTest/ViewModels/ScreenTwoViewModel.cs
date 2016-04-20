using System;
using ReactiveUI;

namespace ReactiveIOSTest.ViewModels
{
	public class ScreenTwoViewModel : BaseViewModel
	{
		private bool _Visible;
		public bool Visible
		{
			get { return _Visible; }
			set { this.RaiseAndSetIfChanged (ref _Visible, value);} 
		}

		public ScreenTwoViewModel () : base ()
		{
			this.Visible = true;
		}
			
	}
}

