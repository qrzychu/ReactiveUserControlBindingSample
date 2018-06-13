using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactiveValidation;
using ReactiveValidation.Extensions;

namespace ReactiveUseControlBindingSample
{
    public class ItemValidation : ValidatableObject
    {
        private double _weight;

        public  ItemValidation()
        {
            Validator = GetValidator();
        }

        private IObjectValidator GetValidator()
        {
            var builder = new ValidationBuilder<ItemValidation>();

            builder.RuleFor(x => x.Weight).GreaterThan(0);

            return builder.Build(this);
        }

        public double Weight
        {
            get { return _weight; }
            set { _weight = value; OnPropertyChanged();}
        }
    }
}
