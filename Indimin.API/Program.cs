using System.Reflection;
using Indimin.API;
using Indimin.Application;
using Indimin.Persistence;

var builder = WebApplication.CreateBuilder(args);
{
    // Add services to the container.
    builder.Services
        .AddApplicationLayer()
        .AddInfrastructureLayer(builder.Configuration);

    builder.Services.AddControllers();
    
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();

    builder.Services.AddSwaggerGen(config  => 
    { 
        config.SwaggerDoc("v1", new()
        {
            Title = "EastView API", 
            Version = "v1",
            Description = "CRUD challenge Software Engineer position at Indimin",
            Contact = new()
            {
                Name = "Nelson Rivas",
                Email = "contact@nelsonrivas.me",
                Url = new Uri("https://nelsonrivas.me")
            }
        });
    
        // using System.Reflection;
        var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        config.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));

    });
    
    builder.Services.AddCors(options =>
    {
        var frontendUrl = builder.Configuration.GetValue<string>("FrontendUrl");
        
        options.AddDefaultPolicy(builder =>
        {
            builder.WithOrigins(frontendUrl)
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
        
        // options.AddPolicy("AllowAll", builder =>
        // {
        //     builder.WithOrigins(frontendUrl)
        //         .AllowAnyHeader()
        //         .AllowAnyMethod();
        // });

    });

}

var app = builder.Build();
{
    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();
    
    app.UseCors();

    app.UseErrorHandlerMiddleware();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
