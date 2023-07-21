using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;
        public void Add(Color color)
        {
            if (color.ColorName.Length < 2)
            {
                Console.WriteLine("The Car Name must have minimum 2 character.");
            }
            else
            {
                _colorDal.Add(color);
            }
        }

        public void Delete(Color color)
        {
            _colorDal.Delete(color);
        }

        public List<Color> GetAll()
        {
           return  _colorDal.GetAll();
        }

        public Color GetById(int ColorId)
        {
            return _colorDal.Get(c => c.ColorId == ColorId);
        }

        public void Update(Color color)
        {
            if (color.ColorName.Length < 2)
            {
                Console.WriteLine("The Car Name must have minimum 2 character.");
            }
            else
            {
                _colorDal.Add(color);
            }
        }
    }
}
