using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace SomeWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SparePartsController : ControllerBase
    {
        ISparePartService _sparePartService;

        public SparePartsController(ISparePartService sparePartService)
        {
            _sparePartService = sparePartService;
        }

        [HttpPost]
        public IActionResult Post(SparePartCreateModel sparePart)
        {
            if (!ModelState.IsValid)
            {
                return new BadRequestResult();
            }

            _sparePartService.CreateNewPart(sparePart);

            return Created();
        }
    }

    public class SparePartService : ISparePartService
    {
        private ISparePartRepository _sparePartRepository;
        private IValidNameService _validNameService;

        public SparePartService(ISparePartRepository sparePartRepository, IValidNameService validNameService)
        {
            _sparePartRepository = sparePartRepository;
            _validNameService = validNameService;
        }

        public void CreateNewPart(SparePartCreateModel model)
        {
            if (!_validNameService.IsValid(model.Name))
            {
                throw new InvalidOperationException("Name is invalid");
            }

            var part = new SparePart
            {
                Name = model.Name
            };

            _sparePartRepository.Save(part);
        }
    }

    public interface IValidNameService
    {
        bool IsValid(string name);
    }

    public interface ISparePartRepository
    {
        void Save(SparePart part);
    }

    public interface ISparePartService
    {
        void CreateNewPart(SparePartCreateModel model);
    }

    public class SparePartCreateModel
    {
        [Required]
        public string Name { get; set; }
    }

    public class SparePart
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
