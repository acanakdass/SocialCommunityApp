using System.Reflection;
using Business.Abstract;
using Business.Concrete;
using Business.Rules;
using Business.Security.JWT;
using Business.Validators.ProductValidators;
using Core.CrossCuttingConcerns.Caching.Redis;
using Core.Utilities.Ioc;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repository.Abstract;
using Repository.Concrete;
using Repository.Contexts;

namespace Business.Modules
{
    public class DIModule : ICoreModule
    {
        private IConfiguration _configuration;

        public DIModule(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void Load(IServiceCollection serviceCollection)
        {
            serviceCollection.AddDbContext<BaseDbContext>(options => options.UseNpgsql(
                _configuration.GetConnectionString("PostgreSQL"), x => x.MigrationsAssembly("WebAPI")));

            serviceCollection.AddAutoMapper(Assembly.GetExecutingAssembly());

            serviceCollection.AddScoped<IProductService, ProductManager>();
            serviceCollection.AddScoped<IProductRepository, ProductRepository>();

            //serviceCollection.AddScoped<ICacheService, RedisCacheManager>();

            serviceCollection.AddScoped<ITokenHelper, JwtHelper>();

            serviceCollection.AddScoped<IUserRepository,UserRepository>();
            serviceCollection.AddScoped<IUserService, UserManager>();
            
            serviceCollection.AddScoped<IPostRepository, PostRepository>();
            serviceCollection.AddScoped<IPostService, PostManager>();

            serviceCollection.AddScoped<ICommentRepository, CommentRepository>();
            serviceCollection.AddScoped<ICommentService, CommentManager>();

            serviceCollection.AddScoped<IOperationClaimService, OperationClaimManager>();
            serviceCollection.AddScoped<IOperationClaimRepository, OperationClaimRepository>();

            serviceCollection.AddScoped<IUserOperationClaimRepository, UserOperationClaimRepository>();

            serviceCollection.AddScoped<IAuthService, AuthManager>();

            serviceCollection.AddScoped<ProductBusinessRules>();
            serviceCollection.AddScoped<UserBusinessRules>();

            serviceCollection.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            serviceCollection.AddValidatorsFromAssemblyContaining<ProductCreateValidator>();
            serviceCollection.Configure<RedisSettings>(_configuration.GetSection("RedisSettings"));

            //serviceCollection.AddSingleton<RedisServer>(sp =>
            //{
            //    var redisSettings = sp.GetRequiredService<IOptions<RedisSettings>>().Value;
            //    var redis = new RedisServer(redisSettings.Host, redisSettings.Port);
            //    redis.Connect();
            //    return redis;
            //});
            // serviceCollection.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
