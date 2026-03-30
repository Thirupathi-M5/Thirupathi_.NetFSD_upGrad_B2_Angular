using System;

namespace Solids
{

    public interface IPrinter
    {
        void Print();
    }

    public interface IScanner
    {
        void Scan();
    }

    public interface IFax
    {
        void Fax();
    }

    public class BasicPrinter : IPrinter
    {
        public void Print()
        {
            Console.WriteLine("Basic Printer: Printing...");
        }
    }


    public class AdvancedPrinter : IPrinter, IScanner, IFax
    {
        public void Print()
        {
            Console.WriteLine("Advanced Printer: Printing...");
        }

        public void Scan()
        {
            Console.WriteLine("Advanced Printer: Scanning...");
        }

        public void Fax()
        {
            Console.WriteLine("Advanced Printer: Faxing...");
        }
    }

    //  ISP Class (Main Execution)
    internal class ISP
    {
        public static void Main(string[] args)
        {

            IPrinter basic = new BasicPrinter();
            basic.Print();

            Console.WriteLine();

            AdvancedPrinter advanced = new AdvancedPrinter();
            advanced.Print();
            advanced.Scan();
            advanced.Fax();

            Console.ReadLine();
        }
    }
}