using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Books.API.Profiles
{
    public class QuoteProfile : Profile
    {
        public QuoteProfile()
        {
            CreateMap<Entities.Quotation,Models.QuoteDto>();
            CreateMap<Models.QuoteForCreationDto, Entities.Quotation>();
            CreateMap<Models.QuoteForUpdateDto, Entities.Quotation>()
                .ReverseMap();
            
            // the ReversMap automatically creates the same as: 
            // CreateMap<Entities.Quotation, Models.QuoteForUpdateDto>();
        }
    }
}


