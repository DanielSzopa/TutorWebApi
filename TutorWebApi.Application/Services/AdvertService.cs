using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using TutorWebApi.Application.Authorization;
using TutorWebApi.Application.Exceptions;
using TutorWebApi.Application.Interfaces;
using TutorWebApi.Application.Models.Advert;
using TutorWebApi.Application.Models.Page;
using TutorWebApi.Domain.Entities;
using TutorWebApi.Domain.Interfaces;

namespace TutorWebApi.Application.Services
{
    public class AdvertService : IAdvertService
    {
        private readonly IAdvertRepository _advertRepository;
        private readonly IMapper _mapper;
        private readonly IUserContextService _contextService;
        private readonly IProfileRepository _profileRepository;
        private readonly IPaginationService _paginationService;
        private readonly IResourceOperationService<Advert> _resourceOperationService;

        public AdvertService(IAdvertRepository advertRepository, IMapper mapper,
             IUserContextService contextService,
             IProfileRepository profileRepository,
             IPaginationService paginationService,
             IResourceOperationService<Advert> resourceOperationService)
        {
            _advertRepository = advertRepository;
            _mapper = mapper;
            _contextService = contextService;
            _profileRepository = profileRepository;
            _paginationService = paginationService;
            _resourceOperationService = resourceOperationService;
        }

        public async Task<int> CreateAdvert(NewAdvertDto advertDto)
        {
            var userId = await _contextService.GetUserId();
            var profile = await _profileRepository.GetProfileByUserId(userId);
            if (profile is null)
                throw new NotFoundException("Profile not found");

            var advert = _mapper.Map<Advert>(advertDto);
            advert.ProfileId = profile.Id;
            var advertId = await _advertRepository.CreateAdvert(advert);
            return advertId;
        }

        public async Task UpdateAdvert(NewAdvertDto advertDto, int id)
        {
            var advert = await GetAdvertIfExist(id);
            var user = await _contextService.GetUser();            
            await _resourceOperationService
                .ResourceAuthorizationException(user,advert, new ResourceOperationRequirement(ResourceOperation.Update));
            advert = _mapper.Map<Advert>(advertDto);
            advert.Id = id;
            await _advertRepository.UpdateAdvert(advert);
        }

        public async Task DeleteAdvert(int id)
        {
            var advert = await GetAdvertIfExist(id);
            var user = await _contextService.GetUser();
            await _resourceOperationService
                .ResourceAuthorizationException(user, advert, new ResourceOperationRequirement(ResourceOperation.Delete));
            await _advertRepository.DeleteAdvert(id);
        }

        public async Task<AdvertDto> GetAdvertById(int id)
        {
            var advert = await GetAdvertIfExist(id);
            var advertDto = _mapper.Map<AdvertDto>(advert);
            return advertDto;
        }

        public async Task<PagedResult<AdvertDto>> GetAllAdverts(AdvertQuery advertQuery)
        {
            var adverts = await _advertRepository.GetAllAdverts();
            var advertDtos = _mapper.Map<IEnumerable<AdvertDto>>(adverts);

            var baseQuery = advertDtos.Where(a => advertQuery.SearchPhrase == null ||
            (a.FullName.ToLower().Contains(advertQuery.SearchPhrase.ToLower()))
            || a.City.ToLower().Contains(advertQuery.SearchPhrase.ToLower()));

            if(!string.IsNullOrEmpty(advertQuery.SortBy))
            {
                var columnsSelectors = new Dictionary<string, Func<AdvertDto, object>>
                {
                    { nameof(AdvertDto.City), r => r.City},
                    { nameof(AdvertDto.Subject), r => r.Subject},
                };

                var selectedColumn = columnsSelectors[advertQuery.SortBy];
                baseQuery = _paginationService.SortRecords<AdvertDto>(selectedColumn, advertQuery.SortDirection, baseQuery.ToList());
            }

            var paginationResult = _paginationService.ReturnRecordsToShow
                (advertQuery.PageNumber, advertQuery.PageSize, baseQuery.ToList());

            var result = new PagedResult<AdvertDto>(paginationResult, baseQuery.Count(), advertQuery.PageSize, advertQuery.PageNumber);
            return result;
        }

        private async Task<Advert> GetAdvertIfExist(int id)
        {
            var advert = await _advertRepository.GetAdvertById(id);
            if (advert is null || advert.IsActive == false)
                throw new NotFoundException("Advert not found");
            return advert;
        }
    }
}
