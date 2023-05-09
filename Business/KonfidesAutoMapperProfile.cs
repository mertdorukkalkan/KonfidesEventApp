using AutoMapper;
using Business.DTOs.Address;
using Business.DTOs.City;
using Core.Business.DTOs.Address;
using Core.Business.DTOs.Category;
using Core.Business.DTOs.Event;
using Core.Business.DTOs.Status;
using Core.Business.DTOs.Ticket;
using Domain;


namespace Business
{
    public class KonfidesAutoMapperProfile : Profile
    {
        public KonfidesAutoMapperProfile()
        {
            #region Category
            CreateMap<Category, CategoryGetDto>();
            CreateMap<CategoryDto, Category>();
            #endregion
            #region City
            CreateMap<City, CityGetDto>();
            CreateMap<CityDto, City>();
            #endregion
            #region Status
            CreateMap<Status, StatusGetDto>();
            CreateMap<StatusDto, Status>();
            #endregion
            #region Address

            CreateMap<Address, AddressGetDto>()
                .ForMember(x => x.CityName, x => x.MapFrom(y => y.City.CityName));
            CreateMap<AddressCreateDto, Address>();
            CreateMap<AddressCreateDto, City>();
            CreateMap<AddressUpdateDto, Address>();
            #endregion
            #region Event
            CreateMap<Event, EventGetDto>()
                .ForMember(x => x.FirstName, x => x.MapFrom(y => y.ApplicationUser.FirstName))
                .ForMember(x => x.LastName, x => x.MapFrom(y => y.ApplicationUser.LastName))
                .ForMember(x => x.CategoryName, x => x.MapFrom(y => y.Category.CategoryName))
                .ForMember(x => x.Street, x => x.MapFrom(y => y.Address.Street))
                .ForMember(x => x.AddressId, x => x.MapFrom(y => y.Address.Id))
                .ForMember(x => x.AddressDescription, x => x.MapFrom(y => y.Address.AddressDescription))
                .ForMember(x => x.CityId, x => x.MapFrom(y => y.Address.City.Id))
                .ForMember(x => x.StatusCode, x => x.MapFrom(y => y.Status.StatusCode));
            CreateMap<EventCreateDto, Event>();
            CreateMap<EventUpdateDto, Event>();
            CreateMap<EventCreateDto, Address>();
            CreateMap<EventUpdateDto, Address>();
            

            #endregion

            #region Ticket

            CreateMap<Ticket, TicketGetDto>()
                .ForMember(x => x.FirstName, x => x.MapFrom(y => y.ApplicationUser.FirstName))
                .ForMember(x => x.LastName, x => x.MapFrom(y => y.ApplicationUser.LastName))
                .ForMember(x => x.EventName, x => x.MapFrom(y => y.Event.EventName));
            CreateMap<TicketCreateDto, Ticket>();
            

            #endregion

        }
    }
}