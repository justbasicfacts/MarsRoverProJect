using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverProject.Exceptions
{
    public class CannotExceedBordersException : Exception
    {
        public override string Message => "Cannot exceed landing zone borders";
    }
}
