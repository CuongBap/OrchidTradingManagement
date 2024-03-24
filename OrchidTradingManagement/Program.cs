using OrchidTradingRepositories.Models.ViewModels;
using OrchidTradingRepositories.Services;
using OrchidTradingRepositories.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddControllers();

//CRUD Repository
builder.Services.AddScoped<IListInformationService, ListInformationService>();
builder.Services.AddScoped<IOrchidService, OrchidService>();
builder.Services.AddScoped<IAuctionService, AuctionService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IOrderDetailService, OrderDetailService>();
builder.Services.AddScoped<IImageRepository, ImageRepositoryCloudinary>();


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
