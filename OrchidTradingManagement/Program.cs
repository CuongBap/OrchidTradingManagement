using OrchidTradingRepositories.Models.ViewModels;
using OrchidTradingRepositories.Repositories;
using OrchidTradingServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddControllers();

//CRUD Repository
builder.Services.AddScoped<OrchidTradingServices.IListInformationService, ListInformationService>();
builder.Services.AddScoped<OrchidTradingServices.IOrchidService, OrchidService>();
builder.Services.AddScoped<OrchidTradingServices.IAuctionService, AuctionService>();
builder.Services.AddScoped<OrchidTradingServices.IUserService, UserService>();
builder.Services.AddScoped<OrchidTradingServices.IRoleService, RoleService>();
builder.Services.AddScoped<OrchidTradingServices.IOrderService, OrderService>();
builder.Services.AddScoped<OrchidTradingServices.IOrderDetailService, OrderDetailService>();
builder.Services.AddScoped<OrchidTradingServices.IImageService, ImageServiceCloudinary>();


// Use session
builder.Services.AddSession();
builder.Services.AddMvc();
builder.Services.AddHttpContextAccessor();
builder.Services.Configure<StripeSetting>(builder.Configuration.GetSection("StripeSettings"));



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//Session
app.UseSession();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();
app.MapControllers();

app.Run();
