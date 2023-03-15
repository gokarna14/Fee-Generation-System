using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnderstandingDelegate
{
    public delegate void TotalShippingFees(decimal price, ref decimal fee);
    public abstract class ShippingDestination
    {
        public bool isHighRisk;
        public virtual void CalculateFee(decimal price, ref decimal fee) { }

        public static ShippingDestination? GetDestinationZone(string zone)
        {
            if (zone == "zone1")
            {
                return new Dest_1();
            }
            if (zone == "zone2")
            {
                return new Dest_2();
            }
            if (zone == "zone3")
            {
                return new Dest_3();
            }
            if (zone == "zone4")
            {
                return new Dest_4();
            }

            return null;
        }
    }

    public class Dest_1 : ShippingDestination
    {
        string Name { get; }
        public Dest_1()
        {
            Name = "zone1";
            this.isHighRisk = false;
        }

        public override void CalculateFee(decimal price, ref decimal fee)
        {
            fee = price * 0.25m;
        }


    }
    public class Dest_2 : ShippingDestination
    {
        public string Name { get; }
        public Dest_2()
        {
            Name = "zone2";
            this.isHighRisk = true;
        }
        public override void CalculateFee(decimal price, ref decimal fee)
        {
            fee = price * 0.12m;
        }
    }
    public class Dest_3 : ShippingDestination
    {
        public string Name { get; }
        public Dest_3()
        {
            this.Name = "zone3";
            this.isHighRisk = false;
        }
        public override void CalculateFee(decimal price, ref decimal fee)
        {
            fee = price * 0.05m;
        }
    }
    public class Dest_4 : ShippingDestination
    {
        public string Name { get; }
        public Dest_4()
        {
            this.Name = "zone4";
            this.isHighRisk = true;
        }
        public override void CalculateFee(decimal price, ref decimal fee)
        {
            fee = price * 0.04m;
        }
    }
}