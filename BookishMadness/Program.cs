using AutoMapper;
using BookishMadness.BLL;
using BookishMadness.BLL.Interfaces;
using BookishMadness.BLL.Services;
using BookishMadness.DAL.EF;
using BookishMadness.DAL.Entities;
using BookishMadness.DAL.Interfaces;
using BookishMadness.DAL.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var mapConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MapperProfile());
});
IMapper mapper = mapConfig.CreateMapper();
string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Add services to the container.

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddSingleton(mapper);
builder.Services.AddScoped<IRepository<Book>, BookRepository>();
builder.Services.AddScoped<IRepository<Author>, AuthorRepository>();
builder.Services.AddScoped<IGenreRepository, GenreRepository>();
builder.Services.AddScoped<IReactionRepository, ReactionRepository>();
builder.Services.AddTransient<IBooksService, BookService>();
builder.Services.AddTransient<IAuthorService, AuthorService>();
builder.Services.AddTransient<IReactionService, ReactionService>();



builder.Services.AddControllersWithViews()
    .AddNewtonsoftJson(options =>
      options.SerializerSettings.ReferenceLoopHandling =
        Newtonsoft.Json.ReferenceLoopHandling.Ignore);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
   
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.MapControllers();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
