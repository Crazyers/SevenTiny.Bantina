﻿using SevenTiny.Bantina.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Test.SevenTiny.Bantina.Model
{
    public class Student2
    {
        [Mapper(TargetName = "SchoolName")]
        public string Name { get; set; }
    }
}
