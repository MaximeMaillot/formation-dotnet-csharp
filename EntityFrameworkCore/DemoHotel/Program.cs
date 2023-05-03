using DemoHotel.Classes;
using DemoHotel.Data;

using var context = new HotelDbContext();

IHM program = new IHM(context);
program.Start();
