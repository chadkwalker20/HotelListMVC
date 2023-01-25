using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using HotelListMVC.Data;
using System;
using System.Linq;


namespace HotelListMVC.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new HotelListMVCContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<HotelListMVCContext>>()))
            {
                // look for any guests.
                if(context.Guest.Any())
                {
                    return; //DB has been seeded
                }

                context.Guest.AddRange(
                    new Guest
                    {
                        FirstName = "John",
                        LastName = "Smith",
                        PhoneNum = "323-434-3433",
                        CheckInDate = DateTime.Parse("2023-1-25"),
                        CheckOutDate = DateTime.Parse("2023-1-29"),
                        CreditCardId = 938949949
                        
                    },

                    new Guest
                    {
                        FirstName = "Jim",
                        LastName = "Johnson",
                        PhoneNum = "655-654-7933",
                        CheckInDate = DateTime.Parse("2020-1-20"),
                        CheckOutDate = DateTime.Parse("2020-1-22"),
                        CreditCardId = 976946949
                    },

                    new Guest
                    {
                        FirstName = "Peter",
                        LastName = "Parker",
                        PhoneNum = "987-397-9999",
                        CheckInDate = DateTime.Parse("2022-4-15"),
                        CheckOutDate = DateTime.Parse("2022-4-19"),
                        CreditCardId = 935494549
                    },

                    new Guest
                    {
                        FirstName = "Harry",
                        LastName = "Potter",
                        PhoneNum = "109-568-1648",
                        CheckInDate = DateTime.Parse("2020-6-1"),
                        CheckOutDate = DateTime.Parse("2020-6-10"),
                        CreditCardId = 938698949
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
