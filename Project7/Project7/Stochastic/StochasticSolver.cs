using System;
using System.Collections.Generic;
using System.Linq;

// All the names in this solver are directly tied to problem 19.36,
// but can be applied to the general solution.

namespace Project7
{
    // The class used to store the information about that particular row in the data grid.
    class Contractor
    {
        public string name = "";
        public List<double> probabilities = new List<double>();

        public bool selected = false;

        public Contractor() { }

        public Contractor(string name, List<double> probabilities)
        {
            this.name = name;
            this.probabilities = probabilities;
        }
    }

    class StochasticSolver
    {
        public List<Contractor> contractors = new List<Contractor>();

        public List<int> solve()
        {
            double max = double.MinValue;
            List<int> maxIndexList = new List<int>();
            foreach (Contractor contractor in contractors)
            {
                double currentTotal = contractor.probabilities[0];
                List<int> currentIndexList = new List<int> { contractors.IndexOf(contractor) };
                contractor.selected = true;

                for (int j = 1; j < contractor.probabilities.Count; j++)
                {
                    Tuple<int, double> result = getMaxNonSelectedProbability(j);
                    currentTotal += result.Item2;
                    currentIndexList.Add(result.Item1);
                }

                if (currentTotal > max)
                {
                    max = currentTotal;
                    maxIndexList = currentIndexList;
                }

                clearSelectedContracters();
            }

            return maxIndexList;
        }

        // Returns index of selected probability and the probability.
        private Tuple<int, double> getMaxNonSelectedProbability(int index)
        {
            double max = double.MinValue;
            Contractor maxContracter = new Contractor();

            // Filter out all currently selected contractors.
            List<Contractor> nonSelectedContractors = contractors.Where(contractor => !contractor.selected).ToList();
            for (int i = 0; i < nonSelectedContractors.Count; i++)
                if (nonSelectedContractors[i].probabilities[index] > max)
                {
                    max = nonSelectedContractors[i].probabilities[index];
                    maxContracter = nonSelectedContractors[i];
                }

            maxContracter.selected = true;
            return new Tuple<int, double>(contractors.IndexOf(maxContracter), max);
        }

        private void clearSelectedContracters()
        {
            foreach (Contractor contracter in contractors)
                contracter.selected = false;
        }
    }
}
