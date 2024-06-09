using Model.Entities;
using Service.Base;
using Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebsiteBanSua_L.Reponsive.Base;

namespace Service.Service
{
    public class ImageService : BaseService<Image, IBaseRepo<Image>>, IImageService
    {
        public ImageService(IBaseRepo<Image> repo) : base(repo)
        {
        }
    }
}
