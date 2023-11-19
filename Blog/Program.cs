using Blog;
using Blog.API.DbContexts;
using MediatR;
using MediatR.Pipeline;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.EntityFrameworkCore;
using SimpleInjector;
using SimpleInjector.Lifestyles;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

var container = new Container();
container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();
container.Options.DefaultLifestyle = Lifestyle.Scoped;
// Add services to the container.
builder.Services.AddControllers(
    options => options.Filters.Add(typeof(ExceptionFilter)))
.AddNewtonsoftJson();

builder.Services.AddDbContext<BlogContext>(
    dbContextOptions => dbContextOptions.UseSqlite("Data Source=Blog.db"));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
    options => options.CustomSchemaIds(x => x.FullName));

builder.Services.AddSimpleInjector(container, options =>
{
    options.AddAspNetCore()
        .AddControllerActivation();

    var mediatorAssemblies = 
        new[] { typeof(IMediator).Assembly, Assembly.GetExecutingAssembly() };

    container.RegisterInstance(new ServiceFactory(container.GetInstance));
    container.RegisterSingleton<IMediator, Mediator>();
    container.Register(typeof(IRequestHandler<,>), mediatorAssemblies);

    // even though we don't intend to use request pre or post processors of mediator we need to register an empty collection at least
    // as it trys to resolve it anyhow
    container.Collection.Register(typeof(IPipelineBehavior<,>),
        new[]
        {
            typeof(RequestPreProcessorBehavior<,>),
            typeof(RequestPostProcessorBehavior<,>)
        });
    container.Collection.Register(typeof(IRequestPreProcessor<>), mediatorAssemblies);
    container.Collection.Register(typeof(IRequestPostProcessor<,>), mediatorAssemblies);

    container.RegisterInstance(new FileExtensionContentTypeProvider());

    options.AutoCrossWireFrameworkComponents = true;
});

var app = builder.Build();

SimpleInjectorUseOptionsAspNetCoreExtensions.UseSimpleInjector(app, container);
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints => endpoints.MapControllers());

container.Verify();
app.Run();
