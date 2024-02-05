// SPDX-License-Identifier: Apache-2.0
// © 2024 Nikolay Melnikov <n.melnikov@depra.org>

using UnityEngine;

namespace Depra.Ragdoll.Body
{
	public abstract class RagdollBody : MonoBehaviour
	{
		public abstract void Enable();

		public abstract void Disable();
	}
}