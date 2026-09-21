namespace BackendTienda.DTOs
{
    #region requests

    public record CreateProductRequest(

        int categoryId,
        string name,
        decimal price,
        int stockQuantity,
        IFormFile image
    );

    public record ReturnProductRequest(string categoryId);
    #endregion

    #region responses
    public record GetProductResponse(

        int productId,
        string categoryId,
        string categoryName,
        string name,
        decimal price,
        int stockQuantity,
        string imageUrl
    );
    #endregion

}
