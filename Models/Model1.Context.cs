﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Store.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class PetStoreEntities4 : DbContext
    {
        public PetStoreEntities4()
            : base("name=PetStoreEntities4")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<tb_admin> tb_admin { get; set; }
        public virtual DbSet<tb_buy> tb_buy { get; set; }
        public virtual DbSet<tb_cart> tb_cart { get; set; }
        public virtual DbSet<tb_pet> tb_pet { get; set; }
        public virtual DbSet<tb_user> tb_user { get; set; }
    }
}
