using GraphQL.Types;

namespace BasketGraphQLAPI
{
    public class CharacterInterface : InterfaceGraphType<Human>
    {
        public CharacterInterface()
        {
            Name = "Character";

            Field(d => d.Id).Description("The id of the character.");
            Field(d => d.Name, true).Description("The name of the character.");

            Field<ListGraphType<CharacterInterface>>("friends");
        }
    }
}