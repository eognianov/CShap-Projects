﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ErrorLogger.Models.Contracts
{
    public interface ILogger
    {
        IReadOnlyCollection<IAppender> Appenders { get; }
        void Log(IError error);
    }
}
