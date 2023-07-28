using FreeCourse.Services.Basket.Dtos;
using FreeCourse.Shared.Dtos;

namespace FreeCourse.Services.Basket.Services
{
    public interface IBasketServices
    {
        Task<Response<BasketDto>> GetBasket(string userId);

        Task<Response<bool>> SaveOrUpdate(BasketDto basketDto);
        Task<Response<bool>> Delete(string userId);
    }
}
