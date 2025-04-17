using BigProject.DataContext;
using BigProject.Middlewares;
using BigProject.Payload.Response;
using BigProject.PayLoad.Converter;
using BigProject.PayLoad.DTO;
using BigProject.Service.Implement;
using BigProject.Service.Interface;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using Npgsql;

var builder = WebApplication.CreateBuilder(args);

// Get connection string from environment variable in production, otherwise from appsettings.json
var connectionString = Environment.GetEnvironmentVariable("POSTGRES_URL") ?? 
                      builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(opt => opt.UseNpgsql(connectionString));

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy => policy.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
});

builder.Services.AddSwaggerGen(x =>
{
    x.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Swagger eShop Solution", Version = "v1" });
    x.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Description = "Làm theo mẫu này. Example: Bearer {Token} ",
        Name = "Authorization",
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });
    x.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
                Scheme = "oauth2",
                Name = "Bearer",
                In = ParameterLocation.Header,
            },
            new List<string>()
        }
    });
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options => {
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        ValidateAudience = false,
        ValidateIssuer = false,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
            builder.Configuration.GetSection("AppSettings:SecretKey").Value!))
    };
});

builder.Services.AddScoped<AppDbContext>();

builder.Services.AddScoped<ResponseBase>();

builder.Services.AddScoped<Converter_Register>();
builder.Services.AddScoped<Converter_Login>();
builder.Services.AddScoped<Converter_Event>();
builder.Services.AddScoped<Converter_RewardDiscipline>();
builder.Services.AddScoped<Converter_RewardDisciplineApproval>();
builder.Services.AddScoped<Converter_MemberInfo>();
builder.Services.AddScoped<Converter_EventJoin>();
builder.Services.AddScoped<Converter_OutstandingMember>();
builder.Services.AddScoped<Converter_OutstandingMemberApproval>();
builder.Services.AddScoped<Converter_ApprovalHistory>();
builder.Services.AddScoped<Converter_Document>();

builder.Services.AddScoped<IService_Authentic, Service_Authentic>();
builder.Services.AddScoped<IService_Event, Service_Event>();
builder.Services.AddScoped<IService_RewardDiscipline, Service_RewardDiscipline>();
builder.Services.AddScoped<IService_MemberInfo, Service_MemberInfo>();
builder.Services.AddScoped<IService_OutstandingMember, Service_OutstandingMember>();
builder.Services.AddScoped<IService_ApprovalHistory, Service_ApprovalHistory>();
builder.Services.AddScoped<IService_Document, Service_Document>();

builder.Services.AddScoped<ResponseObject<DTO_Register>>();     
builder.Services.AddScoped<ResponseObject<DTO_Login>>();
builder.Services.AddScoped<ResponseObject<DTO_Token>>();
builder.Services.AddScoped<ResponseObject<List<DTO_Register>>>();
builder.Services.AddScoped<ResponseObject<DTO_Event>>();
builder.Services.AddScoped<ResponseObject<DTO_RewardDiscipline>>();
builder.Services.AddScoped<ResponseObject<DTO_RewardDisciplineApproval>>();
builder.Services.AddScoped<ResponseObject<DTO_MemberInfo>>();
builder.Services.AddScoped<ResponseObject<DTO_EventJoin>>();
builder.Services.AddScoped<ResponseObject<DTO_OutstandingMember>>();
builder.Services.AddScoped<ResponseObject<DTO_OutstandingMemberApproval>>();
builder.Services.AddScoped<ResponseObject<DTO_ApprovalHistory>>();
builder.Services.AddScoped<ResponseObject<DTO_Document>>();

builder.Services.AddControllers();

builder.Logging.AddConsole();
builder.Logging.AddDebug();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    c.RoutePrefix = string.Empty;
});

app.UseMiddleware<TokenValidationMiddleware>();
app.UseCors("AllowAll");
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

