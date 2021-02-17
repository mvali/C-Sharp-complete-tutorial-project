using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp
{
    // Factory Method is a Design Pattern which defines an interface for creating an object but lets the classes that implement the interface decide which class to instantiate
    // type of the object instantiated can be determined at run-time
    class DesignpatternFactory
    {
        public void RunF()
        {
            string cardNameUI = Console.ReadLine();

            // access child method at runtime based on user input
            CardActions ccaction = cardNameUI switch
            {
                "titanium" => new TitaniumCardAction(5000),
                "platinum" => new PlatinumCardAction(500, 10000),
                _ => throw new NotImplementedException()
            };

            CreditCard creditCardUsed = ccaction.GetCreditCard();
            Console.WriteLine($"Your card: {cardNameUI} details below:\n cardType: {creditCardUsed.CardType}, cardAnualCharge: {creditCardUsed.AnnualCharge}");
        }
    }

    abstract class CreditCard
    {
        public abstract string CardType { get; }
        public abstract int AnnualCharge { get; set; }
    }
    class TitaniumCreditCard : CreditCard
    {
        private readonly string _cardType;
        private int _annualCharge;
        public override string CardType
        {
            get { return _cardType; }
        }
        public override int AnnualCharge
        {
            get { return _annualCharge; }
            set { _annualCharge = value; }
        }
        public TitaniumCreditCard(int annualCharge)
        {
            _cardType = "Titanium";
            _annualCharge = annualCharge;
        }
    }
    class PlatinumCreditCard : CreditCard
    {
        private readonly string _cardType;
        private int _annualCharge;

        public override string CardType
        {
            get { return _cardType; }
        }
        public override int AnnualCharge
        {
            get { return _annualCharge; }
            set { _annualCharge = value; }
        }

        public PlatinumCreditCard(int annualCharge)
        {
            _cardType = "Platinum";
            _annualCharge = annualCharge;
        }
    }

    abstract class CardActions
    {
        public abstract CreditCard GetCreditCard();
    }
    class TitaniumCardAction : CardActions
    {
        private int _annualCharge;
        
        // constructor of child class
        public TitaniumCardAction(int annualCharge)
        {
            _annualCharge = annualCharge;
        }
        public override CreditCard GetCreditCard()
        {
            return new TitaniumCreditCard(_annualCharge);
        }
    }
    class PlatinumCardAction : CardActions
    {
        private int _creditLimit;
        private int _annualCharge;

        public PlatinumCardAction(int creditLimit, int annualCharge)
        {
            _creditLimit = creditLimit;
            _annualCharge = annualCharge;
        }

        public override CreditCard GetCreditCard()
        {
            return new PlatinumCreditCard(_annualCharge);
        }
    }

}
