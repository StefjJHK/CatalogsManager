using AutoMapper;
using BusinessLogic.Services.Abstractions.Requests;
using CatalogManager.ViewModels;
using CatalogManager.Presentors.Requests;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CatalogManager.Presentors.CatalogsPresentors
{
    public class CatalogsOrderByPresentor : IPresentor<IEnumerable<CatalogViewModel>, GetAllCatalogs>
    {
        private readonly ICatalogsRequestsService _catalogsRequestsService;
        private readonly IMapper _mapper;

        public CatalogsOrderByPresentor(ICatalogsRequestsService catalogsRequestsService, IMapper mapper)
        {
            _catalogsRequestsService = catalogsRequestsService ??
                throw new ArgumentNullException(nameof(catalogsRequestsService));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        public IEnumerable<CatalogViewModel> Get(GetAllCatalogs request)
        {
            return _catalogsRequestsService
                .GetAll()
                .Select(catalog => _mapper.Map<CatalogViewModel>(catalog))
                .OrderBy(catalog => catalog.Kind);
        }
    }
}
