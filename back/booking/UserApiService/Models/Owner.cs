using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using UserApiService.Models.Enums;

namespace UserApiService.Models
{
    public class Owner : User
    {
        public override UserRole RoleName { get; set; } = UserRole.Owner;
        public List<OwnerOfferLink> OwnerOfferLinks { get; set; } = new();
    }
}
