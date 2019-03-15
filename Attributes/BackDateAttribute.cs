using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple =false)]
    public class BackDateAttribute : ValidationAttribute
    {
        public DateTime MaximumDate { get; private set; }
        public bool AllowNulls { get; private set; }

        /// <summary>
				/// Gets a value that indicates whether the attribute requires validation context.
				/// </summary>
				/// <returns><c>true</c> if the attribute requires validation context; otherwise, <c>false</c>.</returns>
				public override bool RequiresValidationContext
        {
            get { return true; }
        }
				
        /// <summary>
        /// Initializes a new instance of the <see cref="BackDateAttribute"/> class.
        /// </summary>
        /// <param name="allowNulls">if set to <c>true</c> [allow nulls].</param>
        public BackDateAttribute(bool allowNulls = false)
        :base()
        {
            AllowNulls = allowNulls;
            MaximumDate = DateTime.Today;
        }

        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return AllowNulls;
            }
            DateTime dtValue = DateTime.Parse(value.ToString(), CultureInfo.InvariantCulture);
            return DateTime.Compare(MaximumDate, dtValue) < 0;
        }
    }
}
