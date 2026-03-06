using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using UserContracts.Enums;


namespace UserApiService.Models
{
    public class Owner : Client
    {
        public override UserRole RoleName { get; set; } = UserRole.Owner;
        public List<OwnerOfferLink> OwnerOfferLinks { get; set; } = new();
    }
}
