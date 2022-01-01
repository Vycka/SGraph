using System.Collections.Generic;

namespace SGraph.Core.Simulation
{
    public class InteractionsHandler
    {
        private readonly List<IInteraction> _interactions;

        public InteractionsHandler()
        {
            _interactions = new List<IInteraction>();
        }

        public InteractionsHandler Add<T>(IForce<T> force, List<T> entities)
        {
            return Add(new Interaction<T>(force, entities));
        }

        public InteractionsHandler Add(IInteraction interaction)
        {
            _interactions.Add(interaction);

            return this;
        }

        public void Simulate(int frames = 1)
        {
            for (int frame = 0; frame < frames; frame++)
            {
                for (int interaction = 0; interaction < _interactions.Count; interaction++)
                {
                    _interactions[interaction].Apply();
                }
            }
        }
    }
}