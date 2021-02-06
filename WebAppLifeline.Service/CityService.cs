using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAppLifeline.DAL;
using WebAppLifeline.DAL.Models;

namespace WebAppLifeline.Service
{
    public class CityService: ICityService
    {
        private LifelineContext _dbContext;
        public CityService(LifelineContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<IList<City>> getCityList(){
            return await _dbContext.Cities.ToListAsync();
        }

    }
}
