using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StatePattern.States
{
    public class PatchRun_InProgress : State
    {
         // to take values from the old state
        public PatchRun_InProgress(State oldState)
            : this(oldState.jsonString, oldState.stateLoader)
        {
        }

        public PatchRun_InProgress(string jsonString, StateLoader stateLoader)
        {
            this.jsonString = jsonString;
            this.stateLoader = stateLoader;
        }

        public override void PerformOperations()
        {
            // Check if patch run completed, then Update State, else stay same
            this.UpdateState();
        }

        private void UpdateState()
        {
            // next state is ReAssessment_InProgress
            this.stateLoader.CurrentState = new ReAssessment_InProgress(this);
            // Persist state in the table
        }
    }
}
