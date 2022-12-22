using CartService.Application.Abstractions.Repository;
using CartService.Application.Extensions;
using CartService.Repository.Cart;
using MediatR;
using TP.NA.CartService.Data;
using TP.NA.CartService.Models;
using TP.NA.CartService.Models.Models;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<ICartRepository, CartRepository>();
builder.Services.AddApplicationServices();
builder.Services.ConfigAutoMapper();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//#region Cart management




//app.MapGet("/v1/cartService", () =>
//{
//    return Results.Ok(CartStore.LstCart);
//})
//.WithName("GetCartService")
//.WithOpenApi();


//app.MapGet("/v1/cartService/{id:int}", (int cartId) =>
//{
//    return Results.Ok(CartStore.LstCart.Find(x => x.Id == cartId));
//})
//.WithName("GetCartServiceId")
//.WithOpenApi();

//app.MapGet("/v1/cartService/{userId:int}", (int userId) =>
//{
//    return Results.Ok(CartStore.LstCart.Find(x => x.UserId == userId));
//})
//.WithName("GetCartServiceByUserId")
//.WithOpenApi();

//app.MapPost("/v1/cartService/", (Cart CartObj) =>
//{
//    var id = CartStore.LstCart.OrderByDescending(x => x.Id).FirstOrDefault().Id + 1;
//    CartObj.Id = id;
//    CartStore.LstCart.Add(CartObj);
//    return Results.Ok(CartObj);
//}
//).WithName("CartServiceCreateCart")
//.WithOpenApi();

//#endregion

//#region ManageProducts

//app.MapPost("/v1/cartService/{cartId:int}", (int CartId, Product product) =>
//{
//    var cart = CartStore.LstCart.FirstOrDefault(c => c.Id == CartId);

//    cart.Products.Add(product);

//    return Results.Ok(cart);
//}
//).WithName("CartServiceAddProduct")
//.WithOpenApi();

//app.MapPost("/v1/cartService/{cartId:int}/{productId:int}", (int CartId, int ProductId) =>
//{
//    var cart = CartStore.LstCart.FirstOrDefault(c => c.Id == CartId);
//    var product = CartStore.LstCart.FirstOrDefault(c => c.Id == CartId).Products.FirstOrDefault(x => x.ID == ProductId);


//    cart.Products.Remove(product);

//    return Results.Ok(cart);
//}
//).WithName("CartServiceRemoveProduct")
//.WithOpenApi();

//#endregion

app.ConfigureApp();

app.Run();

