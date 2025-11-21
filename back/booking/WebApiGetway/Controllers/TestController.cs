using Globals.Abstractions;
using Globals.Controllers;
using Globals.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApiGetway.Controllers
{
    public class TestController : BaseController<TestModel, TestResponse, TestRequest>
    {
        public TestController(IServiceBase<TestModel> service, IRabbitMqService mqService)
            : base(service, mqService)
        {
        }

        [Route("create")]
        public override Task<ActionResult<TestResponse>> Create([FromBody] TestRequest request)
        {
             return base.Create(request);
        }

        protected override TestModel MapToModel(TestRequest request)
        {
            return new TestModel
            {
                Name = request.Data
            };
        }
        protected override TestResponse MapToResponse(TestModel model)
        {
            return new TestResponse
            {
                Data = model.Name
            };
        }
    }

    public class TestModel : EntityBase
    {
        public string Name { get; set; }
    }

    public class CreateRequest: IBaseRequest
    { }

    public class TestRequest: IBaseRequest
    {
        public string Data { get; set; }
    }

    public class TestResponse: IBaseResponse
    {
        public string Data { get; set; }
    }
}
