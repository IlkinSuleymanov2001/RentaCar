using Core.Utilities.Business;
using Core.Utilities.Results;
using Entities.Concrets;
using Entities.DTOs;


namespace Business.Abstracts
{
    public interface  IColorService 
    {

        IDataResult<List<Color>> GetAll();
        IResult Add(Color entity);
        IDataResult<Color> GetById(int id);
        IResult Delete(Color entity);
        IResult Update(Color entity);

    }
}
