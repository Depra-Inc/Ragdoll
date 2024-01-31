using Depra.Stateful.Abstract;
using UnityEngine;
using static Depra.Ragdoll.Module;

namespace Depra.Ragdoll.Body.States
{
	[DisallowMultipleComponent]
	[AddComponentMenu(menuName: MENU_PATH + nameof(EmptyRagdollState), DEFAULT_ORDER)]
	public sealed class EmptyRagdollState : RagdollState, IState
	{
		[ContextMenu(nameof(Enter))]
		public override void Enter() { }

		[ContextMenu(nameof(Enter))]
		public override void Exit() { }
	}
}