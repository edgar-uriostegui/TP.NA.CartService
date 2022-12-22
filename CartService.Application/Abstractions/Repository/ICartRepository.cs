﻿namespace CartService.Application.Abstractions.Repository
{
    using CartService.Application.Commons;
    using CartService.Domain.Entities;

    /// <summary>
    /// Cart repository interface 
    /// </summary>
    public interface ICartRepository 
    {
        /// <summary>
        /// Add a new record asynchronism
        /// </summary>
        /// <param name="entity">T entity</param>
        /// <returns>Cart entity</returns>
        Task<CartEntity> AddAsync(CartEntity entity);

        /// <summary>
        /// Get all records asynchronism
        /// </summary>
        /// <returns>Cart entity</returns>
        Task<IEnumerable<CartEntity>> GetAllAsync();

        /// <summary>
        /// Get record by id asynchronism
        /// </summary>
        /// <param name="id">Record id</param>
        /// <returns>Cart entity</returns>
        Task<CartEntity> GetByIdAsync(int id);

        /// <summary>
        /// Add new product to a cart asynchronism
        /// </summary>
        /// <param name="cartId">Cart id</param>
        /// <param name="product">Product entity</param>
        /// <returns>Cart entity</returns>
        Task<CartEntity> AddProductAsync(int cartId, ProductEntity product);

        /// <summary>
        /// Update quantity of a product in a cart asynchronism
        /// </summary>
        /// <param name="cartId">Cart id</param>
        /// <param name="productId">Product id</param>
        /// <param name="quantity">Product quantity</param>
        /// <returnsCart entity</returns>
        Task<CartEntity> UpdateProductQuantityAsync(int cartId, int productId, int quantity);

        /// <summary>
        /// Remove o delete a product of a cart asynchronism
        /// </summary>
        /// <param name="cartId">Cart id</param>
        /// <param name="productId">Product id</param>
        /// <returns>Cart entity</returns>
        Task<CartEntity> DeleteProductAsync(int cartId, int productId);
    }
}
