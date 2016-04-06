using System;
using ReactiveUI;
using System.Collections;
using System.Linq;

namespace ReactiveIOSTest
{
	public class BaseViewModel : ReactiveObject, IDisposable
	{

		public virtual void Dispose()
		{
			var properties = this.GetType().GetProperties().Select(p => p.GetValue(this, null)).ToList();
			properties.Where(v => v is IList).Cast<IList>().ToList().ForEach(d => d.Clear());
			properties.Where(v => v is IDictionary).Cast<IDictionary>().ToList().ForEach(d => d.Clear());
			properties.Where(v => v is IDisposable).Cast<IDisposable>().ToList().ForEach(d => d.Dispose());
		}
	}
}

