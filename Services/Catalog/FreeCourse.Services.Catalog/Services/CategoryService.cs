﻿using AutoMapper;
using FreeCourse.Services.Catalog.Dtos;
using FreeCourse.Services.Catalog.Model;
using FreeCourse.Services.Catalog.Settings;
using FreeCourse.Shared.Dtos;
using MongoDB.Driver;

namespace FreeCourse.Services.Catalog.Services
{
    public class CategoryService: ICategoryService
    {
        private readonly IMongoCollection<Category> _categoryCollection;
        private readonly IMapper _mapper;

        public CategoryService(IMapper mapper, IDatabaseSettings databaseSettings)
        {

            var client= new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);

            _categoryCollection = database.GetCollection<Category>(databaseSettings.CategoryCollectionName);
            _mapper = mapper;
        }

        public async Task<Response<List<CategoryDto>>> GetAllAsync()
        {
            var categoriList = await _categoryCollection.Find(catgory => true).ToListAsync();

            return Response<List<CategoryDto>>.Success(_mapper.Map<List<CategoryDto>>(categoriList),StatusCodes.Status200OK);
        }

        public async Task<Response<CategoryDto>> CreateAsync(CategoryCreateDto category)
        {
            var newCategory=_mapper.Map<Category>(category);

            await _categoryCollection.InsertOneAsync(newCategory);

            return Response<CategoryDto>.Success(_mapper.Map<CategoryDto>(newCategory),StatusCodes.Status201Created);
        }

        public async Task<Response<CategoryDto>> GetByIdAsync (string id)
        {
            var category=await _categoryCollection.Find<Category>(x=> x.Id==id).FirstOrDefaultAsync();

            if (category == null)
                return Response<CategoryDto>.Fail("Category not found", StatusCodes.Status404NotFound);

            return Response<CategoryDto>.Success(_mapper.Map<CategoryDto>(category), StatusCodes.Status200OK);


        }
    }
}
