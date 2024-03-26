using Entities.Concrets;
using FluentValidation;


namespace Business.ValidationRules.FluentValidation
{
    public  class CarValidator  : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c => c.ModelYear).GreaterThan(2000).WithMessage("masin ili 2000 ci ilden yuxari olmalidir");
            RuleFor(c => c.CarName).NotNull().WithMessage("masin adi null ola bilmez..");
            RuleFor(c => c.DailyPrice).GreaterThan(50).WithMessage("50aznden asagi masin kirayesi movcud deyil ");
            
        }
    }
}
