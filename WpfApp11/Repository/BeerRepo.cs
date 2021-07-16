using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp11.Models;

namespace WpfApp11.Repository
{
    public class BeerRepo
    {
        public List<Beer> GetAll()
        {
            return new List<Beer>
            {
                new Beer
                {
                    Id=1,
                    Name="Baltika",
                    ImagePath = "Images/beer1.jpg",
                    Volume=0.6,
                    Price=5.4,
                    Stock = 5
                },
                new Beer
                {
                    Id=2,
                    Name="Coor Lights",
                    ImagePath = "Images/beer2.jpeg",
                    Volume=1,
                    Price=6.4,
                    Stock = 3
                },
                new Beer
                {
                    Id=3,
                    Name="Miller",
                    ImagePath = "Images/beer3.png",
                    Volume=1.6,
                    Price=9.1,
                    Stock = 6
                },
                new Beer
                {
                    Id=4,
                    Name="Singha",
                    ImagePath = "Images/beer4.jpg",
                    Volume=2.6,
                    Price=10.8,
                    Stock = 9
                },
            };
        }
    }
}
