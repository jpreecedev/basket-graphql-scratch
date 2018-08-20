using GraphQL.Types;

namespace BasketGraphQLAPI
{
    public class StarWarsQuery : ObjectGraphType<object>
    {
        public StarWarsQuery(StarWarsData data)
        {
            Name = "Query";

            Field<ListGraphType<HumanType>>(
                "humans",
                resolve: context => data.GetHumansAsync()
            );

            Field<HumanType>(
                "human",
                arguments: new QueryArguments(
                    new QueryArgument<StringGraphType> {Name = "id", Description = "id of the human"}
                ),
                resolve: context => data.GetHumanByIdAsync(context.GetArgument<string>("id"))
            );
        }
    }
}