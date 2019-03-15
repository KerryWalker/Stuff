using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAPI.Attributes
{
	public class EmptyOrMinLengthAttribute : MinLengthAttribute
	{
		public EmptyOrMinLengthAttribute(int length) : base(length)
		{
		}

		public override bool IsValid(object value)
		{
			if (value == null)
			{
				return true;
			}
			if (string.IsNullOrEmpty(value.ToString())){
				return true;
			}
			return base.IsValid(value);
		}
	}
}
