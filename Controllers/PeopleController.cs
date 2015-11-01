using Microsoft.AspNet.Mvc;
using docker_people_service.Core;
using System.Linq;


// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860
namespace docker_people_service.Controllers

{
    [RouteAttribute("api/[controller]")]
    public class PeopleController : Controller
    {
        private IPeopleGeneratorService _personGenerator;
        private IPeopleCacheService _cache;

        public PeopleController(IPeopleCacheService cacheService, IPeopleGeneratorService generatorService)
        {
            _cache = cacheService;
            _personGenerator = generatorService;
        }

        // GET: api/people/
        [HttpGet]
        public docker_people_service.PersonMajor[] Get()
        {
           return LoadPeople();
        }

        // GET: api/people/1
        [HttpGet("{id}")]
        public docker_people_service.PersonMajor Get(int id)
        {
            var people = LoadPeople();
            return people.SingleOrDefault(p => p.Id == id);
        }

        private PersonMajor[] LoadPeople()
        {
            var result = _cache.GetPeople();
            if (result == null)
            {
                result = _personGenerator.GenerateMajorPeople(50);
                _cache.SavePeople(result);
            }

            return result;
        }

    }
}
