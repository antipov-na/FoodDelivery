using System;
using ValueOf;

namespace Domain.Entities.ValueObjects
{
    public class Price : ValueOf<decimal, Price>
    {
        protected override void Validate()
        {
            if ( Value < 0)
            {
                throw new NegativePriceExeption(Value);
            }   
        }
    }

    public class NegativePriceExeption : Exception
    {
        public NegativePriceExeption(decimal price) 
            : base($"Price cannot be less then zero. Current value: {price}.")
        {
        }
    }
}
