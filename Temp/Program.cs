using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Temp.EntityModel;
namespace Temp
{
    class Program
    {
        static void Main(string[] args)
        {
            using (EntityContext db = new EntityContext())
            {
                db.Database.ExecuteSqlCommand("TRUNCATE TABLE [Users]");
                db.SaveChanges();
                // создаем два объекта User
                User user1 = new User { Name = "Tom", Age = 33 };
                User user2 = new User { Name = "Sam", Age = 26 };

                //добавляем их в бд
                db.Users.Add(user1);               
                db.Users.Add(user2);               
                db.SaveChanges();
                Console.WriteLine("Объекты успешно сохранены");

                //получаем объекты из бд и выводим на консоль
                var user = db.Users.FirstOrDefault(s => s.Id.Equals(1));
                db.Users.Remove(user);
                db.SaveChanges();
                var userc = db.Users.Include( s => s).FirstOrDefault(s => s.Id.Equals(1));
                Console.WriteLine("Список объектов:");
                Console.WriteLine("{1} - {2}", userc.Name, userc.Age);
                //foreach (User u in users)
                //{
                //    Console.WriteLine("{0}.{1} - {2}", u.Id, u.Name, u.Age);
                //}
                //db.Database.ExecuteSqlCommand("TRUNCATE TABLE [Users]");
                //db.SaveChanges();

            }
            Console.Read();
        }
    }
}
