﻿using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using GraphQL;
using GraphQL.Http;
using GraphQL.Instrumentation;
using GraphQL.Types;
using GraphQL.Validation.Complexity;

namespace BasketGraphQLAPI.Controllers
{
    public class GraphQLController : ApiController
    {
        private readonly IDocumentExecuter _executer;
        private readonly ISchema _schema;
        private readonly IDocumentWriter _writer;

        public GraphQLController(
            IDocumentExecuter executer,
            IDocumentWriter writer,
            ISchema schema)
        {
            _executer = executer;
            _writer = writer;
            _schema = schema;
        }

        [HttpPost]
        public async Task<HttpResponseMessage> PostAsync(HttpRequestMessage request, GraphQLQuery query)
        {
            var inputs = query.Variables.ToInputs();
            var queryToExecute = query.Query;

            var result = await _executer.ExecuteAsync(_ =>
            {
                _.Schema = _schema;
                _.Query = queryToExecute;
                _.OperationName = query.OperationName;
                _.Inputs = inputs;

                _.ComplexityConfiguration = new ComplexityConfiguration {MaxDepth = 15};
                _.FieldMiddleware.Use<InstrumentFieldsMiddleware>();
            }).ConfigureAwait(false);

            var httpResult = result.Errors?.Count > 0
                ? HttpStatusCode.BadRequest
                : HttpStatusCode.OK;

            var json = _writer.Write(result);

            var response = request.CreateResponse(httpResult);
            response.Content = new StringContent(json, Encoding.UTF8, "application/json");

            return response;
        }
    }
}