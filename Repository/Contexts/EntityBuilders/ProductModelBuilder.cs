using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Repository.Contexts.EntityBuilders
{


    public static class ProductModelBuilder
    {
        public static void Build(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(a =>
            {
                a.ToTable("Products").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.Name).HasColumnName("Name");
                a.Property(p => p.Desc).HasColumnName("Desc");
            });
        }

        public static void Seed(ModelBuilder modelBuilder)
        {
            Product[] productEntitySeeds =
            {
            new() {Id = 1, Name = "Pen",Desc="Pen Description"},
            new() {Id = 2, Name = "Pencil",Desc="Pen Description"}
        };
            modelBuilder.Entity<Product>().HasData(productEntitySeeds);
        }


    }
    //public static class UserModelBuilder
    //{
    //    public static void Build(ModelBuilder modelBuilder)
    //    {
    //        //modelBuilder.Entity<UserOperationClaim>(a =>
    //        //{
    //        //    a.ToTable("UserOperationClaims").HasKey(k => k.Id);
    //        //    a.Property(p => p.Id).HasColumnName("Id");
    //        //    a.Property(p => p.OperationClaimId).HasColumnName("OperationClaimId");
    //        //    a.Property(p => p.UserId).HasColumnName("UserId");
    //        //    a.Property(p => p.CreatedDate).HasColumnName("CreatedDate");
    //        //});
    //        modelBuilder.Entity<UserOperationClaim>().HasKey(uo => new { uo.UserId, uo.OperationClaimId });
    //        modelBuilder.Entity<UserOperationClaim>().HasOne(uo => new { uo.UserId, uo.OperationClaimId });

    //    }

    //    public static void Seed(ModelBuilder modelBuilder)
    //    {
    //        Product[] productEntitySeeds =
    //        {
    //        new() {Id = 1, Name = "Pen",Desc="Pen Description"},
    //        new() {Id = 2, Name = "Pencil",Desc="Pen Description"}
    //    };
    //        modelBuilder.Entity<Product>().HasData(productEntitySeeds);
    //    }


    //}
}