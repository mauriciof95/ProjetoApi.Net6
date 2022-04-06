using Api.Configuration;
using Api.Data.Context;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;

IConfiguration configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

var builder = WebApplication.CreateBuilder(args);

var tokenConfiguration = new TokenConfiguration();

new ConfigureFromConfigurationOptions<TokenConfiguration>(
    configuration.GetSection("TokenConfigurations")
).Configure(tokenConfiguration);

builder.Services.AddSingleton(tokenConfiguration);

builder.Services.AddAuthentication(o => {
    o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(o => {
    o.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = tokenConfiguration.Issuer,
        ValidAudience = tokenConfiguration.Audience,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenConfiguration.Secret))
    };
});

builder.Services.AddAuthorization(a => { 
    a.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
        .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
        .RequireAuthenticatedUser()
        .Build());
});

builder.Services.AddCors(b => 
    b.AddDefaultPolicy(o => o
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowAnyOrigin()
    )
);

builder.Services.AddControllers();

/*builder.Services.Configure<JsonSerializerSettings>(o => {
    o.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
});*/

var conn = configuration.GetConnectionString("ConnectionString");

//pega a string de conexao do secrets.json
//arquivo fora do projeto para gerenciar dados sensiveis
//>dotnet user-secrets set ConnectionString "string da conexao" --project Api
var connSecret = builder.Configuration["ConnectionString"];

if (connSecret != null) conn = connSecret;

builder.Services.AddDbContext<ApiContext>(o => { 
    o.UseNpgsql(conn);
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

try
{
    using (var serviceScope = app.Services.GetService<IServiceScopeFactory>().CreateScope())
    {
        var context = serviceScope.ServiceProvider.GetRequiredService<ApiContext>();
        context.Database.Migrate();
    }
}
catch { }

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run("http://localhost:8900");
