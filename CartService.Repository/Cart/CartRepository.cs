namespace CartService.Repository.Cart
{
    using CartService.Application.Abstractions.Repository;
    using CartService.Domain.Entities;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// Cart repository implementation
    /// </summary>
    public class CartRepository : ICartRepository
    {
        public async Task<CartEntity> AddAsync(CartEntity entity)
        {
            int last = CartMemoryFactory.listCart.OrderByDescending(x => x.Id).FirstOrDefault().Id + 1;

            entity.Id = last;

            CartMemoryFactory.listCart.Add(entity);

            return await Task.FromResult(entity);
        }

        public async Task<CartEntity> AddProductAsync(int cartId, ProductEntity product)
        {
            var cart = CartMemoryFactory.listCart.FirstOrDefault(x => x.Id == cartId);
            cart.Products.Add(product);

            return await Task.FromResult(cart);
        }

        public async Task<CartEntity> DeleteProductAsync(int cartId, int productId)
        {
            var cart = CartMemoryFactory.listCart.FirstOrDefault(x => x.Id == cartId);
            var product = cart.Products.FirstOrDefault(x => x.Id == productId);
            cart.Products.Remove(product);

            return await Task.FromResult(cart);
        }

        public async Task<IEnumerable<CartEntity>> GetAllAsync()
        {
            var all = CartMemoryFactory.listCart.ToList();

            return await Task.FromResult(all);
        }

        public async Task<CartEntity> GetByIdAsync(int id)
        {
            var found = CartMemoryFactory.listCart.FirstOrDefault(c => c.Id == id);

            return await Task.FromResult(found);
        }

        public async Task<CartEntity> UpdateProductQuantityAsync(int cartId, int productId, int quantity)
        {
            var cart = CartMemoryFactory.listCart.FirstOrDefault(c => c.Id.Equals(cartId));
            var product = cart.Products.FirstOrDefault(c => c.Id == productId);
            product.Quantity = quantity;

            return await Task.FromResult(cart);
        }
    }
}