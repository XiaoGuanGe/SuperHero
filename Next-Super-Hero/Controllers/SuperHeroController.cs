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
using Next_Super_Hero.Model;

namespace Next_Super_Hero.Controllers
{
    /// <summary>
    /// 所有的删除都未写，删除即在数据库中把该条信息的IsRemove属性改成1，如果修改，则在查询中需要加入逻辑判断If（！IsRemove），并且增加数据时也要加入逻辑判断是否原来已经存在，若存在则。。。不存在则。。。
    /// ？ 为什么要这样做，而不是在数据库中直接删除呢-》可能该条数据存在连级关系，删除该表中的数据，则会导致其他表受到关联，导致出错。
    /// </summary>
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
        
        [HttpPost]
        [Route("AddHotHero")]
        public Task<bool> AddHotHero(HotHero hotHero)
        {
            HotHeroManager hhm = new HotHeroManager();
            var result = hhm.AddHotHeroAsync(hotHero.MovieId,hotHero.MovieName,hotHero.Poster,hotHero.Cover,hotHero.Trailer,hotHero.Score,hotHero.PrisedCounts,hotHero.PlotDesc);
            return result;
        }
        /// <summary>
        /// 目标逻辑：收到请求时，返回一个电影热点集合和返回状态信息，status为接口状态，msg：OK为返回正常数据，
        /// status200为接收请求成功，否则接口失效，msg：error为出错，没有更多信息了!未完善，待学习
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("GetHotHero")]
        public GetHotHeroReturn GetHotHero()
        {
            HotHeroManager hhm = new HotHeroManager();
            //这里返回的是Task<T>
            var result = hhm.GetAllHotHeroAsync();
            var result2=result.Result;
            GetHotHeroReturn getHotHeroReturn = new GetHotHeroReturn();
            if (result != null)
            {
                getHotHeroReturn.ListHeroHot = result2;
                getHotHeroReturn.Msg = "OK";
                getHotHeroReturn.Status = 200;
            }
            else
            {
                getHotHeroReturn.Msg = "error";
                getHotHeroReturn.Status = 200;
            }
            return getHotHeroReturn;
        }
    }
}
