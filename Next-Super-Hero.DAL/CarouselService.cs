using Next_Super_Hero.IDAL;
using Next_Super_Hero.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Next_Super_Hero.DAL
{
    public class CarouselService : BaseService<Carousel>,ICarouselService
    {
        public CarouselService() : base(new Model.SuperHeroContext())
        {
        }
    }
}
