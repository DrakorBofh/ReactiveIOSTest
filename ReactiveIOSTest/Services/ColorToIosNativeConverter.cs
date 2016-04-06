using System;
using ReactiveUI;
using System.Drawing;
using Splat;

namespace ReactiveIOSTest
{
	public class ColorToIosNativeConverter : IBindingTypeConverter
	{
		public ColorToIosNativeConverter ()
		{
		}

		public int GetAffinityForObjects (Type fromType, Type toType)
		{
			if (fromType == typeof(System.Drawing.Color) || fromType == typeof(UIKit.UIColor))
			{
				return 100; 
			}
			return 0;
		}

		public bool TryConvert (object from, Type toType, object conversionHint, out object result)
		{
			try
			{
				result = ((Color)from).ToNative();
			}
			catch (Exception ex)
			{
				this.Log().WarnException("Couldn't convert object to type: " + toType, ex);
				result = null;
				return false;
			}

			return true;
		}


	}
}

