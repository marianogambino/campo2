using System;
using System.Collections.Generic;
using System.Text;

namespace Confluence.DAL
{
    public class DuplicateEntityException : Exception
    {
        private String exceptionCause;

        public String ExceptionCause
        {
            get { return exceptionCause; }
            set { exceptionCause = value; }
        }
	
        public DuplicateEntityException(String message)
        {
            ExceptionCause = "Entity Already Exists #ID = " + message;
        }
    }
}
