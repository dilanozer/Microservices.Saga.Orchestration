using MassTransit;
using Order.API.Context;
using Shared.OrderEvents;

namespace Order.API.Consumers
{
    public class OrderCompletedEventConsumer : IConsumer<OrderCompletedEvent>
    {
        readonly OrderDbContext _orderDbContext;

        public OrderCompletedEventConsumer(OrderDbContext orderDbContext)
        {
            _orderDbContext = orderDbContext;
        }

        public async Task Consume(ConsumeContext<OrderCompletedEvent> context)
        {
            Order.API.Models.Order order = await _orderDbContext.Orders.FindAsync(context.Message.OrderId);
            if (order != null)
            {
                order.OrderStatus = Enums.OrderStatus.Completed;
                await _orderDbContext.SaveChangesAsync();
            }
        }
    }
}

