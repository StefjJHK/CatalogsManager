using AutoMapper;
using BusinessLogic.DTO;
using BusinessLogic.Repositories;
using DataAccess.Data;
using DataAccess.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Repositories
{
    public class CatalogsRepository : ICatalogsRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public CatalogsRepository(AppDbContext context, IMapper mapper)
        {
            _context = context ??
                throw new ArgumentNullException(nameof(context));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        public void Create(CatalogDTO catalogDTO)
        {
            var mappedCatalog = _mapper.Map<Catalog>(catalogDTO);
           
            _context.Catalogs.Add(mappedCatalog);
            _context.SaveChanges();
        }

        public void DeleteById(int id)
        {
            var catalog = _context.Catalogs
                .FirstOrDefault(catalog => catalog.CatalogId == id);
            
            _context.Catalogs.Remove(catalog);
            _context.SaveChanges();
        }

        public IEnumerable<CatalogDTO> GetAll()
        {
            var catalogs = _context.Catalogs
                .ToList();

            return catalogs
                 .Select(catalog => _mapper.Map<CatalogDTO>(catalog));
        }

        public CatalogDTO GetById(int id)
        {
            var catalog = _context.Catalogs
                .FirstOrDefault(catalog => catalog.CatalogId == id);

            return _mapper.Map<CatalogDTO>(catalog);
        }

        public void Update(CatalogDTO catalogDTO)
        {
            var catalog = _context.Catalogs
                .FirstOrDefault(catalog => catalog.CatalogId == catalogDTO.CatalogId);

            catalog.Kind = catalogDTO.Kind;

            _context.SaveChanges();
        }
    }
}
