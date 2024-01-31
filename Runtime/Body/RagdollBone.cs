// SPDX-License-Identifier: Apache-2.0
// © 2024 Nikolay Melnikov <n.melnikov@depra.org>

using UnityEngine;
using static Depra.Ragdoll.Module;

namespace Depra.Ragdoll.Bones
{
	[DisallowMultipleComponent]
	[AddComponentMenu(menuName: MENU_PATH + nameof(RagdollBone), DEFAULT_ORDER)]
	public sealed class RagdollBone : MonoBehaviour
	{
		[SerializeField] private BoneType _boneType;
		[SerializeField] private Collider _collider;
		[SerializeField] private Rigidbody _rigidbody;

		public BoneType Type => _boneType;
		public Collider Collider => _collider;
		public Rigidbody Rigidbody => _rigidbody;
		public Vector3 Position => transform.position;

		private void OnValidate()
		{
			if (_collider == null)
			{
				_collider = GetComponent<Collider>();
			}

			if (_rigidbody == null)
			{
				_rigidbody = GetComponent<Rigidbody>();
			}
		}
	}
}