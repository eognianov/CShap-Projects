﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BashSoft.Contracts
{
    public interface IOrderTaker
    {
        void OrderAndTake(string courseName, string comparison, int? studentsToTake = null);
    }
}
