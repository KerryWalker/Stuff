using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAPI
{
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
	public sealed class CannotBeEmptyAttribute : RequiredAttribute
	{
		public override bool IsValid(object value)
		{
			var list = value as IEnumerable;
			return list != null && list.GetEnumerator().MoveNext();
		}
	}
}
