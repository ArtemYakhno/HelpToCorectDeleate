using System;
using System.Data.Entity;
using System.Linq;

namespace Temp.EntityModel
{
    public class EntityContext : DbContext
    {      
        public EntityContext()
            : base("name=EntityContext")
        {
        }
        //static EntityContext()
        //{
        //    Database.SetInitializer<EntityContext>(new DropCreateDBOnModelChanged());
        //}
        public DbSet<User> Users { get; set; }
    }

   
}