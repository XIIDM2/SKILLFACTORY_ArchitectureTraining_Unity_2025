namespace CodeBase.Infrastructure.StateMachines
{
    public interface IExitableState : IState
    {
        public void Exit()
        {

        }
    }
}