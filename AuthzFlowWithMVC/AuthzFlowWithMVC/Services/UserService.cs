using AuthzFlowWithMVC.Models;

namespace AuthzFlowWithMVC.Services
{
    public class UserService
    {
        private List<User> _users;
        public UserService()
        {
            _users = new List<User>()
            {
                new(){ Id=1, UserName ="turkay", Email="a@bc.com", Password="123", Role="Admin" },
                new(){ Id=1, UserName ="sevda", Email="a@bc.com", Password="123", Role="Editor" },
                new(){ Id=1, UserName ="mustafa", Email="a@bc.com", Password="123", Role="Client" }


            };
        }
        public User ValidateUser(string username, string password)
        {
            return _users.SingleOrDefault(u => u.UserName == username && u.Password == password);
        }
    }
}
