using Tweb.Digital.Marketing.Leads.Api.Extensions.MySql;
using Tweb.Digital.Marketing.Leads.Api.Extensions.Swagger;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
                
builder.Services.AddSwagger()
                .AddValidation()
                .GetConnectionStringMySql(builder.Configuration);

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.DocumentTitle = "Documentação da API";
    options.RoutePrefix = "swagger";
    options.ConfigObject.AdditionalItems.Add("antiforgery", false); 
});
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
