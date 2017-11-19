using System.Collections.Generic;

namespace Project7
{
    // Define the Item class. Use this later to keep track of the data.
    class Item
    {
        public string name;
        public int weight;
        public double profi;

        public Item(string name, int weight, double profit)
        {
            this.name = name;
            this.weight = weight;
            this.profi = profit;
        }
    }

    // Define a class that keeps a state of items that can be tested for maximum profit.
    class ProfitTestState
    {

        public double overallProfit;

        // Keep track of the items, so we can report it later.
        public List<Item> subItems = new List<Item>();
    }

    // Solver class. Does all the necessary logic for the algorithm.
    class BargeSolver
    {
        public int weightLimit = 0;
        public List<Item> items = new List<Item>();

        private ProfitTestState[,] profitMatrix;

        public ProfitTestState solve()
        {
            // Create f sub j matrix.
            profitMatrix = new ProfitTestState[items.Count, weightLimit + 1];
            for (int i = 0; i < items.Count; i++)
            {
                Item item = items[i];
                for (int j = 0; j <= weightLimit; j++)
                {
                    if (item.weight <= j + 1 && item.weight != 0)
                    {
                        int numberOfItems = j / item.weight;

                        ProfitTestState pItem = new ProfitTestState();
                        pItem.overallProfit = numberOfItems * item.profi;
                        for (int p = 0; p < numberOfItems; p++)
                            pItem.subItems.Add(item);
                        profitMatrix[i, j] = pItem;
                    }
                    else
                    {
                        // Assign an empty one so we don't have null collisions.
                        profitMatrix[i, j] = new ProfitTestState();
                    }
                }
            }

            // Find max of d and m matrix.
            double max = double.MinValue;
            ProfitTestState maxProfitTestState = new ProfitTestState();
            for (int j = 0; j < items.Count; j++)
            {
                for (int u = 0; u <= weightLimit; u++)
                {
                    ProfitTestState state = maxForJandU(j + 1, u + 1);
                    if (state.overallProfit > max)
                    {
                        max = state.overallProfit;
                        maxProfitTestState = state;
                    }
                }
            }

            return maxProfitTestState;
        }

        private ProfitTestState maxForJandU(int j, int u)
        {
            if (j == items.Count)
                return profitMatrix[j - 1, u - 1];
            else
            {
                ProfitTestState maxState = new ProfitTestState();
                for (int x = 0; x < u; x++)
                {
                    // Recursive forumla.
                    ProfitTestState currentState = profitMatrix[j - 1, x];
                    ProfitTestState currentMaxState = maxForJandU(j + 1, u - x);
                    if (currentMaxState.overallProfit == 0)
                        currentMaxState.subItems = new List<Item>();

                    double value = currentState.overallProfit + currentMaxState.overallProfit;
                    if (value > maxState.overallProfit)
                    {
                        maxState = new ProfitTestState();
                        maxState.overallProfit = value;

                        maxState.subItems = new List<Item>(currentMaxState.subItems);
                        foreach (Item item in currentState.subItems)
                            maxState.subItems.Add(item);
                    }
                }

                return maxState;
            }
        }
    }
}
