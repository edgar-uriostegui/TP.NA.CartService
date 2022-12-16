using TP.NA.CartService.Data;
using TP.NA.CartService.Models;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/v1/cartService", () =>
{
    return Results.Ok(CartStore.LstCart);
})
.WithName("GetCartService")
.WithOpenApi();


app.MapGet("/v1/cartService/{id:int}", (int id) =>
{
    return Results.Ok(CartStore.LstCart.Find(x => x.Id == id));
})
.WithName("GetCartServiceId")
.WithOpenApi();

app.MapPost("/v1/cartService/", (Cart CartObj) =>
{
    var id = CartStore.LstCart.OrderByDescending(x => x.Id).FirstOrDefault().Id + 1;
    CartObj.Id = id;
    CartStore.LstCart.Add(CartObj);
    return Results.Ok(CartObj);
}
).WithName("PostCartServiceAddProduct")
.WithOpenApi();

app.MapDelete("/v1/cartService/{id:int}", (int id) =>
{
    Cart cartItem = CartStore.LstCart.Find(x => x.Id == id);
    CartStore.LstCart.Remove(cartItem);
    return Results.Ok(cartItem);
})
.WithName("GetCartServiceIdRemoveProduct")
.WithOpenApi(); 

app.Run();

