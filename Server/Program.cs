using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.Json;

using Data;
using Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Shared;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// Sætter CORS så API'en kan bruges fra andre domæner
var AllowSomeStuff = "_AllowSomeStuff";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: AllowSomeStuff, builder => {
        builder.AllowAnyOrigin()
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});

// Tilføj DbContext factory som service.
builder.Services.AddDbContext<TrådeContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("ContextSQLite")));

// Tilføj DataService så den kan bruges i endpoints
builder.Services.AddScoped<DataService>();

var app = builder.Build();


app.UseHttpsRedirection();
app.UseCors(AllowSomeStuff);

Console.WriteLine(JsonSerializer.Serialize(new Tråde(new Bruger("Navn"), "Tekst", "Overskrift")));

// Middlware der kører før hver request. Sætter ContentType for alle responses til "JSON".
app.Use(async (context, next) =>
{
    context.Response.ContentType = "application/json; charset=utf-8";
    await next(context);
});

// DataService fås via "Dependency Injection" (DI)
app.MapGet("/", (DataService service) =>
{
    return new { message = "Hello World!" };
});

app.MapGet("/api/tråde", async (DataService service) =>
{
    var trådes = await service.GetTrådesAsync();
    return trådes;
});
// post en tråd
app.MapPost("/api/tråde", async (DataService service, Tråde tråd) =>
{
    var trådes = await service.PostTrådesAsync(tråd);
    return trådes;
});
// en post til at kommentere på en bestemt tråd id (Du får id med i URL/api'en
app.MapPost("/api/tråde/{id}/kommentar/", async (DataService service, Kommentar kommentar, int id) =>
{
    var trådes = await service.PostKommentarAsync(kommentar, id);
    return trådes;
});
app.MapPut("/api/tråde/{id}/upvote/", async (DataService service, int id) =>
    {
    var UpvoteTråd = await service.PutUpvoteTrådAsync(id);
    return UpvoteTråd;
});
app.MapPut("/api/tråde/{id}/downvote/", async (DataService service, int id) =>
{
    var DownvoteTrådes = await service.PutDownvoteTrådAsync(id);
    return DownvoteTrådes;
});
app.MapPut("/api/tråde/{idT}/kommentar/{idK}/upvote", async (DataService service, int idT, int idK) =>
{
    var UpvoteKommentar = await service.PutUpvoteKommentarAsync(idT, idK);
    return UpvoteKommentar;
});
app.MapPut("/api/tråde/{idT}/kommentar/{idK}/downvote", async (DataService service, int idT, int idK) =>
{
    var DownvoteKommentar = await service.PutDownvoteKommentarAsync(idT, idK);
    return DownvoteKommentar;
});

app.Run();

