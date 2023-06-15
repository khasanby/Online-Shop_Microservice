namespace Catalog.API.Models
{
    public interface IProduct
    {
        public string Name { get; set; }

        /// <summary>
        /// Gets and sets category.
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// Gets and sets summary.
        /// </summary>
        public string Summary { get; set; }

        /// <summary>
        /// Gets and sets description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets and sets image file path.
        /// </summary>
        public string ImageFile { get; set; }

        /// <summary>
        /// Gets and sets price.
        /// </summary>
        public decimal Price { get; set; }
    }
}