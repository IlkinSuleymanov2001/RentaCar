using Business.Abstracts;
using Core.Utilities.Results;
using Entities.Concrets;
using Entities.DTOs.Color;

namespace Business.Concrets
{
    public class ColorManager : IColorService
    {
        public IResult Add(Color entity)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(Color entity)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Color>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IDataResult<Color> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<ColorDto>> GetDetails()
        {
            throw new NotImplementedException();
        }

        public IResult Update(Color entity)
        {
            throw new NotImplementedException();
        }
    }
}
