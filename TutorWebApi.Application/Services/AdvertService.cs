using AutoMapper;
using TutorWebApi.Application.Authorization;
using TutorWebApi.Application.Exceptions;
using TutorWebApi.Application.Interfaces;
using TutorWebApi.Application.Models.Advert;
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

        public AdvertService(IAdvertRepository advertRepository, IMapper mapper,
             IUserContextService contextService,
             IProfileRepository profileRepository)
        {
            _advertRepository = advertRepository;
            _mapper = mapper;
            _contextService = contextService;
            _profileRepository = profileRepository;
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

        public async Task<AdvertDto> GetAdvertById(int id)
        {
            var advert = await _advertRepository.GetAdvertById(id);
            if (advert is null)
                throw new NotFoundException("Advert not found");
            var advertDto = _mapper.Map<AdvertDto>(advert);
            return advertDto;
        }
    }
}
