using Next_Super_Hero.DAL;
using Next_Super_Hero.DTO;
using Next_Super_Hero.IBLL;
using Next_Super_Hero.IDAL;
using Next_Super_Hero.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Next_Super_Hero.BLL
{
    public class HotHeroManager : IHotHeroManager
    {
        /// <summary>
        /// 添加热点电影信息
        /// </summary>
        /// <param name="movieId"></param>
        /// <param name="movieName"></param>
        /// <param name="poster"></param>
        /// <param name="cover"></param>
        /// <param name="trailer"></param>
        /// <param name="score"></param>
        /// <param name="prisedCounts"></param>
        /// <param name="plotDesc"></param>
        /// <returns></returns>
        public async Task<bool> AddHotHeroAsync(string movieId, string movieName, string poster, string cover, string trailer, float score, int prisedCounts, string plotDesc)
        {
            using (IHotHeroService hHeroSer = new HotHeroService())
            {
                //已经存在该影片热点信息
                if (await hHeroSer.GetAllAsync().AnyAsync(m => m.MovieId == movieId))
                {
                    return false;
                }
                else
                {
                    await hHeroSer.CreateAsync(new HotHero
                    {
                        MovieId = movieId,
                        MovieName = movieName,
                        Poster = poster,
                        Cover = cover,
                        Trailer = trailer,
                        Score = score,
                        PrisedCounts = prisedCounts,
                        PlotDesc = plotDesc
                    });
                    return true;
                }
            }
        }

        public async Task<List<HotHeroDto>> GetAllHotHeroAsync()
        {
            using (IHotHeroService hHeroSer = new HotHeroService())
            {
                return await hHeroSer.GetAllAsync().Where(m=>m.IsRemove!=true).OrderBy(m=>m.MovieId).Select(m => new HotHeroDto()
                {
                    MoiveId = m.MovieId,
                    MoiveName = m.MovieName,
                    Poster = m.Poster,
                    Cover = m.Cover,
                    Trailer = m.Trailer,
                    Score = m.Score,
                    PrisedCounts = m.PrisedCounts,
                    PlotDesc = m.PlotDesc
                }).ToListAsync();
            }
        }

        public async Task<bool> RemoveAsync(string moiveId)
        {
            using (IHotHeroService hHeroSer = new HotHeroService())
            {
                //先查是否存在该电影的ID
                if (await hHeroSer.GetAllAsync().AnyAsync(m => m.MovieId == moiveId))
                {
                    var hotHero =await hHeroSer.GetAllAsync().FirstAsync(m => m.MovieId == moiveId);
                    await hHeroSer.RemoveAsync(hotHero.Id);
                    return true;
                }
                else {
                    return false;
                }
            }
        }
    }
}
