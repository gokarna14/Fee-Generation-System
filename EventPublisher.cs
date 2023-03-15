using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnderstandingDelegate
{

    public delegate void MyEvenetHandler(string value);

    public class EventPublisher
    {

        private string Value = "";

        public event MyEvenetHandler? valueChanged;

        public string Val 
        {
            set {
                this.Value = value;
                if(this.valueChanged != null)
                    this.valueChanged(this.Value);
            }
        }
    }

    class Program
    {
        public static void Start()
        {
            EventPublisher obj = new EventPublisher();

            // obj.valueChanged += new MyEvenetHandler(obj_ValueChanged);

            obj.valueChanged += delegate (string val)
            {
                System.Console.WriteLine($"The value cahnged to {val}");
            };


            string str;
            do
            {
                System.Console.WriteLine("Enter a value: ");
                str = Console.ReadLine() ?? "";
                if (!str.Equals("exit"))
                {
                    obj.Val = str;
                }
            } while (!str.Equals("exit"));
        }

        static void obj_ValueChanged(string value)
        {
            System.Console.WriteLine($"The value changed to {value}");
        }
    }
}