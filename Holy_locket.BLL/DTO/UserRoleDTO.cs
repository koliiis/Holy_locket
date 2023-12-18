using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Holy_locket.BLL.DTO
{
    public class UserRoleDTO
    {
        public UserRoleDTO(int Id, int Role)
        {
            this.Id = Id;
            this.Role = Role;
        }
        public int Id { get; set; }
        public int Role { get; set; }
    }
}
