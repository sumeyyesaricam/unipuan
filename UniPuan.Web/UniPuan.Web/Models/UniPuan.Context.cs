﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UniPuan.Web.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class UniPuanEntities1 : DbContext
    {
        public UniPuanEntities1()
            : base("name=UniPuanEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<UP_ST_CITY> UP_ST_CITY { get; set; }
        public virtual DbSet<UP_ST_CITYDEPARTMENT> UP_ST_CITYDEPARTMENT { get; set; }
        public virtual DbSet<UP_ST_DEPARTMENT> UP_ST_DEPARTMENT { get; set; }
        public virtual DbSet<UP_ST_EDUTYPE> UP_ST_EDUTYPE { get; set; }
        public virtual DbSet<UP_ST_SCORETYPE> UP_ST_SCORETYPE { get; set; }
        public virtual DbSet<UP_ST_UNITYPE> UP_ST_UNITYPE { get; set; }
        public virtual DbSet<UP_ST_UNIVERSITY> UP_ST_UNIVERSITY { get; set; }
        public virtual DbSet<UP_ST_PROGRAM> UP_ST_PROGRAM { get; set; }
        public virtual DbSet<UP_ST_SELECT> UP_ST_SELECT { get; set; }
    }
}
