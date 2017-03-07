using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern
{
    using StatePattern.States;

    public class StateLoader
    {
        public State CurrentState { get; set; }

        public StateLoader()
        {
            // LOAD STATE
            // check db for the row for this test
            // Read the row to get the current state and json string. eg: Setup_Started.
            //{
            //    "VMID": "abcd",
            //    "WSID": "1234"
            //}
            this.CurrentState = new Assessment_InProgress("{VMID:abcd}", this);
        }

        public void TransitionState()
        {
            // Get Test StartTime from the table and calculate timespan since the test started, say its 4 hours
            var timeSpan = new TimeSpan(0, 4, 0,0);
 
            if (timeSpan < new TimeSpan(0, 7, 0, 0))
            {
                try
                {
                    this.CurrentState.PerformOperations();
                }
                catch (Exception)
                {
                    // MDS EVENT HERE TO REPORT FAILURE OF THE RUNNER

                    // Update json string with error message and pass it to the Cleanup State
                    string jsonString = "Error Message here";
                    this.CurrentState = new Cleanup_Started(jsonString, this);
                }

                if (this.CurrentState.GetType().Name == "Setup_Started")
                {
                    // MDS EVENT HERE TO REPORT SUCCESS OF THE RUNNER THROUGH ONE CYCLE
                }
            }
            else
            {
                // Runner Running for too long
                // MDS EVENT HERE TO REPORT FAILURE OF THE RUNNER
            }
        }
    }
}
