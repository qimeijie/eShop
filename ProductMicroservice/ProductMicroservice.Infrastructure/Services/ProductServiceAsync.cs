﻿using AutoMapper;
using ProductMicroservice.ApplicationCore.Contracts.Repositories;
using ProductMicroservice.ApplicationCore.Contracts.Services;
using ProductMicroservice.ApplicationCore.Entities;
using ProductMicroservice.ApplicationCore.Models;
using ProductMicroservice.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductMicroservice.Infrastructure.Services
{
    public class ProductServiceAsync : IProductServiceAsync
    {
        private readonly IMapper mapper;
        private readonly IProductRepositoryAsync productRepositoryAsync;

        public ProductServiceAsync(IMapper mapper, IProductRepositoryAsync productRepositoryAsync)
        {
            this.mapper = mapper;
            this.productRepositoryAsync = productRepositoryAsync;
        }
        public Task<int> DeleteAsync(int id)
        {
            return productRepositoryAsync.DeleteAsync(id);
        }

        public async Task<IEnumerable<ProductResponseModel>> GetAllAsync()
        {
            return mapper.Map<IEnumerable<ProductResponseModel>>(await productRepositoryAsync.GetAllAsync());
        }

        public async Task<ProductResponseModel?> GetByIdAsync(int id)
        {
            return mapper.Map<ProductResponseModel>(await productRepositoryAsync.GetByIdAsync(id));
        }

        public async Task<IEnumerable<ProductResponseModel>> GetListProducts(int pageId, int pageSize, int? categoryId)
        {
            return mapper.Map<IEnumerable<ProductResponseModel>>(await productRepositoryAsync.GetListProducts(pageId, pageSize, categoryId));
        }

        public async Task<IEnumerable<ProductResponseModel>> GetProductByCategoryId(int categoryId)
        {
            return mapper.Map<IEnumerable<ProductResponseModel>>(await productRepositoryAsync.GetProductByCategoryId(categoryId));
        }

        public async Task<IEnumerable<ProductResponseModel>> GetProductByProductName(string productName)
        {
            return mapper.Map<IEnumerable<ProductResponseModel>>(await productRepositoryAsync.GetProductByProductName(productName));

        }

        public Task<int> InsertAsync(ProductRequestModel entity)
        {
            var p = mapper.Map<Product>(entity);
            return productRepositoryAsync.InsertAsync(p);
        }

        public Task<int> UpdateAsync(ProductRequestModel entity)
        {
            var p = mapper.Map<Product>(entity);
            return productRepositoryAsync.UpdateAsync(p);
        }
    }
}
