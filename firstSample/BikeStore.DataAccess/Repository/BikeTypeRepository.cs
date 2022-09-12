using BikeStore.DataAccess.Repository.IRepository;
using BikeStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeStore.DataAccess.Repository
{
    public class BikeTypeRepository : Repository<BikeType>, IBikeTypeRepository
    {
        private ApplicationDbContext _db;
        public BikeTypeRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(BikeType bikeType)
        {
            _db.BikeType.Update(bikeType);
        }
    }
}
