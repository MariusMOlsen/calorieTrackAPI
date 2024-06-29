using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalorieTrack.Domain.Model;

namespace CalorieTrack.Application.Common.Authorization
{

    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class AuthorizeAttribute : Attribute
    {
        public ProfileType Roles { get; set; }
    }
}
