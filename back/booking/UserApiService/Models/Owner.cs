using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using UserApiService.Models.Enums;

namespace UserApiService.Models
{

    using UserApiService.Models.Enums;
    public class Owner : User
    {
        public new UserRole RoleName { get; set; } = UserRole.Owner;
        public List<OwnerOfferLink> OwnerOfferLinks { get; set; } = new();
    }



}
