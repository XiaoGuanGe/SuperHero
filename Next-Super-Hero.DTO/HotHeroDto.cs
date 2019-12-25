using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Next_Super_Hero.DTO
{
    public class HotHeroDto
    {
        public string MovieId { get; set; }

        /// <summary>
        /// 电影名字
        /// </summary>
        public string MovieName { get; set; }
        /// <summary>
        /// 海报url
        /// </summary>
        public string Poster { get; set; }
        /// <summary>
        /// 封面url
        /// </summary>
        public string Cover { get; set; }
        /// <summary>
        /// 预告url
        /// </summary>
        public string Trailer { get; set; }
        /// <summary>
        /// 评分
        /// </summary>
        public float Score { get; set; }
        /// <summary>
        /// 点赞数
        /// </summary>
        public int PrisedCounts { get; set; }
        /// <summary>
        /// 简介
        /// </summary>
        public string PlotDesc { get; set; }

    }
}
