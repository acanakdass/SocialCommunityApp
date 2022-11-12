using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Domain.Entities;
using Repository.Contexts.EntityBuilders;

namespace Repository.Contexts
{
    public class BaseDbContext : DbContext
    {
        private IConfiguration Configuration { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }

        public BaseDbContext(DbContextOptions dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
        {
            Configuration = configuration;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ProductModelBuilder.Build(modelBuilder);
            ProductModelBuilder.Seed(modelBuilder);
        }
    }
}