using Core.DataAccess;
using Core.Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstrasts
{
    public  interface  IUserDal : IEntityRepository<User>
    {

        List<OperationClaim> GetClaims(User user);
    }
}
