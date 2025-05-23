﻿using AutoMapper;
using HelpApp.Application.DTOs;
using HelpApp.Application.Interfaces;
using HelpApp.Domain.Interfaces;

namespace HelpApp.Application.Services
{
    public class CategoryServices : ICategoryServices
    {
        private ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryServices(ICategoryRepository categoryRepository, IMapper mapper) 
        {
            _categoryRepository= categoryRepository;
            _mapper= mapper;
        }

        public Task<IEnumerable<CategoryDTO>> GetCategories()
        {
            throw new NotImplementedException();
        }

        public Task<CategoryDTO> GetById(int? id)
        {
            throw new NotImplementedException();
        }

        public Task Add(CategoryDTO categoryDto)
        {
            throw new NotImplementedException();
        }

        public Task Update(CategoryDTO categoryDto)
        {
            throw new NotImplementedException();
        }

        public Task Remove(int? id)
        {
            throw new NotImplementedException();
        }
        //teste
    }
}
