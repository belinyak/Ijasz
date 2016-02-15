using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Ijasz2.Common {
    class KorValidation : ValidationRule {


        public KorValidation() {
        }

        public KorValidation(ValidationStep validationStep, bool validatesOnTargetUpdated) : base(validationStep, validatesOnTargetUpdated) {
        }

        public override ValidationResult Validate( object value, CultureInfo cultureInfo ) {
            return value != null && value.ToString( ).Length == 0 ? new ValidationResult( false, "Kor validation error" ) : new ValidationResult( true, null );
        }
    }
}
