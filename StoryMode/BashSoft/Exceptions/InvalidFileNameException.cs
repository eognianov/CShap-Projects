﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BashSoft.Exceptions
{
    class InvalidFileNameException:Exception
    {
        public const string ForbiddenSymbolsContainedInName =
            "The given name contains symbols that are not allowed to be used in names of files and folders.";
        public InvalidFileNameException():base(ForbiddenSymbolsContainedInName)
        {
            
        }

        public InvalidFileNameException(string message):base(message)
        {
            
        }
    }
}
