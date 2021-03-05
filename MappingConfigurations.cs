using AutoMapper;
using PeaceHotelAPI.Dtos;
using PeaceHotelAPI.Entities;
using System;

namespace PeaceHotelAPI
{
    public class MappingConfigurations : Profile
    {
        public MappingConfigurations()
        {
            CreateMap<ClientCreateDto, Client>()
                .ForMember(d => d.DateCheckedIn, option => option.MapFrom(s => DateTime.Now));

            CreateMap<BookRoomDto, Room>()
                .ForMember(d => d.RoomOccupant, option => option.MapFrom(s => string.Concat(s.FirstName, s.LastName)))
                .ForMember(d => d.RoomFree, option => option.MapFrom(s => RoomFree.N))
                .ForMember(d => d.RoomName, option => option.Ignore())
                .ForMember(d => d.RoomCost, option => option.Ignore());
                






    }

}
}