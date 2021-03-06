﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FractionsTest
{
    public class Fraction

    {
        public int numerator { get; }
        public int denumerator { get; }

        public Fraction(int n, int d = 1)
        {

            //Denumerator not = 0
            if (d == 0)
                throw new ArgumentException(nameof(d));

            this.numerator = n;
            this.denumerator = d;

            //Sign
            if (this.denumerator < 0)
            {
                    this.numerator = -numerator;
                    this.denumerator = -denumerator;
            }
           
            //Normal Form
            for (int i = Math.Abs(this.numerator * this.denumerator); i > 1; i--)
            {
                if ((this.numerator % i == 0) && (this.denumerator % i == 0))
                {
                    this.numerator /= i;
                    this.denumerator /= i;
                }
            }
        }

        //Overload + operator
        public static Fraction operator+ (Fraction f1, Fraction f2)
        {
            int _newNumerator = ((f1.numerator * f2.denumerator) +
                                 (f2.numerator * f1.denumerator));
                               
            int _newDenominator = (f1.denumerator * f2.denumerator);

            return new Fraction(_newNumerator, _newDenominator);
        }

        //Overload * operator
        public static Fraction operator *(Fraction f1, Fraction f2)
        {
            return new Fraction(f1.numerator * f2.numerator, f1.denumerator * f2.denumerator);
        }

        //Overload - operator
        public static Fraction operator -(Fraction f1, Fraction f2)
        {
            int _newNumerator = ((f1.numerator * f2.denumerator) -
                                 (f2.numerator * f1.denumerator));

            int _newDenominator = (f1.denumerator * f2.denumerator);

            return new Fraction(_newNumerator, _newDenominator);
        }

        //Overload / operator
        public static Fraction operator /(Fraction f1, Fraction f2)
        {
            return new Fraction(f1.numerator * f2.denumerator, f1.denumerator * f2.numerator);
        }

        //Override ToString
        public override string ToString()
        {
            if(this.denumerator != 1)
            return this.numerator + "/" + this.denumerator;
            return this.numerator.ToString();
        }

        //Override Equals
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (obj.GetType() == typeof(Fraction))
            {
                Fraction other = (Fraction) obj;
                return this.numerator == other.numerator && this.denumerator == other.denumerator
                       && this.denumerator == other.denumerator;
            }
            return false;
        }


        static void Main(string[] args)
        {
        }
    }
}
