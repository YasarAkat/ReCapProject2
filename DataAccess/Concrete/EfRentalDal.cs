using Core.DataAccess.EntityFramework;
using Core.Utilites.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, ReCapContext>, IRentalDal
    {
        public List<RentalDto> GetRentalDetails()
        {
            using (ReCapContext context = new ReCapContext())
            {
                
                var result = from r in context.Rentals
                             join c in context.Cars
                             on r.CarId equals c.CarId
                             join ct in context.Customers
                             on r.CustomerId equals ct.CustomerId
                             join u in context.Users
                             on ct.UserId equals u.UserId
                             select new RentalDto
                             {
                                 RentalId = r.RentalId,
                                 CarName = c.CarName,
                                 DailyPrice = c.DailyPrice,
                                 FirstName = u.FirstName,
                                 LastName = u.LastName,
                                 Email = u.Email,
                                 CompanyName = ct.CompanyName
                             };
                return result.ToList();
            }
        }
    }
}
