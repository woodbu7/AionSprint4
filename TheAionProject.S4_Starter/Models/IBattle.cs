﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheAionProject
{
    interface IBattle
    {
        string AttackMessage { get; set; }

        string Attack();
    }
}
