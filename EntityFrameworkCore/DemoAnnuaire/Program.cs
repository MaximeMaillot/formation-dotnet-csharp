using DemoAnnuaire.Classes;

using DemoAnnuaire.Data;
using DemoAnnuaire.Models;

using var context = new ApplicationDbContext();

IHM program = new IHM(context);
program.Start();
