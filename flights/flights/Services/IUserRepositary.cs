using flights.Context;
using flights.Entity;
namespace flightSystem.Services
{
    public interface IUserRepositary
    {
        public List<AspNetUser> GetAll();
        public AspNetUser GetDetails(int id);
        public void Insert(AspNetUser user);
        public void UpdateUser(int id, AspNetUser user);
        public void DeleteUser(int id);
    }
}
