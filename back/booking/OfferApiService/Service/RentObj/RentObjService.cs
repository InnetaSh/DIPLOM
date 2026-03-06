using Globals.Sevices;
using Microsoft.EntityFrameworkCore;
using OfferApiService.Models;
using OfferApiService.Models.RentObjModel;


namespace OfferApiService.Services.Interfaces.RentObj
{
    public class RentObjService : TableServiceBaseNew<RentObject, OfferContext>, IRentObjService
    {
        public RentObjService(OfferContext context, ILogger<RentObjService> logger) : base(context, logger)
        {
        }


        public async Task<int> AddRentObjWithParamValuesAsync(RentObject rentObj)
        {
            _logger.LogInformation("Creating RentObject with parameter values");

            if (rentObj == null)
            {
                _logger.LogWarning("RentObject is null");
                throw new ArgumentNullException(nameof(rentObj));
            }

            if (rentObj.ParamValues != null)
            {
                _logger.LogInformation("Processing {Count} parameter values", rentObj.ParamValues.Count);

                foreach (var param in rentObj.ParamValues)
                {
                    param.ValueString ??= "";
                }
            }


            var res = _context.RentObjects.Add(rentObj);

            await _context.SaveChangesAsync();

            _logger.LogInformation(
                "RentObject created successfully with id {RentObjId}",
                res.Entity.id);

            return res.Entity.id;
        }
    }
}
