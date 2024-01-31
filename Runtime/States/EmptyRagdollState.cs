using Depra.Stateful.Abstract;
using UnityEngine;

namespace Depra.Ragdoll.Body.States
{
	[DisallowMultipleComponent]
	public sealed class EmptyRagdollState : RagdollState, IState
	{
		public override void Initialize(RagdollBody body) { }

		[ContextMenu(nameof(Enter))]
		public override void Enter() { }

		[ContextMenu(nameof(Enter))]
		public override void Exit() { }
	}
}