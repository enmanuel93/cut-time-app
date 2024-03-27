using CutTime.Domain.Models;

namespace CutTime.Web.Mocks
{
    public class DataLogicalMock
    {
        public List<User> ListaUsuario()
        {
            return new List<User>()
            {
                new User() {Name="jose", Email="jose@gmail.com", Password="123", Roles = new List<Role>{ 
                    new Role {Name = "Administrador"}
                } },
                new User() {Name="maria", Email="maria@gmail.com", Password="123", Roles = new List<Role>{
                    new Role {Name = "Barbero"}
                } },
                new User() {Name="pedro", Email="pedro@gmail.com", Password="123", Roles = new List<Role>{
                    new Role {Name = "Cliente"}
                } }
            };
        }

        public User ValidarUsuario(string _Email, string _Password)
        {
            return ListaUsuario().Where(x => x.Email == _Email && x.Password == _Password).FirstOrDefault();
        }
    }
}
