using AutoMapper;
using BusinessLogic.Services.Abstractions.Requests;
using CatalogManager.ViewModels;
using CatalogManager.Presentors.Requests;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CatalogManager.Presentors.TitlesGroupsPresentors
{
    public class TitlesGroupsOrderByPresentor : IPresentor<IEnumerable<TitlesGroupViewModel>, GetTitlesGroupsByCatalogId>
    {
        private readonly ITitlesRequestsService _titlesRequestsService;
        private readonly IMapper _mapper;

        public TitlesGroupsOrderByPresentor(ITitlesRequestsService titlesRequestsService, IMapper mapper)
        {
            _titlesRequestsService = titlesRequestsService ??
                throw new ArgumentNullException(nameof(titlesRequestsService));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        public IEnumerable<TitlesGroupViewModel> Get(GetTitlesGroupsByCatalogId request)
        {
            var titles = _titlesRequestsService
                .GetAllByCatalogId(request.CatalogId)
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
