using Globals.Abstractions;
using Globals.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using StatisticApiService.Models;
using StatisticApiService.Models.Enum;
using StatisticApiService.Services;
using StatisticApiService.Services.Interface;
using StatisticApiService.View;

namespace StatisticApiService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EntityStatisticController 
        : EntityControllerBase<PopularEntity, PopularEntityResponse, PopularEntityRequest>
    {
        private IEntityStatsService _entityStatService;

    public EntityStatisticController(IEntityStatsService entityStatService,
        IRabbitMqService mqService,
        IConfiguration configuration)
        : base(entityStatService, mqService)
    {
            _entityStatService = entityStatService;
    }

        // ===================================================================
        //                  добавить событие статистики
        //====================================================================
        [HttpPost("event")]
        public async Task<IActionResult> AddEvent(
            EntityStatEventRequest entityStatEventRequest)
        {
            var model = EntityStatEventRequest.MapToModel(entityStatEventRequest);
            var success = await _entityStatService.AddEventAsync(model);
            if (success)
                return Ok();
            else
                return StatusCode(500, "Не удалось сохранить событие");
        }


        //// ===================================================================
        ////                  агрегировать статистику за день
        ////              POST api/stats/aggregate?date=2026-01-13
        ////====================================================================
        //[HttpPost("aggregate")]
        //public async Task<IActionResult> Aggregate(DateOnly date)
        //{
        //    await _entityStatService.AggregateDayAsync(date);
        //    return Ok();
        //}

        //===================================================================
        //                  получить популярные сущности
        //                      GET api/stats/popular
        //===================================================================
        [HttpGet("popular")]
        public async Task<IActionResult> GetPopular(int entityType,
             int limit,
             DateOnly? startDate = null,
             DateOnly? endDate = null)
        {
            var result = await _entityStatService.GetPopularEntitiesAsync(
                (Models.Enum.EntityType)entityType,
                limit, 
                startDate,
                endDate);
            return Ok(result);
        }

        // ===================================================================
        //                              Топ 10 за неделю
        //====================================================================
        [HttpGet("top-week")]
        public async Task<IActionResult> GetPopularTopWeek(
            int entityType,
            int limit = 10)
        {
            var today = DateOnly.FromDateTime(DateTime.UtcNow);
            var weekAgo = today.AddDays(-7);

            var result = await _entityStatService.GetPopularEntitiesAsync(
                (Models.Enum.EntityType)entityType,
                limit,
                weekAgo,
                today);

            return Ok(result);
        }
        // ===================================================================
        //                              Топ 10 за месяц
        //====================================================================
        [HttpGet("top-month")]
        public async Task<IActionResult> GetPopularTopMonth(
            int entityType,
             int limit = 10)
        {
            var startOfMonth = new DateOnly(DateTime.UtcNow.Year, DateTime.UtcNow.Month, 1);
            var today = DateOnly.FromDateTime(DateTime.UtcNow);

            var result = await _entityStatService.GetPopularEntitiesAsync(
                (Models.Enum.EntityType)entityType,
                limit,
                startOfMonth,
                today);
            return Ok(result);
        }
        // ===================================================================
        //                              Топ 10 за год
        //====================================================================
        [HttpGet("top-year")]
        public async Task<IActionResult> GetPopularTopYear(
            int entityType,
             int limit = 10)
        {

            var startOfYear = new DateOnly(DateTime.UtcNow.Year, 1, 1);
            var today = DateOnly.FromDateTime(DateTime.UtcNow);

            var result = await _entityStatService.GetPopularEntitiesAsync(
                (Models.Enum.EntityType)entityType,
                limit,
                startOfYear, 
                today);
            return Ok(result);
        }
    }
}
