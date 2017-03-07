namespace StatePattern
{
    public class Uninitialized : State
    {
        public Uninitialized(State state) : this(state.jsonString, state.stateLoader)
        {
        }

        public Uninitialized(string jsonString, StateLoader stateLoader)
        {
            this.stateLoader = stateLoader;
            this.jsonString = jsonString;
        }

        public override void PerformOperations()
        {
            // Perform 
            // Update Starttime in the table
            this.UpdateState();
        }

        private void UpdateState()
        {
            // next state is Setup_Started
            this.stateLoader.CurrentState = new Setup_Started(this);
            // Persist next state in the table
        }
    }
}
