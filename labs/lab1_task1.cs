using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_Z1
{
    interface mobilePhone
    {
        string toString();
        void TurnOff();
        void Call();
    }

    public abstract class Sony: mobilePhone
    {
        public abstract string toString();
        public abstract void Call();
        public abstract void TurnOff();
        public abstract void TurnOn();
        public abstract void LowBattery();
    }

    public class Model: Sony, mobilePhone
    {
        string vendor, model;
        double screenSize;
        enum State {TurnedOn, TurnedOff, CallMode, NotCallMode, LowBattery};
        State PowSt;
        static int MemberCount;
        State PowerState
        {
            get
            {
                return PowSt;
            }
            set
            {
                PowSt = value;
                Console.WriteLine(this.toString());
            }
        }
        public Model(string ven, string mdl, double scrSz )
        {
            vendor = ven;
            model = mdl;
            screenSize = scrSz;
            PowerState = State.TurnedOff;
            MemberCount++;
        }

        public static int GetMemberCount()
        {
            return MemberCount;
        }

        public override string toString()
        {
            return vendor + " " + model + ". Screen size is " + screenSize + ". Power state is: " + PowerState;
        }

        public override void TurnOff()
        {
            PowerState = State.TurnedOff;
        }

        public override void TurnOn()
        {
            PowerState = State.TurnedOn;
        }

        public override void Call()
        {
            PowerState = State.CallMode;
        }
        
        public override void LowBattery()
        {
            PowerState = State.LowBattery;
        }


    }
    class Program
    {
        static void Main(string[] args)
        {
            Model Lenovo = new Model("Lenovo", "P90", 5.5);
            Lenovo.TurnOn();
            Lenovo.Call();
            Lenovo.LowBattery();
            Lenovo.TurnOff();
            Console.WriteLine(Model.GetMemberCount());

            Model iPhone = new Model("iPhone", "4S", 4.0);
            iPhone.TurnOn();
            iPhone.Call();
            iPhone.LowBattery();
            iPhone.TurnOff();
            Console.WriteLine(Model.GetMemberCount());

            Model Samsung = new Model("Samsung", "S3", 4.7);
            Samsung.TurnOn();
            Samsung.LowBattery();
            Samsung.TurnOff();
        }
    }
}
