using MAUIExamples.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUIExamples.Core.Services
{
    public class CarService
    {
        private List<Producer> Producers { get; set; }
        private List<Car> Cars { get; set; }

        public CarService()
        {
            Producers = new List<Producer>
            {
                new Producer { Id = 1, Name = "Toyota" },
                new Producer { Id = 2, Name = "Honda" },
                new Producer { Id = 3, Name = "Ford" }
            };

            Cars = new List<Car>
            {
                new Car { Id = 1, Name = "Toyota Corolla", ReleaseDate = new DateTime(2020, 5, 20), ProducerId = 1 },
                new Car { Id = 2, Name = "Honda Civic", ReleaseDate = new DateTime(2021, 3, 14), ProducerId = 2 },
                new Car { Id = 3, Name = "Ford Focus", ReleaseDate = new DateTime(2019, 11, 8), ProducerId = 3 },
            };
        }

        public List<Producer> GetProducers() => Producers;

        public List<Car> GetCars() => Cars;

        public void AddCar(Car car)
        {
            car.Id = Cars.Any() ? Cars.Max(c => c.Id) + 1 : 1;
            Cars.Add(car);
        }
    }
}
