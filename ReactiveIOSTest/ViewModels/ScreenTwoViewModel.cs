using System;
using ReactiveUI;

namespace ReactiveIOSTest.ViewModels
{
	public class ScreenTwoViewModel : BaseViewModel
	{
		public enum Incrementals 
		{
			SQRA = 45,
			SQRB = 270,
			SQRC = 90,
			SQRD = 180,
		}
		private bool _Visible;
		public bool Visible
		{
			get { return _Visible; }
			set { this.RaiseAndSetIfChanged(ref _Visible, value); }
		}

		private float _SqrRotationA;
		public float SqrRotationA
		{
			get { return _SqrRotationA; }
			set { 
				if (value > 360) 
					value -= 360;
				this.RaiseAndSetIfChanged(ref _SqrRotationA, value); 
			}
		}

		private float _SqrRotationB;
		public float SqrRotationB
		{
			get { return _SqrRotationB; }
			set {
				if (value > 360) 
					value -= 360;
				this.RaiseAndSetIfChanged(ref _SqrRotationB, value); 
			}
		}

		private float _SqrRotationC;
		public float SqrRotationC
		{
			get { return _SqrRotationC; }
			set {
				if (value > 360) 
					value -= 360;
				this.RaiseAndSetIfChanged(ref _SqrRotationC, value);
			}
		}

		private float _SqrRotationD;
		public float SqrRotationD
		{
			get { return _SqrRotationD; }
			set { 			
				if (value > 360) 
					value -= 360;
				this.RaiseAndSetIfChanged(ref _SqrRotationD, value); 
			}
		}

		public ScreenTwoViewModel () : base ()
		{
			this.Visible = true;
		}
			
	}
}

