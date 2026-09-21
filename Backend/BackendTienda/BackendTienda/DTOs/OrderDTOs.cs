namespace BackendTienda.DTOs
{
    public class OrderDTOs
    {
        #region requests
        public record CreateOrderRequest(
            decimal totalAmount,
            IEnumerable<CreateOrderDetailRequest> details
        );

        public record CreateOrderDetailRequest(
            int productId,
            int quantity,
            decimal unitPrice
        );
        #endregion

        #region responses

        public record GetOrderResponse(
            int orderId,
            string date,
            decimal totalAmount,
            IEnumerable<GetOrderDetailResponse> details
        );


        public record GetOrderDetailResponse(
            string imageUrl,
            string productName,
            int quantity,
            decimal total
        );
                #endregion
            }
        }
