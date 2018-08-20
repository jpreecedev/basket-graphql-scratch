using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL;

namespace BasketGraphQLAPI
{
    public class StarWarsData
    {
        private readonly List<Human> _humans = new List<Human>();

        public StarWarsData()
        {
            _humans.Add(new Human
            {
                Id = "1",
                Name = "Luke",
                Friends = new[] {"2"}
            });
            _humans.Add(new Human
            {
                Id = "2",
                Name = "Vader"
            });
        }

        public IEnumerable<Human> GetFriends(Human character)
        {
            if (character == null)
                return null;

            var friends = new List<Human>();
            var lookup = character.Friends;
            if (lookup != null)
                _humans.Where(h => lookup.Contains(h.Id)).Apply(friends.Add);
            return friends;
        }

        public Task<List<Human>> GetHumansAsync()
        {
            return Task.FromResult(_humans.ToList());
        }

        public Task<Human> GetHumanByIdAsync(string id)
        {
            return Task.FromResult(_humans.FirstOrDefault(h => h.Id == id));
        }
    }
}