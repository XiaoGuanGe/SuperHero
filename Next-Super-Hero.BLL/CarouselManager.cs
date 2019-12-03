using Next_Super_Hero.DAL;
using Next_Super_Hero.DTO;
using Next_Super_Hero.BLL;
using Next_Super_Hero.IDAL;
using Next_Super_Hero.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Next_Super_Hero.BLL
{
    public class CarouselManager : ICarouselManager
    {
        public async Task<bool> AddCarousel(string imgUrl, string moiveId)
        {
            using (ICarouselService carouselSer = new CarouselService())
            {
                if (await carouselSer.GetAllAsync().AnyAsync(m => m.MovieId == moiveId))
                {
                    return false;
                }
                else
                {
                    await carouselSer.CreateAsync(
                        new Models.Carousel
                        {
                            ImgUrl=imgUrl,
                            MovieId=moiveId
                        }
                    );
                    return true;
                }
            }
        }
        //查询所有
        public async Task<List<CarouselDto>> GetAllAsync()
        {
            using (ICarouselService carouselSer = new CarouselService())
            {

                return await carouselSer.GetAllAsync().Select(m=>new CarouselDto()
                {
                    ImgUrl=m.ImgUrl,
                    MovieId=m.MovieId,
                    Id=m.Id
                }).ToListAsync();
            }
        }

        public async Task<bool> Remove(string movieId)
        {
            using (ICarouselService carouselSer = new CarouselService())
            {
                if (await carouselSer.GetAllAsync().AnyAsync(m => m.MovieId == movieId))
                {
                    var carouse = await carouselSer.GetAllAsync().FirstAsync(m => m.MovieId == movieId);
                    await carouselSer.RemoveAsync(carouse.Id);
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
