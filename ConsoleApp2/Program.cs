using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //var car = new Car(new V8Engine());
            //car.Run(3);

            Engine engine = new Engine();
            var car = new Car(engine);
            car.Run(3);
        }

        #region 引入接口来解耦
        //interface IEngine
        //{
        //    int RPM { get; }
        //    void Work(int gas);
        //}

        //class V6Engine : IEngine
        //{
        //    public int RPM { get; private set; }
        //    public void Work(int gas)
        //    {
        //        RPM = 1000 * gas;
        //    }
        //}

        //class V8Engine : IEngine
        //{
        //    public int RPM { get; private set; }
        //    public void Work(int gas)
        //    {
        //        RPM = 1500 * gas;
        //    }
        //}
        //class Car
        //{
        //    //使用接口来解耦
        //    private IEngine _engine;
        //    public Car(IEngine engine)
        //    {
        //        _engine = engine;
        //    }

        //    public int Speed { get; private set; }
        //    public void Run(int gas)
        //    {
        //        _engine.Work(gas);
        //        Speed = _engine.RPM / 100;
        //        Console.WriteLine(Speed);
        //    }
        //}
        #endregion


        #region 依赖越直接，耦合越紧
        class Engine
        {
            public int RPM { get; private set; }
            public void Work(int gas)
            {
                RPM = 1000 * gas;
            }
        }
        class Car
        {
            //Car依赖在Engine上，产生紧耦合
            private Engine _engine;
            public Car(Engine engine)
            {
                _engine = engine;
            }

            public int Speed { get; private set; }
            public void Run(int gas)
            {
                _engine.Work(gas);
                Speed = _engine.RPM / 100;
                Console.WriteLine(Speed);
            }
        }
        #endregion
    }
}
