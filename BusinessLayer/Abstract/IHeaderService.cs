using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IHeaderService : IGenericService<Header>
    {
        List<Header> GetHeaderbySearch(string p);
    }
}
