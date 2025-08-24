// SPDX-License-Identifier: Apache-2.0
// © 2024-2025 Depra <n.melnikov@depra.org>

using Depra.Ragdoll.Plugins;
using UnityEngine;
using static Depra.Ragdoll.Module;

namespace DefaultNamespace
{
	[AddComponentMenu(MENU_PATH + "Ragdoll Behaviours", DEFAULT_ORDER)]
	internal sealed class RagdollBehaviours : ExternalRagdollPlugin
	{
		[SerializeField] private Behaviour[] _behaviours;

		protected override void OnEnabled()
		{
			foreach (var ik in _behaviours)
			{
				ik.enabled = false;
			}
		}

		protected override void OnDisabled()
		{
			foreach (var ik in _behaviours)
			{
				ik.enabled = true;
			}
		}
	}
}