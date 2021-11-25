using Business.Concrete;
using Core.Entities.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {


            //Rental rental = new Rental() { CarId = 1, CustomerId = 2, RentDate = new DateTime(2021, 10, 7), ReturnDate = null };
            //RentalManager rentalManager = new RentalManager(new EfRentalDal());
            //var result = rentalManager.Add(rental);
            ////var result = rentalManager.Update(rental);
            //Console.WriteLine(result.Message);

            

            //AddCustomer();
            //AddUser();
            //CarResultTest();
            //CarTest();
            //CarTest2();

        }

        private static void AddCustomer()
        {
            Customer customer = new Customer() { UserId = 2, CompanyName = "engin.io" };
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            var result = customerManager.Add(customer);
            Console.WriteLine(result.Message);
        }

        //private static void AddUser()
        //{
        //    User user = new User() { FirstName = "Engin", LastName = "Toprak", Email = "engintoprak@gmail.com", Password = "123456" };
        //    UserManager userManager = new UserManager(new EfUserDal());
        //    var result = userManager.Add(user);
        //    Console.WriteLine(result.Message);
        //}

        //private static void CarResultTest()
        //{
        //    CarManager carManager = new CarManager(new EfCarDal());
        //    var result = carManager.GetAll();

        //    if (result.Success)
        //    {
        //        Console.WriteLine(result.Message);
        //        foreach (var c in result.Data)
        //        {
        //            Console.WriteLine(c.Description);
        //        }
        //    }
        //    else
        //    {
        //        Console.WriteLine(result.Message);
        //    }
        //}

        //private static void CarTest2()
        //{
        //    CarManager carManager = new CarManager(new EfCarDal());
        //    foreach (var c in carManager.GetCarDetails())
        //    {
        //        Console.WriteLine(c.CarName + " " + c.BrandName + " " + c.ColorName + " " + c.DailyPrice);
        //    }
        //    //carManager.Add(new Car { BrandId=3,ColorId=2,DailyPrice=250,Description="Zengin",ModelYear=1999});
        //}

        //private static void CarTest()
        //{
        //    CarManager carManager = new CarManager(new EfCarDal());
        //    foreach (var c in carManager.GetCarsByColorId(1))
        //    {
        //        Console.WriteLine(c.Description);
        //    }
        //    Console.WriteLine("-------");

        //    //carManager.Add(new Car { BrandId = 5,ColorId = 1,DailyPrice = 500,Description="Konforlu",ModelYear=2015});
        //}
    }
}
