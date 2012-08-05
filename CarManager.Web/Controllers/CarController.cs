using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using CarManager.Data;

namespace CarManager.Web.Controllers
{
	public class CarController : ApiController
	{

		private static readonly ICarRepository _carRepository = new InMemoryCarRepository();

		public IEnumerable<Car> Get()
		{
			return _carRepository.GetAll();
		}

		public Car Get(int id)
		{
			return _carRepository.Get(id);
		}

		public void Put(Car car)
		{
			_carRepository.Update(car);
		}

		public void Delete(int id)
		{
			_carRepository.Delete(id);
		}

		public HttpResponseMessage Post(Car car)
		{
			_carRepository.Add(car);
			var httpResponseMessage = new HttpResponseMessage(HttpStatusCode.Created);
			httpResponseMessage.Headers.Location = new Uri(Request.RequestUri.ToString()
				+ "/" + car.Id.ToString());
			return httpResponseMessage;			
		}



	}
}