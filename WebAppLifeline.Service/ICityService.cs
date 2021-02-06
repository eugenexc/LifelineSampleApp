using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebAppLifeline.DAL.Models;

namespace WebAppLifeline.Service
{
    public interface ICityService
    {
        Task<IList<City>> getCityList();
    }
}
