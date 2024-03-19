using WebApplication3.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ¬икористано AddSingleton, оск≥льки нам потр≥бен лише один екземпл€р серв≥су прот€гом життЇвого циклу додатка.
builder.Services.AddSingleton<ITweetService, TweetService>();
builder.Services.AddSingleton<IUserService, UserService>();
builder.Services.AddSingleton<IHashtagService, HashtagService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
