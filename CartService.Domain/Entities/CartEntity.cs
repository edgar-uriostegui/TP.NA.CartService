namespace CartService.Domain.Entities
{
    /// <summary>
    /// Cart class
    /// </summary>
    public class CartEntity
    {
        /// <summary>
        /// Gets or sets cart id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets user id
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets created time
        /// </summary>
        public DateTime CreatedTime { get; set; } = DateTime.Now;

        /// <summary>
        /// Gets or sets update time
        /// </summary>
        public DateTime UpdatedTime { get; set; }

        /// <summary>
        /// Gets or sets products list
        /// </summary>
        public List<ProductEntity> Products { get; set; } = new List<ProductEntity>();
    }
}