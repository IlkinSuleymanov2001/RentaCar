
using Core.Utilities.Results;
using Entities.Concrets;
using Entities.DTOs;


namespace Business.Abstracts
{
    public  interface  IBrandService
    {

        IDataResult<List<Brand>> GetAll();
        IResult Add(Brand entity);
        IDataResult<Brand> GetById(int id);
        IResult Delete(Brand entity);
        IResult Update(Brand entity);

    }
}
