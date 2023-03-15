using UnderstandingDelegate;

public class Entry
{
    public static ShippingDestination? TheDestintion { get; private set; }

    public static void Main(string[] args)
    {
        string zone = "";
        decimal Price;
        
        TotalShippingFees FeeDel;

        // NormalFee Zone1 = NormalFee();

        while (zone != "exit")
        {
            System.Console.Write("Enter the destination zone: ");
            zone = Console.ReadLine() ?? "";

            TheDestintion = ShippingDestination.GetDestinationZone(zone);


            Console.Write($"Enter the item price: ");
            

            if (decimal.TryParse(Console.ReadLine() ?? "0.0", out Price) && TheDestintion != null)
            {
                decimal grandTotalFee = 0.0m;
                FeeDel = TheDestintion.CalculateFee;

                FeeDel(price: Price, fee: ref grandTotalFee);
                if (TheDestintion.isHighRisk)
                {
                    grandTotalFee += 25;
                }

                System.Console.WriteLine($"The grand total fees are : {grandTotalFee}");
            }
            else
            {
                System.Console.WriteLine("Invalid Input !!");
            }
        }
    }
}