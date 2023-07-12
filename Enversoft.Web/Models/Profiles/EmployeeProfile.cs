using AutoMapper;
using Enversoft.Shared;

namespace Enversoft.Web.Models.Profiles
{
    public class EmployeeProfile:Profile
    {
        public EmployeeProfile() {
            CreateMap<EmployeeModel, Employee>();
            CreateMap<Employee, EmployeeModel>();
        }
    }
}
