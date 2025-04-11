using Ambev.DeveloperEvaluation.Application.Orders.GetOrder;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Orders.GetOrder
{
    public class GetOrderProfile : Profile
    {
        public GetOrderProfile()
        {
            CreateMap<GetOrderResult, GetOrderResponse>();
            CreateMap<GetOrderItemDto, GetOrderItemResponse>();
        }
    }
}
