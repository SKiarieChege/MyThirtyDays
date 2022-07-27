using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MyThirtyDays.Models
{
    public partial class TestDB_AuthStoreContext : DbContext
    {
        public TestDB_AuthStoreContext()
        {
        }

        public TestDB_AuthStoreContext(DbContextOptions<TestDB_AuthStoreContext> options)
            : base(options)
        {
        }

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
