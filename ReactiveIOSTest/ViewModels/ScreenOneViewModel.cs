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
			set { this.RaiseAndSetIfChanged(ref _Visible, value); }
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

		public ReactiveCommand<object> NextScreenCommand { get; private set; }
		public ReactiveCommand<object> ChangeRandomColorCommand { get; private set; }

		public ScreenOneViewModel (Color sqrColorA, Color sqrColorB, Color sqrColorC) : base ()
		{
			this.SqrColorA = sqrColorA;
			this.SqrColorB = sqrColorB;
			this.SqrColorC = sqrColorC;
			this._Visible = true;
			this.NextScreenCommand = ReactiveCommand.Create();
			this.NextScreenCommand.Subscribe(_ => this.Visible = false);
			this.ChangeRandomColorCommand = ReactiveCommand.Create();
			this.ChangeRandomColorCommand.Subscribe(_ => randomizeColors());

		}

		private void randomizeColors()
		{
			Random rnd = new Random();
			int sqr = rnd.Next(1, 4);

			switch (sqr)
			{
			case 1:
				SqrColorA = Color.White.GetPalletteRandom();
				break;
			case 2:
				SqrColorB = Color.Beige.GetPalletteRandom();
				break;
			default:
				SqrColorC = Color.Beige.GetPalletteRandom();
				break;
			}

		}


	}
}

