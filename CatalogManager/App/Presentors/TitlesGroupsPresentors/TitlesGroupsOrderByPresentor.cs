using AutoMapper;
using CatalogsManager.ViewModels;
using CatalogsManager.Presentors.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using BusinessLogic.Services.Requests;
using BusinessLogic.ParametrObjects.Requests.Titles;
using BusinessLogic.DTO;

namespace CatalogsManager.Presentors.TitlesGroupsPresentors
{
    public class TitlesGroupsOrderByPresentor : IPresentor<IEnumerable<TitlesGroupViewModel>, GetTitlesGroupsByCatalogId>
    {
        private readonly IRequestHandler<GetAllTitlesByCatalogIdRequest, IEnumerable<TitleDTO>> _service;
        private readonly IMapper _mapper;

        public TitlesGroupsOrderByPresentor(IRequestHandler<GetAllTitlesByCatalogIdRequest, IEnumerable<TitleDTO>> service, IMapper mapper)
        {
            _service = service ??
                throw new ArgumentNullException(nameof(service));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        public IEnumerable<TitlesGroupViewModel> Get(GetTitlesGroupsByCatalogId request)
        {
            var serviceRequest = new GetAllTitlesByCatalogIdRequest() { Id = request.CatalogId };
            var titles = _service.Execute(serviceRequest)
                .Select(title => _mapper.Map<TitleViewModel>(title));

            return titles
                .GroupBy(title => title.Name[0..1])
                .Select(group => new TitlesGroupViewModel() 
                {
                    LexicographicalSign = group.Key, 
                    Titles = group
                })
                .OrderBy(group => group.LexicographicalSign);
        }
    }
}
