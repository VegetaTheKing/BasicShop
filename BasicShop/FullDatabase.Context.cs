﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BasicShop
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class shopEntities : DbContext
    {
        public shopEntities()
            : base("name=shopEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<account> account { get; set; }
        public virtual DbSet<address> address { get; set; }
        public virtual DbSet<category> category { get; set; }
        public virtual DbSet<city> city { get; set; }
        public virtual DbSet<country> country { get; set; }
        public virtual DbSet<feedback> feedback { get; set; }
        public virtual DbSet<order> order { get; set; }
        public virtual DbSet<order_product> order_product { get; set; }
        public virtual DbSet<person> person { get; set; }
        public virtual DbSet<position> position { get; set; }
        public virtual DbSet<producent> producent { get; set; }
        public virtual DbSet<product> product { get; set; }
        public virtual DbSet<role> role { get; set; }
        public virtual DbSet<staff> staff { get; set; }
        public virtual DbSet<store> store { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<warehouse> warehouse { get; set; }
        public virtual DbSet<product_image> product_image { get; set; }
        public virtual DbSet<WarehouseAllInfoView> WarehouseAllInfoView { get; set; }
    
        [DbFunction("shopEntities", "childCategories")]
        public virtual IQueryable<Nullable<int>> childCategories(Nullable<int> parentId)
        {
            var parentIdParameter = parentId.HasValue ?
                new ObjectParameter("ParentId", parentId) :
                new ObjectParameter("ParentId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<Nullable<int>>("[shopEntities].[childCategories](@ParentId)", parentIdParameter);
        }
    
        [DbFunction("shopEntities", "categorySpecification")]
        public virtual IQueryable<categorySpecification_Result> categorySpecification(Nullable<int> categoryId)
        {
            var categoryIdParameter = categoryId.HasValue ?
                new ObjectParameter("CategoryId", categoryId) :
                new ObjectParameter("CategoryId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<categorySpecification_Result>("[shopEntities].[categorySpecification](@CategoryId)", categoryIdParameter);
        }
    
        [DbFunction("shopEntities", "categorySpecificationWithChildren")]
        public virtual IQueryable<categorySpecificationWithChildren_Result> categorySpecificationWithChildren(Nullable<int> categoryId)
        {
            var categoryIdParameter = categoryId.HasValue ?
                new ObjectParameter("CategoryId", categoryId) :
                new ObjectParameter("CategoryId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<categorySpecificationWithChildren_Result>("[shopEntities].[categorySpecificationWithChildren](@CategoryId)", categoryIdParameter);
        }
    
        [DbFunction("shopEntities", "productSpecification")]
        public virtual IQueryable<productSpecification_Result> productSpecification(Nullable<int> productId)
        {
            var productIdParameter = productId.HasValue ?
                new ObjectParameter("ProductId", productId) :
                new ObjectParameter("ProductId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<productSpecification_Result>("[shopEntities].[productSpecification](@ProductId)", productIdParameter);
        }
    }
}
