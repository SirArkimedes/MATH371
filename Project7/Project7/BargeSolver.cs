using System;
using System.Collections.Generic;

namespace Project7
{
    // Define the Item class. Use this later to keep track of the data.
    class Item
    {
        public string name;
        public int weight;
        public double cost;

        public Item(string name, int weight, double cost)
        {
            this.name = name;
            this.weight = weight;
            this.cost = cost;
        }
    }

    class BargeSolver
    {
        public int weightLimit = 0;
        public List<Item> items = new List<Item>();

        private double[,] costMatrix;

        public void Solve()
        {
            // Create f sub j matrix.
            costMatrix = new double[items.Count, weightLimit + 1];
            for (int i = 0; i < items.Count; i++)
            {
                Item item = items[i];
                for (int j = 0; j <= weightLimit; j++)
                {
                    if (item.weight <= j + 1 && item.weight != 0)
                    {
                        int numberOfItems = (j) / item.weight;
                        costMatrix[i, j] = numberOfItems * item.cost;
                    }
                }
            }



            double max = double.MinValue;
            for (int j = 0; j < items.Count; j++)
            {
                for (int u = 0; u <= weightLimit; u++)
                {
                    double value = maxForJandU(j + 1, u + 1);
                    if (value > max)
                        max = value;
                }
            }

            double d = max;
        }

        private double maxForJandU(int j, int u)
        {
            if (j == items.Count)
            {
                return costMatrix[j - 1, u - 1];
            }
            else
            {
                double max = double.MinValue;
                for (int x = 0; x < u; x++)
                {
                    double f = costMatrix[j - 1, x];
                    double value = f + maxForJandU(j + 1, u - x);
                    if (value > max)
                        max = value;
                }

                return max;
            }
        }
    }
}
