using NordCodes;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

// Демонстрация MyClass
int[] arr = [-1, 1, 4, 5, 2, 3, 9, 8, 11, 0, -10, 100];
Console.WriteLine($"Минимальный элемент: {MyClass.Min(arr)}");

Console.WriteLine($"Перевёрнутая строка: {MyClass.Reverse("Hello, World!")}");

var values = new List<string> { "key1", "bbbb", "key2", "ffff", "aaa", "zzzz" };
var hash = MyClass.GetSign(values, "qweQWEqwe");
Console.WriteLine($"MD5 хеш: {BitConverter.ToString(hash).Replace("-", "").ToLower()}");

app.Run();