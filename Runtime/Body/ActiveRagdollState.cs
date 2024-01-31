using Depra.Ragdoll.Armature;
using Depra.Stateful.Abstract;

namespace Depra.Ragdoll.Body
{
	public sealed class ActiveRagdollState : IState
	{
		private readonly RagdollArmature _armature;

		public ActiveRagdollState(RagdollArmature armature) => _armature = armature;

		void IState.Enter()
		{
			foreach (var bone in _armature.Bones)
			{
				bone.Rigidbody.useGravity = true;
				bone.Rigidbody.isKinematic = false;
			}
		}

		void IState.Exit()
		{
			foreach (var bone in _armature.Bones)
			{
				bone.Rigidbody.useGravity = false;
				bone.Rigidbody.isKinematic = true;
			}
		}
	}
}