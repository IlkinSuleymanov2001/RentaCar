using Core.Entities.Concretes;
using Entities.Concrets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages

    {
        public static string CarImageSuccessAdd = "sekil elave olundu";
        public static string ImagesLimitExceeded= "sekilin limit sayi 5 ,siz limiti asirsiz";

        public static string  NotFoundImage = "sekil server terefinden tapila bilmedi";
        public static string DefaultImage = "sekil elave olunmuyub";

        public static string NotExistsImage = "bu idli sekil movcud deyil";
        public static string UpdatedCarImage = "sekil update edildi...";

        public static string UserAlreadyExists { get; internal set; }
        public static string AccessTokenCreated { get; internal set; }
        public static string SuccessfulLogin { get; internal set; }
        public static User PasswordError { get; internal set; }
        public static User UserNotFound { get; internal set; }
        public static string UserRegistered { get; internal set; }
        public static string? AuthorizationDenied { get; internal set; }
    }
}
