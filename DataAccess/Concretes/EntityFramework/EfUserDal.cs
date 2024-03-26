using Core.DataAccess.EntityFramework;
using Core.Entities.Concretes;
using DataAccess.Abstrasts;
using DataAccess.Concretes.EntityFramework.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concretes.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, RentACarContext>,  IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (RentACarContext context = new())            
            {
                var result = from userclaim in   context.UserOperationClaims
                             join  claim  in   context.OperationClaims
                             on  userclaim.OperationClaimId equals claim.Id
                             where userclaim.UserId == user.Id
                             select new OperationClaim { Id = claim.Id, Name = claim.Name };
                return result.ToList();


            }
        }
    }
}
