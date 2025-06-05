using YMYP67_FirstAPI.Business.Abstract;
using YMYP67_FirstAPI.Business.Concrete;
using YMYP67_FirstAPI.DataAccess.Abstract;
using YMYP67_FirstAPI.DataAccess.Concrete.EntityFramework;

namespace YMYP67_FirsAPI.WebApi;

public class Program
{
    public static void Main(string[] args)
    {
        // Dependency Injection Lifecycle (Yaþam Döngüsü)

        // AddScoped() : Her istek için yeni bir örnek oluþturulur. (Web uygulamalarýnda genellikle kullanýlýr). Response döndükten sonra nesnenin ömrü tamamlanýr.

        // AddSingleton() : Uygulama baþlatýldýðýnda tek bir örnek oluþturulur ve bu örnek tüm isteklerde kullanýlýr. Uygulama kapatýlana kadar bu örnek yaþamaya devam eder.

        // AddTransient() : Her istek için yeni bir örnek oluþturulur. Ancak, bu örnekler istek tamamlandýðýnda hemen yok edilir. Genellikle kýsa ömürlü nesneler için kullanýlýr.


        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        builder.Services.AddDbContext<FirstApiContext>();
        builder.Services.AddScoped<ICategoryDal, EfCategoryDal>();
        builder.Services.AddScoped<ICategoryService, CategoryManager>();
        builder.Services.AddScoped<IProductDal, EfProductDal>();
        builder.Services.AddScoped<IProductService, ProductManager>();
        builder.Services.AddScoped<ICustomerDal, EfCustomerDal>();
        builder.Services.AddScoped<ICustomerService, CustomerManager>();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

         var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}