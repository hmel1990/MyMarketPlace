using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace FormMarket
{
    internal class EFCUsersManager
    {
        public void AddUser(AppDbContext db, EFCUser user)
        {
            db.Users?.Add(user);
            db.SaveChanges();
        }

        public void AddUsers(AppDbContext db, List<EFCUser> users)
        {
            db.Users?.AddRange(users);
            db.SaveChanges();
        }

        public void UpdateUser(AppDbContext db, int id, string newAccess)
        {
            var user = db.Users?.FirstOrDefault(u => u.ID == id);
            if (user != null)
            {
                user.Access = newAccess;
                db.SaveChanges();
            }
        }

        public void UpdateAllUsers(AppDbContext db, string newAccess)
        {
            var users = db.Users?.ToList();
            if (users != null)
            {
                foreach (var user in users)
                {
                    user.Access = newAccess;
                }
                db.SaveChanges();
            }
        }

        public void DeleteUser(AppDbContext db, int id)
        {
            var user = db.Users?.FirstOrDefault(u => u.ID == id);
            if (user != null)
            {
                db.Users?.Remove(user); // удаление одной записи
                db.SaveChanges();
            }
        }

        public void DeleteAllUsers(AppDbContext db)
        {
            var users = db.Users?.ToList();
            if (users != null && users.Any())
            {
                db.Users?.RemoveRange(users); // удаление всех записей
                db.SaveChanges();
            }
        }

        public void ShowUser(AppDbContext db, int id)
        {
            var user = db.Users?.FirstOrDefault(u => u.ID == id);
            if (user != null)
            {
                Console.WriteLine($"ID: {user.ID}, Username: {user.Username}, Password: {user.Password}, Access: {user.Access}");
            }
        }

        public void ShowAllUsers(AppDbContext db)
        {
            var users = db.Users?.ToList();
            if (users != null && users.Any())
            {
                foreach (var user in users)
                {
                    Console.WriteLine($"ID: {user.ID}, Username: {user.Username}, Password: {user.Password}, Access: {user.Access}");
                }
            }
        }

        public int IsUserWithLogingPassword(AppDbContext db, string Username, string Password)
        {
            var user = db.Users?.FirstOrDefault(u => u.Username == Username && u.Password == Password);
            if (user != null)
            {  return user.ID;}
            else return 0;
        }
    }
}
