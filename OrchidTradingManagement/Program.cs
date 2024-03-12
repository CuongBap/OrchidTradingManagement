using OrchidTradingRepositories.Models.ViewModels;
using OrchidTradingRepositories.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

//CRUD Repository
builder.Services.AddScoped<IListInformationRepository, ListInformationRepository>();
builder.Services.AddScoped<IOrchidRepository, OrchidRepository>();
builder.Services.AddScoped<IAuctionRepository, AuctionRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IOrderDetailRepository, OrderDetailRepository>();


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

app.Run();
