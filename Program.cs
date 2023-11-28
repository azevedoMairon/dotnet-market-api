using IWantApp.Endpoints.Category;
using MongoDB.Bson;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// app.MapMethods(CategoryPost.Template, CategoryPost.Methods, CategoryPost.Handle);

const string connectionUri = "mongodb+srv://mairondepaiva:mp210501@cluster0.jyi5wff.mongodb.net/?retryWrites=true&w=majority";
var settings = MongoClientSettings.FromConnectionString(connectionUri);
// Set the ServerApi field of the settings object to Stable API version 1
settings.ServerApi = new ServerApi(ServerApiVersion.V1);
// Create a new client and connect to the server
var client = new MongoClient(settings);
// Send a ping to confirm a successful connection
try
{
    var result = client.GetDatabase("admin").RunCommand<BsonDocument>(new BsonDocument("ping", 1));
}
catch (Exception ex)
{
    Console.WriteLine(ex);
}

app.Run();


