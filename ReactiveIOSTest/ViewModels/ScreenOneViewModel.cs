using System;
using ReactiveUI;
using System.Drawing;
using UIKit;

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
			
		private Color _SqrColorA;
		public Color SqrColorA
		{
			get { return _SqrColorA; }
			set { this.RaiseAndSetIfChanged(ref _SqrColorA, value); }
		}

		private Color _SqrColorB;
		public Color SqrColorB
		{
			get { return _SqrColorB; }
			set { this.RaiseAndSetIfChanged(ref _SqrColorB, value); }
		}

		private Color _SqrColorC;
		public Color SqrColorC
		{
			get { return _SqrColorC; }
			set { this.RaiseAndSetIfChanged(ref _SqrColorC, value); }
		}

		private int _Sa;
		public int Sa
		{
			get { return _Sa; }
			set { this.RaiseAndSetIfChanged(ref _Sa, value); }
		}

		private string _Sa1;
		public string Sa1
		{
			get { return _Sa1; }
			set { this.RaiseAndSetIfChanged(ref _Sa1, value); }
		}

		private UIView _Sa2;
		public UIView Sa2
		{
			get { return _Sa2; }
			set { this.RaiseAndSetIfChanged(ref _Sa2, value); }
		}

		private UIButton _Sa3;
		public UIButton Sa3
		{
			get { return _Sa3; }
			set { this.RaiseAndSetIfChanged(ref _Sa3, value); }
		}


		public ScreenOneViewModel () : base ()
		{
			this._Visible = true;
		}
	}
}

