using UnityEngine;
// ReSharper disable LocalVariableHidesMember

namespace Depra.Ragdoll
{
	[AddComponentMenu(Module.MENU_PATH + "Ragdoll Colliders", Module.DEFAULT_ORDER)]
	internal sealed class RagdollColliders : ExternalRagdollPlugin
	{
		[SerializeField] private Collider[] _colliders;

		protected override void OnEnabled()
		{
			foreach (var collider in _colliders)
			{
				collider.enabled = false;
			}
		}

		protected override void OnDisabled()
		{
			foreach (var collider in _colliders)
			{
				collider.enabled = true;
			}
		}
	}
}