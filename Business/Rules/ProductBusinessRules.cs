using Core.BusinessRules;
using Domain.Entities;
using Repository.Abstract;

namespace Business.Rules
{

    public class ProductBusinessRules : BusinessRulesBase<Product>
    {
        public ProductBusinessRules(IProductRepository repository) : base(repository)
        {
        }
    }
}