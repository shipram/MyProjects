using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern.States
{
    public class Cleanup_Started : State
    {
        public Cleanup_Started(State oldState)
            : this(oldState.jsonString, oldState.stateLoader)
        {
        }

        //to pass on to the next state
        public Cleanup_Started(string jsonString, StateLoader stateLoader)
        {
            this.jsonString = jsonString;
            this.stateLoader = stateLoader;
        }

        public override void PerformOperations()
        {
            // read RG Id from the json and delete all.
            this.UpdateState();
        }

        private void UpdateState()
        {
            // next state is Uninitialized
            this.stateLoader.CurrentState = new Setup_Started(this);
            // Persist the next state in the table along with the appropriate jsonstring
        }
    }
}
