using System;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;

namespace ContactBook.Models
{
    public class ContactBookContext : DbContext
    {

        public ContactBookContext(DbContextOptions<ContactBookContext> options) : base(options)
        {

        }

        public DbSet<Contact> Contacts{ get; set; }
    }
}

