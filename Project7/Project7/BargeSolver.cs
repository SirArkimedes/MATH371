using System;
using System.Collections.Generic;

namespace Project7
{

    // Define the Item class. Use this later to keep track of the data.
    class Item
    {
        string name;
        double weight;
        double cost;

        public Item(string name, double weight, double cost)
        {
            this.name = name;
            this.weight = weight;
            this.cost = cost;
        }
    }

    class BargeSolver
    {
        public double weightLimit = 0.0;
        public List<Item> items = new List<Item>();
    }
}
