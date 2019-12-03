using Next_Super_Hero.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Threading.Tasks;
using Next_Super_Hero.BLL;
using Next_Super_Hero.Models;

namespace Next_Super_Hero.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/SuperHero")]
    public class SuperHeroController : ApiController
    {
        [HttpGet]
        [Route("GetTest")]
        public string GetTest()
        {
            return "yes";
        }



        [HttpPost]
        [Route("GetCarousel")]
        public Task<List<CarouselDto>> GetCarousel()
        {
            CarouselManager cm = new CarouselManager();
            var result = cm.GetAllAsync();
            return result;
        }
        //添加轮播图，需要一个ImgUrl和一个MoiveId
        [HttpPost]
        [Route("AddCarousel")]
        public Task<bool> AddCarousel(Carousel carousel)
        {
            CarouselManager cm = new CarouselManager();
            var result = cm.AddCarousel(carousel.ImgUrl,carousel.MovieId);
            return result;
        }
        //轮播图的删除未写
    }
}
