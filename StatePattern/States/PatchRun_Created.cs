using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StatePattern.States
{
    public class PatchRun_Created : State
    {
        // to take values from the old state
        public PatchRun_Created(State oldState)
            : this(oldState.jsonString, oldState.stateLoader)
        {
        }

        public PatchRun_Created(string jsonString, StateLoader stateLoader)
        {
            this.jsonString = jsonString;
            this.stateLoader = stateLoader;
        }

        public override void PerformOperations()
        {
            // Schedule Patch Run 
            this.UpdateState();
        }

        private void UpdateState()
        {
            // next state is Setup_Started
            this.stateLoader.CurrentState = new PatchRun_InProgress(this);
            // Persist state in the table
        }
    }
}
