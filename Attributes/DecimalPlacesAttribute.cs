using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class DecimalPlacesAttribute : RegularExpressionAttribute
    {
        public int DecimalPlaces { get; set; }
        public DecimalPlacesAttribute(int decimalPlaces)
            : base(string.Format(@"^-?\d*\.?\d{{0,{0}}}$", decimalPlaces))
        {
            DecimalPlaces = decimalPlaces;
        }

        public override string FormatErrorMessage(string name)
        {
            return string.Format("This value can have maximum {0} decimal places", DecimalPlaces);
        }
    }
}
