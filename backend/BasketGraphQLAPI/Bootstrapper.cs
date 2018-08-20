using GraphQL;
using GraphQL.Http;
using GraphQL.Types;
using IDependencyResolver = System.Web.Http.Dependencies.IDependencyResolver;

namespace BasketGraphQLAPI
{
    public class Bootstrapper
    {
        public IDependencyResolver Resolver()
        {
            var container = BuildContainer();
            var resolver = new SimpleContainerDependencyResolver(container);
            return resolver;
        }

        private static ISimpleContainer BuildContainer()
        {
            var container = new SimpleContainer();
            container.Singleton<IDocumentExecuter>(new DocumentExecuter());
            container.Singleton<IDocumentWriter>(new DocumentWriter(true));

            container.Singleton(new StarWarsData());
            container.Register<StarWarsQuery>();
            container.Register<HumanType>();
            container.Register<CharacterInterface>();
            container.Singleton<ISchema>(new StarWarsSchema(new FuncDependencyResolver(type => container.Get(type))));

            return container;
        }
    }
}