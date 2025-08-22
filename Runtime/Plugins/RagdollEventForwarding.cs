// SPDX-License-Identifier: Apache-2.0
// © 2024-2025 Depra <n.melnikov@depra.org>

using UnityEngine;
using UnityEngine.Events;
using static Depra.Ragdoll.Module;

namespace Depra.Ragdoll.Parts
{
	[AddComponentMenu(MENU_PATH + "Ragdoll Event Forwarding", DEFAULT_ORDER)]
	internal sealed class RagdollEventForwarding : MonoBehaviour
	{
		[SerializeField] private RagdollPlugins _ragdoll;
		[SerializeField] private UnityEvent _onEnabled;
		[SerializeField] private UnityEvent _onDisabled;

		private void OnEnable()
		{
			_ragdoll.Enabled += _onEnabled.Invoke;
			_ragdoll.Disabled += _onDisabled.Invoke;
		}

		private void OnDisable()
		{
			_ragdoll.Enabled -= _onEnabled.Invoke;
			_ragdoll.Disabled -= _onDisabled.Invoke;
		}
	}
}