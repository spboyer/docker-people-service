using Microsoft.AspNet.Mvc;
using docker_people_service.Core;
using System.Linq;


// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860
namespace docker_people_service.Controllers

{
    [RouteAttribute("api/[controller]")]
    public class PeopleController : Controller
    {
        private PeopleGeneratorService _personGenerator = new PeopleGeneratorService();
        private PersonMajor[] _lastResult;

        public PeopleController()
        {

        }

        // GET: api/people/
        [HttpGet]
        public docker_people_service.PersonMajor[] Get()
        {
            LoadPeople();
            return _lastResult;
        }

        // GET: api/people/1
        [HttpGet("{id}")]
        public docker_people_service.PersonMajor Get(int id)
        {
            if (_lastResult == null)
            {
                LoadPeople();
            }
            return _lastResult.SingleOrDefault(p => p.Id == id);
        }

        private void LoadPeople()
        {
            var people = _personGenerator.GenerateMajorPeople(50);
            _lastResult = people;
        }

    }
}
