﻿using System;
using System.Collections.Generic;
using System.Text;


public class Parent
{
    public Parent(string name, string birthday)
    {
        this.Name = name;
        this.Birthday = birthday;
    }

    public string Name { get; set; }
    public string Birthday { get; set; }
}
