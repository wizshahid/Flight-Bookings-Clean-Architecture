using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightBookings.Domain.Entities
{
    public class Airport
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = null!;

        public string City { get; set; } = null!;
    }
}
