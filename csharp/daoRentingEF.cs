using System.ComponentModel.DataAnnotations;

namespace MyMvcProject.Models
{
    public class RentingData
    {
        [Key]
        public int Id { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace MyMvcProject.Models
{
    public class Extras
    {
        [Key]
        public int Id { get; set; }
        public int RentingDataId { get; set; }
        public string Extra { get; set; }

        [ForeignKey(nameof(RentingDataId))]
        public RentingData RentingData { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;
using MyMvcProject.Models;

namespace MyMvcProject.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }

        public DbSet<RentingData> RentingData { get; set; }
        public DbSet<Extras> Extras { get; set; }
    }
}

using MyMvcProject.Models;
using System.Collections.Generic;

namespace MyMvcProject.Repositories
{
    public interface IRentingDataDao
    {
        void InsertRentingData(RentingData rentingData);

        void InsertExtras(Extras extras);

        RentingData GetRentingData(int id);

        List<Extras> GetExtras(int id);
    }
}

using MyMvcProject.Data;
using MyMvcProject.Models;
using System.Collections.Generic;
using System.Linq;

namespace MyMvcProject.Repositories
{
    public class RentingDataDao : IRentingDataDao
    {
        private readonly MyDbContext _context;

        public RentingDataDao(MyDbContext context)
        {
            _context = context;
        }

        public void InsertRentingData(RentingData rentingData)
        {
            _context.RentingData.Add(rentingData);
            _context.SaveChanges();
        }

        public void InsertExtras(Extras extras)
        {
            _context.Extras.Add(extras);
            _context.SaveChanges();
        }

        public RentingData GetRentingData(int id)
        {
            return _context.RentingData.Find(id);
        }

        public List<Extras> GetExtras(int id)
        {
            return _context.Extras.Where(e => e.RentingDataId == id).ToList();
        }
    }
}

using Microsoft.EntityFrameworkCore;
using MyMvcProject.Data;

public void ConfigureServices(IServiceCollection services)
{
    services.AddDbContext<MyDbContext>(options =>
        options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

    services.AddTransient<IRentingDataDao, RentingDataDao>();
}

using Microsoft.AspNetCore.Mvc;
using MyMvcProject.Models;
using MyMvcProject.Repositories;

namespace MyMvcProject.Controllers
{
    public class RentingDataController : Controller
    {
        private readonly IRentingDataDao _dao;

        public RentingDataController(IRentingDataDao dao)
        {
            _dao = dao;
        }

        public IActionResult Create()
        {
            var rentingData = new RentingData { Id = 1 };
            var extrasList = new List<string> { "Extra 1", "Extra 2", "Extra 3" };

            _dao.InsertRentingData(rentingData);

            for (int i = 0; i < extrasList.Count; i++)
            {
                var extras = new Extras { Id = i, RentingDataId = rentingData.Id, Extra = extrasList[i] };
                _dao.InsertExtras(extras);
            }

            return RedirectToAction("Index");
        }
    }
}