using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
Assembly ControllersAssembly_Layers = Assembly.Load("Layers");
Type myType = ControllersAssembly_Layers.GetType("Layers.Main.Main");
MethodInfo LoadMainMethod = myType.GetMethod("AddDependencies");
object InstanceObject = Activator.CreateInstance(myType);
object[] Parameters = { builder.Services };
LoadMainMethod.Invoke(InstanceObject, Parameters);

builder.Services.AddMvc().AddApplicationPart(ControllersAssembly_Layers).AddControllersAsServices();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
