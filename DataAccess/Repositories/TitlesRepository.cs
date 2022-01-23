using AutoMapper;
using BusinessLogic.DTO;
using BusinessLogic.Repositories;
using DataAccess.Data;
using DataAccess.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Repositories
{
    public class TitlesRepository : ITitlesRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public TitlesRepository(AppDbContext context, IMapper mapper)
        {
            _context = context ??
                throw new ArgumentNullException(nameof(context));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        public void Create(TitleDTO titleDTO)
        {
            var mappedTitle = _mapper.Map<Title>(titleDTO);

            _context.Titles.Add(mappedTitle);
            _context.SaveChanges();
        }

        public void DeleteById(int id)
        {
            var title = _context.Titles
                .FirstOrDefault(title => title.TitleId == id);

            _context.Titles.Remove(title);
            _context.SaveChanges();
        }

        public IEnumerable<TitleDTO> GetAll()
        {
            var titles = _context.Titles
                .Include(title => title.Catalog)
                .ToList();

            return titles
                .Select(title => _mapper.Map<TitleDTO>(title));
        }

        public TitleDTO GetById(int id)
        {
            var title = _context.Titles
                .FirstOrDefault(title => title.TitleId == id);

            return _mapper.Map<TitleDTO>(title);
        }

        public void Update(TitleDTO titleDTO)
        {
            var title = _context.Titles
                .FirstOrDefault(title => title.TitleId == titleDTO.TitleId);

            title.Name = titleDTO.Name;
            title.Tag = titleDTO.Tag;
            title.Count = titleDTO.Count;

            _context.SaveChanges();
        }
    }
}
