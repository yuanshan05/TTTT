﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPro.Factory
{
    public class SubOperator : Operator
    {
        public override double GetResult()
        {
            return FirstNumber - SecondNumber;
        }
    }
}