using System.IO.Compression;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using riwivet.Data;
using riwivet.Models;
using riwivet.Services.Mailsend;
using riwivet.Services.Owners;
using riwivet.Services.Pets;
using riwivet.Services.Quotes;
using riwivet.Services.Vets;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();// IMPORTANTE

/*================= CONFIGURACION DE LA BASE DE DATOS ======================*/
builder.Services.AddDbContext<BaseContext>
(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("mySqlConnection"),
        Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.2-mysql")
    )
);
/*================= CONFIGURACION DE LOS SCOPED ======================*/
builder.Services.AddScoped<IOwnersRepository,OwnersRepository>();
builder.Services.AddScoped<IVetRepository,VetRepository>();
builder.Services.AddScoped<IPetsRepository,PetsRepository>();
builder.Services.AddScoped<IQuoteRepository,QuoteRepository>();

/*================= CONFIGURACION DE LOS SCOPED Y EL HTTPCLIENT DEL MAILSEND ======================*/
builder.Services.AddScoped<IEmailSendRepository,EmailSendRepository>();
builder.Services.AddHttpClient<IEmailSendRepository,EmailSendRepository>();
builder.Services.Configure<MailSendOptions>(builder.Configuration.GetSection("MailSendOptions"));

/*================= CONFIGURACION DEL JWT ======================*/
builder.Services.AddAuthentication(opt => {
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(configurre => {
        configure.TokenValidationParameters = new TokenValidationParameters
        {
            
        };
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseAuthentication();
app.UseAuthorization();
app.UseHttpsRedirection();
app.MapControllers();



app.Run();

