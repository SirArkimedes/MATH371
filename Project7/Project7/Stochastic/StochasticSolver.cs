using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// All the names in this solver are directly tied to the problem 19.36,
// but can be applied to the general solution.

namespace Project7.Stochastic
{
    class Contracter
    {
        public double probabilty = 0.0;

        public bool selected = false;
    }

    class Component
    {
        public List<Contracter> contracters = new List<Contracter>();

        public Contracter getMaxNonSelectedContracter()
        {
            Contracter maxContracter = new Contracter();
            foreach (Contracter contracter in contracters)
                if (!contracter.selected && contracter.probabilty > maxContracter.probabilty)
                    maxContracter = contracter;

            return maxContracter;
        }
    }

    class StochasticSolver
    {
        List<Component> components = new List<Component>();

        public void solve()
        {

        }
    }
}
