using demo_pizzeria.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.InjectDependancies();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// c'est ici que l'on va utiliser le middleware des cors (cross-origin requests)
// on le laisse vide lorsque l'on utilise des policy sur nos contrôlleurs/actions
// on peut aussi préciser une policy qui s'appliquera sur toute l'application
// cette version permet de tout accepter sans utiliser de policy :
app.UseCors(options =>
{
    options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
});

app.UseAuthentication(); // NE PAS OUBLIER
app.UseAuthorization();

app.MapControllers();

app.Run();
