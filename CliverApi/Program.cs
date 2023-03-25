using CliverApi.Extensions;
using CliverApi.Hubs;
using CliverApi.Middlewares;
using CliverApi.Models;
using CliverApi.Models.Settings;
using Hangfire;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);


builder.Services.ConfigureCors();

// Add services to the container.
builder.Services.AddControllers().AddJsonOptions(x =>
{
    x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});
builder.Services.AddSignalR(options =>
{
    options.EnableDetailedErrors = true;
    options.HandshakeTimeout = TimeSpan.FromSeconds(30);
}).AddJsonProtocol(x => {
    x.PayloadSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    x.PayloadSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.ConfigureSwaggerOptions();
});
builder.Services.Configure<MailSettings>(builder.Configuration.GetSection("MailSettings"));
builder.Services.Configure<PaypalSettings>(builder.Configuration.GetSection("PaypalSettings"));
builder.Services.AddHangFireService(builder.Configuration);

builder.Services.ConfigureAuthentication(builder.Configuration);

builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DbContext"));
}
);
builder.Services.ConfigureRepository();
builder.Services.AddAutoMapper(typeof(Program));
var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();
//app.UseHangfireDashboard();

//BackgroundJob.Enqueue(() => Console.WriteLine("Hello, world!"));

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.ConfigureExceptionHandler(app.Logger);
app.UseForwardedHeaders();
app.UseHttpsRedirection();
app.UseRouting();

app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.UseAuthentication();
app.UseAuthorization();

//var vnTimezone = TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time");
//RecurringJob.AddOrUpdate("easyjob", () => Console.WriteLine($"Test Schedule {DateTime.Now}"), "*/1 * * * *");
////RecurringJob.AddOrUpdate<EmailJob>(emailJob => emailJob.SendEmail(), "55 23 * * *", vnTimezone);


app.UseMiddleware<JwtMiddleware>();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapHub<ChatHub>("/hubs/chat");
    //endpoints.MapHangfireDashboard();
});

app.Run();
