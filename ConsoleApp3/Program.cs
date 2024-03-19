using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //var driver = new Driver(new LightTank());
            //driver.Drive();


            //var lightTank = new LightTank();
            //var driver2 = new Driver(lightTank);
            //driver2.Drive();
            //driver2.Drive(lightTank);

            #region 反射
            ITank2 tank2 = new HeavyTank();

            var t = tank2.GetType();
            object o = Activator.CreateInstance(t);
            MethodInfo fireM = t.GetMethod("Fire");
            MethodInfo runM = t.GetMethod("Run");
            fireM.Invoke(o, null);
            runM.Invoke(o, null);
            #endregion

            #region 依赖注入
            //var sc = new ServiceCollection();
            //sc.AddScoped(typeof(ITank2), typeof(LightTank));
            //sc.AddScoped(typeof(IVehicle), typeof(LightTank));
            //sc.AddScoped<Driver>();
            //var sp = sc.BuildServiceProvider();

            //ITank2 tank3 = sp.GetService<ITank2>();
            //tank3.Fire();

            //自动装配
            //var driver3 = sp.GetService<Driver>();
            //driver3.Drive();
            #endregion

        }

        class Driver
        {
            private IVehicle _vehicle;
            //private ITank2 _tank2;
            public Driver(IVehicle vehicle)
            {
                _vehicle = vehicle;
            }
            //public Driver(ITank2 tank2)
            //{
            //    _tank2 = tank2;
            //}
            public void Drive()
            {
                _vehicle.Run();
            }

        }


        //class Driver
        //{
        //    private IVehicle _vehicle;
        //    //private ITank2 _tank2;
        //    public Driver(IVehicle vehicle)
        //    {
        //        _vehicle = vehicle;
        //    }
        //    //public Driver(ITank2 tank2)
        //    //{
        //    //    _tank2 = tank2;
        //    //}
        //    public void Drive()
        //    {
        //        _vehicle.Run();
        //    }
        //    public void Drive(LightTank lightTank)
        //    {
        //        IWeapon weapon = lightTank;
        //        weapon.Fire();
        //        //or this
        //        //var weapon2= lightTank as IWeapon;
        //        //weapon2.Fire();
        //    }
        //}
        public interface IVehicle
        {
            void Run();
        }
        class Car : IVehicle
        {
            public void Run() { Console.WriteLine("Run Car"); }
        }
        class Truck : IVehicle
        {
            public void Run() { Console.WriteLine("Run Truck"); }
        }

        #region 胖接口：武器属性和机动车属性，把它分裂成两个接口
        //interface ITank
        //{
        //    void Fire();
        //    void Run();
        //}

        //class LightTank : ITank
        //{
        //    public void Run() { Console.WriteLine("Run LightTank"); }


        //    public void Fire() { Console.WriteLine("Fire LightTank"); }
        //}

        //class HeavyTank : ITank
        //{
        //    public void Run() { Console.WriteLine("Run HeavyTank"); }

        //    public void Fire() { Console.WriteLine("Fire HeavyTank"); }
        //}
        #endregion

        interface IWeapon
        {
            void Fire();
        }

        interface ITank2 : IVehicle, IWeapon
        {
        }

        class LightTank : ITank2
        {
            public void Run() { Console.WriteLine("Run LightTank"); }


            void IWeapon.Fire() { Console.WriteLine("Fire LightTank"); }
            //public void Fire() { Console.WriteLine("Fire LightTank"); }
        }

        class HeavyTank : ITank2
        {
            public void Run() { Console.WriteLine("Run HeavyTank"); }
            public void Fire() { Console.WriteLine("Fire HeavyTank"); }
        }
    }
}
