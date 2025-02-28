var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddCors(options => {
//    options.AddPolicy("AllowAll", builder => {
//        builder.AllowAnyOrigin()
//               .AllowAnyMethod()
//               .AllowAnyHeader();
//    });
//});

builder.WebHost.UseUrls("http://*:80");

//builder.Services.AddCors(options => {
//    options.AddPolicy("AllowAll",
//        policy => policy
//            .WithOrigins("http://localhost:4200") // Angular dev server
//            .AllowAnyHeader()
//            .AllowAnyMethod()
//            .AllowCredentials());
//});

// Replace existing CORS configuration with:
builder.Services.AddCors(options => {
    options.AddPolicy("AllowAll",
        policy => policy
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod());
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


app.UseCors("AllowAll");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// added the satic files middleware
app.MapGet("/health", () => "OK");
app.UseDefaultFiles();
app.UseStaticFiles();

//app.UseHttpsRedirection();

app.UseAuthorization();

//app.UseCors("AllowAngularDevClient");


app.MapControllers();

app.MapFallbackToFile("index.html");

app.Run();
