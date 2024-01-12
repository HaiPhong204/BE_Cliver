using AutoMapper;
using CliverApi.DTOs;
using CliverApi.DTOs.Master;
using CliverApi.DTOs.Order;
using CliverApi.DTOs.User;
using CliverApi.Models;
using Newtonsoft.Json;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<int?, int>().ConvertUsing((src, dest) => src ?? dest);

        CreateMap<User, UserDto>()
        .ForMember(u => u.Languages, opt => opt.MapFrom(uSrc => JsonConvert.DeserializeObject<List<Language>>(uSrc.Languages)));

        CreateMap<UpdateUserDto, User>()
        .ForMember(u => u.Languages, opt => opt.MapFrom((uSrc, des) => uSrc.Languages != null  ? JsonConvert.SerializeObject(uSrc.Languages) : des.Languages))
        .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

        CreateMap<UserDto, User>();

       CreateMap<CreatePostDto, Post>()
            .ForMember(p => p.Tags, options => options.MapFrom(p => string.Join(';', p.Tags).Replace(" ", "")));
            

        CreateMap<Wallet, WalletDto>();


        CreateMap<Package, PackageDto>();
        CreateMap<PackageDto, Package>();
        CreateMap<UpsertPackageDto, Package>();
        CreateMap<Package, CustomPackageDto>();
        CreateMap<CreateCustomPackageDto, Package>();
        //CreateMap<IEnumerable<PackageDto>, IEnumerable<Package>>();

        CreateMap<UpdatePostDto, Post>()
            .ForMember(d => d.Packages, o => o.Ignore())
            .ForMember(d => d.Tags, options => options.MapFrom(p => p.Tags != null ? string.Join(';', p.Tags).Replace(" ", "") : null))
            .ForMember(d => d.Images, options => options.MapFrom(p => p.Images != null ? string.Join(';', p.Images).Replace(" ", "") : null))
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

        CreateMap<Post, SimplePostDto>()
            .ForMember(pDto => pDto.Tags, options => options.MapFrom(p => p.Tags.Split(';', StringSplitOptions.RemoveEmptyEntries)))
            .ForMember(pDto => pDto.Images, options => options.MapFrom(p => p.Images.Split(';', StringSplitOptions.RemoveEmptyEntries)));
        CreateMap<Post, PostDto>()
            .ForMember(pDto => pDto.Tags, options => options.MapFrom(p => p.Tags.Split(';', StringSplitOptions.RemoveEmptyEntries)))
            .ForMember(pDto => pDto.Images, options => options.MapFrom(p => p.Images.Split(';', StringSplitOptions.RemoveEmptyEntries)))
            .ForMember(pDto => pDto.MinPrice, options => options.MapFrom(p => p.Packages.Count() > 0 ? p.Packages.OrderBy(p => p.Price).FirstOrDefault()!.Price : 0));


        //Order
        CreateMap<Order, OrderDto>();
        CreateMap<OrderDto, Order>();
        CreateMap<CreateOrderDto, Order>();
        CreateMap<OrderHistory, OrderHistoryDto>();
        CreateMap<Resource, ResourceDto>();

        //Message
        CreateMap<Room, RoomDto>();

        CreateMap<Message, MessageDto>();
        CreateMap<CreateMessageDto, Message>()
        .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

        //Wallet
        CreateMap<Wallet, WalletDto>();

        //SavedList
        CreateMap<SavedList, SavedListDto>();
        
        //Service request
        CreateMap<ServiceRequest, ServiceRequestDto>()
        .ForMember(sR => sR.Tags, opt => opt.MapFrom(sR=> JsonConvert.DeserializeObject<List<string>>(sR.Tags)));

         CreateMap<CreateServiceRequestDto, ServiceRequest>()
        .ForMember(sR => sR.Tags, opt => opt.MapFrom(sR => JsonConvert.SerializeObject(sR.Tags)));

        CreateMap<UpdateServiceRequestDto, ServiceRequest>()
       .ForMember(sR => sR.Tags, opt => opt.MapFrom((sR, src) => sR.Tags != null ? JsonConvert.SerializeObject(sR.Tags) : src.Tags));


        //Review
        CreateMap<Review, ReviewDto>();
        CreateMap<CreateReviewDto, Review>();
        CreateMap<Review, ReviewSentimentDto>();
   
    }
}