using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarManager.Data
{
	public interface ICarRepository
	{
		void Add(Car car);
		void Update(Car car);
		Car Get(int id);
		IEnumerable<Car> GetAll();
		void Delete(int id);
	}
}
