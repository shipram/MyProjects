using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StatePattern.States
{
    class ReAssessment_InProgress : State
    { // to take values from the old state
        public ReAssessment_InProgress(State oldState)
            : this(oldState.jsonString, oldState.stateLoader)
        {
        }

        //to pass on to the next state
        public ReAssessment_InProgress(string jsonString, StateLoader stateLoader)
        {
            this.jsonString = jsonString;
            this.stateLoader = stateLoader;
        }

        public override void PerformOperations()
        {
           // Check if there are Update Run Progress records, then update state
            this.UpdateState();
        }

        private void UpdateState()
        {
            // next state is Setup_Started
            this.stateLoader.CurrentState = new Cleanup_Started(this);
            // Persist the next state in the table along with the appropriate jsonstring
        }
    }
}
