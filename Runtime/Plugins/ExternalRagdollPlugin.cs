﻿// SPDX-License-Identifier: Apache-2.0
// © 2024-2025 Depra <n.melnikov@depra.org>

using UnityEngine;

namespace Depra.Ragdoll
{
	public abstract class ExternalRagdollPlugin : MonoBehaviour
	{
		[SerializeField] private RagdollPlugins _ragdoll;

		private void Awake()
		{
			_ragdoll.Enabled += OnRagdollEnabled;
			_ragdoll.Disabled += OnRagdollDisabled;
		}

		private void OnDestroy()
		{
			if (_ragdoll)
			{
				_ragdoll.Enabled -= OnRagdollEnabled;
				_ragdoll.Disabled -= OnRagdollDisabled;
			}
		}

		private void OnRagdollEnabled()
		{
			if (isActiveAndEnabled)
			{
				OnEnabled();
			}
		}

		private void OnRagdollDisabled()
		{
			if (isActiveAndEnabled)
			{
				OnDisabled();
			}
		}

		protected abstract void OnEnabled();

		protected abstract void OnDisabled();
	}
}
