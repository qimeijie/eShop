using AutoMapper;
using PromotionsMicroservice.ApplicationCore.Contracts.Repository;
using PromotionsMicroservice.ApplicationCore.Contracts.Service;
using PromotionsMicroservice.ApplicationCore.Entities;
using PromotionsMicroservice.ApplicationCore.Models;

namespace PromotionsMicroservice.Infrastructure.Services
{
    public class PromotionServiceAsync : IPromotionServiceAsync
    {
        private readonly IMapper mapper;
        private readonly IPromotionRepositoryAsync promotionRepositoryAsync;

        public PromotionServiceAsync(IMapper mapper, IPromotionRepositoryAsync promotionRepositoryAsync)
        {
            this.mapper = mapper;
            this.promotionRepositoryAsync = promotionRepositoryAsync;
        }

        public Task<int> DeleteAsync(int id)
        {
            return promotionRepositoryAsync.DeleteAsync(id);
        }

        public async Task<IEnumerable<PromotionResponseModel>> GetActivePromotionsAsync()
        {
            return mapper.Map<IEnumerable<PromotionResponseModel>>(await promotionRepositoryAsync.GetActivePromotionsAsync());
        }

        public async Task<IEnumerable<PromotionResponseModel>> GetAllAsync()
        {
            return mapper.Map<IEnumerable<PromotionResponseModel>>(await promotionRepositoryAsync.GetAllAsync());
        }

        public async Task<PromotionResponseModel> GetByIdAsync(int id)
        {
            return mapper.Map<PromotionResponseModel>(await promotionRepositoryAsync.GetByIdAsync(id));
        }

        public async Task<IEnumerable<PromotionResponseModel>> GetPromotionByProductNameAsync(string productName)
        {
            return mapper.Map<IEnumerable<PromotionResponseModel>>(await promotionRepositoryAsync.GetPromotionByProductNameAsync(productName));
        }

        public async Task<PromotionResponseModel> InsertAsync(PromotionRequestModel promotionRequestModel)
        {
            return mapper.Map<PromotionResponseModel>(await promotionRepositoryAsync.InsertAsync(mapper.Map<Promotion>(promotionRequestModel)));
        }

        public async Task<PromotionResponseModel> UpdateAsync(PromotionRequestModel promotionRequestModel)
        {
            return mapper.Map<PromotionResponseModel>(await promotionRepositoryAsync.UpdateAsync(mapper.Map<Promotion>(promotionRequestModel)));
        }
    }
}
