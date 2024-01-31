// SPDX-License-Identifier: Apache-2.0
// © 2024 Nikolay Melnikov <n.melnikov@depra.org>

using UnityEngine;

namespace Depra.Ragdoll.Armature
{
	public abstract class RagdollArmatureBaker : MonoBehaviour
	{
		/// <summary>
		/// Gathering all the bones for calculation.
		/// </summary>
		public abstract RagdollArmature Bake();
	}
}