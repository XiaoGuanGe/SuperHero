using Next_Super_Hero.IDAL;
using Next_Super_Hero.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Next_Super_Hero.DAL
{
    public class HotHeroService:BaseService<HotHero>,IHotHeroService
    {
        public HotHeroService() : base(new SuperHeroContext())
        {
        }
    }
}
