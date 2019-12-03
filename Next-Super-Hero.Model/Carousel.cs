using Next_Super_Hero.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Next_Super_Hero.Models
{
    public class Carousel:BaseEntity
    {
        public string ImgUrl { get; set; }
        public string MovieId { get; set; }
    }
}