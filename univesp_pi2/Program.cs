var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();


builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.UseSession();

app.UseAuthorization();

app.MapControllerRoute(
    name: "login",
    pattern: "Login/{action=Index}/{id?}",
    defaults: new { controller = "Login", action = "Index" });

app.MapControllerRoute(
    name: "catalogo",
    pattern: "Catalogo/{action=Index}/{id?}",
    defaults: new { controller = "Catalogo", action = "Index" });

app.MapControllerRoute(
    name: "Admin",
    pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();