using Next_Super_Hero.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Next_Super_Hero.IBLL
{
    public interface IHotHeroManager
    {
        Task<bool> AddHotHeroAsync(string movieId, string moiveName,string poster,string cover,string trailer,float score,int prisedCounts,string plotDesc);
        /// <summary>
        /// 根据电影ID来删除
        /// </summary>
        /// <param name="moiveId"></param>
        /// <returns></returns>
        Task<bool> RemoveAsync(string moiveId);
        /// <summary>
        /// 获得所有的热点电影信息
        /// </summary>
        /// <returns></returns>
        Task<List<HotHeroDto>> GetAllHotHeroAsync();
    }
}
