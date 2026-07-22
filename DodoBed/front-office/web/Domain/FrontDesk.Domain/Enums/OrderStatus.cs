namespace FrontDesk.Domain.Enums;

public enum OrderStatus
{
    PendingReview,
    Scheduled,
    InProduction,
    ReadyForDispatch,
    InTransit,
    Delivered
}
