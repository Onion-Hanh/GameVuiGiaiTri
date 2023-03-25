
using Admin_Site.Interfaces;
using Admin_Site.Services;

var builder = WebApplication.CreateBuilder(args);
//Config api
builder.Services.AddHttpClient("", option =>
{
    option.BaseAddress = new Uri(builder.Configuration["API"]);
});
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IQuestion_Service, Question_Service>();
builder.Services.AddScoped<IPlayer_Service, Player_Service>();
builder.Services.AddScoped<IRecord_Service, Record_Service>();
//Add services for session
builder.Services.AddSession();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseSession();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

