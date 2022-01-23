using AutoMapper;
using CatalogsManager.ViewModels;
using CatalogsManager.Presentors.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using BusinessLogic.ParametrObjects.Requests.Catalogs;
using BusinessLogic.DTO;
using BusinessLogic.Services.Requests;

namespace CatalogsManager.Presentors.CatalogsPresentors
{
    public class CatalogsOrderByPresentor : IPresentor<IEnumerable<CatalogViewModel>, GetAllCatalogs>
    {
        private readonly IRequestHandler<GetAllCatalogsRequest, IEnumerable<CatalogDTO>> _service;
        private readonly IMapper _mapper;

        public CatalogsOrderByPresentor(IRequestHandler<GetAllCatalogsRequest, IEnumerable<CatalogDTO>> service, IMapper mapper)
        {
            _service = service ?? 
                throw new ArgumentNullException(nameof(service));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        public IEnumerable<CatalogViewModel> Get(GetAllCatalogs request)
        {
            var command = new GetAllCatalogsRequest();

            return _service.Execute(command)
                .Select(catalog => _mapper.Map<CatalogViewModel>(catalog))
                .OrderBy(catalog => catalog.Kind);
        }
    }
}
