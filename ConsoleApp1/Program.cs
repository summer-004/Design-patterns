using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Vehicle v = new Car();
            v.Run();
        }

        #region 引入接口
        interface VehicleBase
        {
            void Stop();
            void Run();
        }

        abstract class Vehicle : VehicleBase
        {
            public void Stop()
            {
                Console.WriteLine("Stop");
            }
            public abstract void Run();
        }
        #endregion

        #region 纯抽象类，纯虚类（C++）
        //abstract class VehicleBase
        //{
        //    abstract public void Stop();
        //    abstract public void Run();
        //}

        //abstract class Vehicle : VehicleBase
        //{
        //    public override void Stop()
        //    {
        //        Console.WriteLine("Stop");
        //    }
        //}
        #endregion

        #region 抽象类
        //abstract class Vehicle
        //{
        //    public void Stop()
        //    {
        //        Console.WriteLine("Stop");
        //    }

        //    //抽象方法类似于C++中的纯虚方法。必须被重写，而虚方法可以不被重写
        //    public abstract void Run();
        //}
        #endregion

        #region 虚方法
        //class Vehicle
        //{
        //    public void Stop()
        //    {
        //        Console.WriteLine("Stop");
        //    }

        //    public virtual void Run()
        //    {
        //        Console.WriteLine("Run Vehicle...");
        //    }
        //}
        #endregion



        class Car : Vehicle
        {
            public override void Run()
            {
                Console.WriteLine("Run Car...");
            }

            //public void Run()
            //{
            //    Console.WriteLine("Run Car...");
            //}

            //public void Stop()
            //{
            //    Console.WriteLine("Stop");
            //}
        }

        class Truck : Vehicle
        {
            public override void Run()
            {
                Console.WriteLine("Run Truck...");
            }

            //public void Run()
            //{
            //    Console.WriteLine("Run Truck...");
            //}

            //public void Stop()
            //{
            //    Console.WriteLine("Stop");
            //}
        }

    }
}
