var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// This line adds support for controllers and views (MVC architecture).
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
// Redirect all HTTP requests to HTTPS to enforce secure communication
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
// Defines the default route for the app: requests will go to the HomeController and the Index action by default.
// The optional 'id' parameter can be used for specific resource identification.
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Starts the web application.
app.Run();
