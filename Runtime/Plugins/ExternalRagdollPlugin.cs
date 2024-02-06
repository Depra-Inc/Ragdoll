// SPDX-License-Identifier: Apache-2.0
// © 2024 Nikolay Melnikov <n.melnikov@depra.org>

using Depra.Ragdoll.Parts;
using UnityEngine;

namespace Depra.Ragdoll.Plugins
{
	public abstract class ExternalRagdollPlugin : MonoBehaviour
	{
		[SerializeField] private RagdollPlugins _ragdoll;

		private void OnEnable()
		{
			_ragdoll.Enabled += OnEnabled;
			_ragdoll.Disabled += OnDisabled;
		}

		private void OnDisable()
		{
			_ragdoll.Enabled -= OnEnabled;
			_ragdoll.Disabled -= OnDisabled;
		}

		protected abstract void OnEnabled();

		protected abstract void OnDisabled();
	}
}