using WarehouseManagementSystem;
using WarehouseManagementSystem.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Setup dependency injection

builder.Services.AddTransient<WarehouseContext>();
builder.Services
    .AddTransient<IRepository<Order>, OrderRepository>();
builder.Services
    .AddTransient<IRepository<Item>, ItemRepository>();
builder.Services
    .AddTransient<IRepository<Customer>, CustomerRepository>();
builder.Services
    .AddTransient<IRepository<Warehouse>, WarehouseRepository>();
builder.Services
    .AddTransient<IRepository<ShippingProvider>, ShippingProviderRepository>();
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Order/Error");

    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Order}/{action=Index}/{id?}");

app.Run();
