using Microsoft.EntityFrameworkCore;
using Tarefa.Data;
using Tarefa.Repository;
using Tarefa.Repository.Interface;

namespace Tarefa
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            #region instalando o banco
            var connectionString = builder.Configuration.GetConnectionString("databaseUrl");
            builder.Services.AddDbContext<DataContext>(options
                => options.UseSqlServer(connectionString).EnableSensitiveDataLogging(true)
                );
            #endregion

            #region injecao dependencia 
            builder.Services.AddScoped<ITarefaRepository, TarefaRepository>();
            #endregion

            #region modelState
            builder.Services.AddControllers().ConfigureApiBehaviorOptions(opt =>
            {
                opt.SuppressModelStateInvalidFilter = true;
                opt.SuppressMapClientErrors = true;
            });
            #endregion

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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
}
