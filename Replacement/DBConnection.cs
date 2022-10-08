using Replacement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Replacement
{
    public class DBConnection
    {
        private static ApplicationContext context;

        public static ApplicationContext getConnection()
        {
            if (context == null)
            {
                context = new ApplicationContext();
                DataSourse.Subjects = new(context.Subjects.ToList());
                DataSourse.Users = new(context.Users.ToList());
            }
                
            return context;
        }
    }
}
