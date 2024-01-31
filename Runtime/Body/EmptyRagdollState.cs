using Depra.Stateful.Abstract;

namespace Depra.Ragdoll.Body
{
	public readonly struct EmptyRagdollState : IState
	{
		void IState.Enter() { }

		void IState.Exit() { }
	}
}