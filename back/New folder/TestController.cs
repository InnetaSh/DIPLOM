using Globals.Abstractions;
using Globals.Controllers;
using Globals.Models;
using Globals.Sevices;
using Microsoft.AspNetCore.Mvc;

namespace WebApiGetway.Controllers
{
    public class TestController : EntityControllerBase<TestModel, TestResponse, TestRequest>
    {
        public TestController(IServiceBase<TestModel> service, IRabbitMqService mqService)
            : base(service, mqService)
        {
        }

        [HttpPost("create-test")]
        public override Task<ActionResult<TestResponse>> Create([FromBody] TestRequest request) => base.Create(request);

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

    public class CreateRequest : IBaseRequest
    { }

    public class TestRequest : IBaseRequest
    {
        public string Data { get; set; }
    }

    public class TestResponse : IBaseResponse
    {
        public string Data { get; set; }
    }

    public class TestContext : ContextBase<TestModel>
    {

    }
    public class TestService : ServiceBase<TestModel, TestContext>
    {
    }

    public class SubTestService : TableServiceBase<SubTest, TestContext>, ITableTestService
    {
    }

    public interface ITableTestService : IServiceBase<SubTest>
    {
    }

    public class SubTest : EntityBase
    {
        public string Name { get; set; }
    }
}
