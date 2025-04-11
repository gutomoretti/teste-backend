using Ambev.DeveloperEvaluation.Application.Orders.GetAllOrders;
using Ambev.DeveloperEvaluation.WebApi.Features.Orders.GetOrder;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Orders.GetAllOrders
{
    public class GetAllOrdersProfile : Profile
    {
        public GetAllOrdersProfile()
        {
            CreateMap<GetAllOrdersResult, GetAllOrdersResponse>();
        }
    }
}
