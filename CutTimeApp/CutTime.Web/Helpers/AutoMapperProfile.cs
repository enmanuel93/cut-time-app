using AutoMapper;
using CutTime.Domain.Models;
using CutTime.Web.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CutTime.Web.Helpers
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, LoginDto>();
        }
    }
}
