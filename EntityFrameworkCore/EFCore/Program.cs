using EFCore.Data;
using EFCore.Models;

using var context = new ApplicationDbContext();


Student student = new Student()
{
    Firstname = "Magalie",
    Lastname = "Maillot",
    Phone = "0607080910",
    Email = "max@test.com"
};

context.Students.Add(student);
context.SaveChanges();


Student secondStudent = context.Students.Find(1);
Console.WriteLine(secondStudent);

/*
secondStudent.Email = "newmail@gmail;com";
context.Students.Update(secondStudent);
context.SaveChanges();
*/

Student studentByName = context.Students.FirstOrDefault(s => s.Firstname == "Maxime");
Console.WriteLine(studentByName);

List<Student> studentsByName = context.Students.Where(s => s.Firstname == "Maxime").ToList();
foreach (Student s in studentsByName)
{
    Console.WriteLine(s);
}

List<Student> students = context.Students.ToList();
foreach (Student s in students)
{
    Console.WriteLine(s);
}