using BikeStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeStore.DataAccess.Repository.IRepository
{
    public interface IBikeTypeRepository : IRepository<BikeType>
    {
        //If I want to do Update/Save I need to add the methods here
        void Update(BikeType bikeType);
    }
}
