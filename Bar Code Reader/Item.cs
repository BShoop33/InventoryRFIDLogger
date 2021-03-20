using System;
using System.Collections.Generic;
using System.Text;

namespace Bar_Code_Reader
{
    public class Item
    {
            public Item(string title, string description, string brand)
            {
            Title = title;
            Description = description;
            Brand = brand;

            }
            //Your Properties are auto-implemented.
            public string Title { get; set; }

            public string Description { get; set; }

            public string Brand { get; set; }
    }
}
