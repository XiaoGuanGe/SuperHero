using Next_Super_Hero.DTO;
using Next_Super_Hero.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Next_Super_Hero.BLL
{
    public interface ICarouselManager
    {
        Task<bool> AddCarousel(string imgUrl,string moiveId);
        Task<bool> Remove(string moiveId);
        Task<List<CarouselDto>> GetAllAsync();
    }
}
