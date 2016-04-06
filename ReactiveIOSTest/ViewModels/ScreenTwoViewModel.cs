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

		public ReactiveCommand<object> BackScreenCommand { get; private set; }
		public ReactiveCommand<object> RotateAdyACommand { get; private set; }
		public ReactiveCommand<object> RotateAdyBCommand { get; private set; }
		public ReactiveCommand<object> RotateAdyCCommand { get; private set; }
		public ReactiveCommand<object> RotateAdyDCommand { get; private set; }

		public ScreenTwoViewModel (float sqrRotationA, float sqrRotationB, float sqrRotationC, float sqrRotationD) : base ()
		{
			this.SqrRotationA = sqrRotationA;
			this.SqrRotationB = sqrRotationB;
			this.SqrRotationC = sqrRotationC;
			this.SqrRotationD = sqrRotationD;

			this.Visible = true;
			this.BackScreenCommand = ReactiveCommand.Create();
			this.BackScreenCommand.Subscribe(_ => this.Visible = false);

			this.RotateAdyACommand = ReactiveCommand.Create();
			this.RotateAdyACommand.Subscribe(_ =>this.RotateAdyA ());
			this.RotateAdyBCommand = ReactiveCommand.Create();
			this.RotateAdyBCommand.Subscribe(_ =>this.RotateAdyB ());
			this.RotateAdyCCommand = ReactiveCommand.Create();
			this.RotateAdyCCommand.Subscribe(_ =>this.RotateAdyC ());
			this.RotateAdyDCommand = ReactiveCommand.Create();
			this.RotateAdyDCommand.Subscribe(_ =>this.RotateAdyD ());
		}

		private void RotateAdyA()
		{
			this.SqrRotationA += (int)Incrementals.SQRA;
			this.SqrRotationB += (int)Incrementals.SQRA;
			this.SqrRotationC += (int)Incrementals.SQRA;
		}

		private void RotateAdyB()
		{
			this.SqrRotationB += (int)Incrementals.SQRB;
			this.SqrRotationA += (int)Incrementals.SQRB;
			this.SqrRotationD += (int)Incrementals.SQRB;
		}

		private void RotateAdyC()
		{
			this.SqrRotationC += (int)Incrementals.SQRC;
			this.SqrRotationA += (int)Incrementals.SQRC;
			this.SqrRotationD += (int)Incrementals.SQRC;
		}

		private void RotateAdyD()
		{
			this.SqrRotationD += (int)Incrementals.SQRD;
			this.SqrRotationB += (int)Incrementals.SQRD;
			this.SqrRotationC += (int)Incrementals.SQRD;
		}
	}
}

