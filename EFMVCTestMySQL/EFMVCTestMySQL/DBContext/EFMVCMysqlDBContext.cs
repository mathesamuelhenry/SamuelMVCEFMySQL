using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using MySql.Data.Entity;
using EFMVCTestMySQL.Models;

namespace EFMVCTestMySQL.DBContext
{
    // Code-Based Configuration and Dependency resolution
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class EFMVCMySqlDBContext : DbContext
    {
        //Add your Dbsets here
        public DbSet<Customer> Customers { get; set; }

        public DbSet<MembershipType> MembershipTypes { get; set; }
        
        public EFMVCMySqlDBContext()
              
           //Reference the name of your connection string
            : base("TestSamuelMVCEFDB")
              {
        }
    }
}