using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfferContracts
{
    public class UpdateImageOfferResponse
    {
        public int OfferId { get; set; }
        public int ImageId { get; set; }
        public bool Success { get; set; }
        public string? FileName {get; set; }
    }
}
