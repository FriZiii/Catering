using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace catering.Application.Managements.AccountManagment.AccountDtos
{
    public class DeliveryAdressInputDto
    {
        public string Adress1 { get; set; } = default!;
        public string Adress2 { get; set; } = default!;
        public string PostalCode { get; set; } = default!;
        public string State { get; set; } = default!;
        public string Country { get; set; } = default!;
        public string PhoneNumber { get; set; } = default!;
    }
}
