namespace CodeBase.Infrastructure.StateMachines
{
    public interface ITickableState : IState
    {
        public void Tick()
        {

        }
    }
}