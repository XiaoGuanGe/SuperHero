using Next_Super_Hero.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Next_Super_Hero.Models
{
    public class GetHotHeroReturn
    {
        public List<HotHeroDto> ListHeroHot { get; set; }
        public string Msg { get; set; }
        public int Status{ get; set; }
    }
}