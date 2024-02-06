// SPDX-License-Identifier: Apache-2.0
// © 2024 Nikolay Melnikov <n.melnikov@depra.org>

using JetBrains.Annotations;
using UnityEngine;
using static Depra.Ragdoll.Module;

namespace Depra.Ragdoll.Bones
{
	[DisallowMultipleComponent]
	[AddComponentMenu(menuName: MENU_PATH + nameof(RagdollBone), DEFAULT_ORDER)]
	public sealed class RagdollBone : MonoBehaviour
	{
		[SerializeField] private Joint _joint;
		[SerializeField] private Collider _collider;
		[SerializeField] private Rigidbody _rigidbody;

		public Collider Collider => _collider;
		public Rigidbody Rigidbody => _rigidbody;
		[CanBeNull] public Joint Joint => _joint;

		private void OnValidate()
		{
			_joint ??= GetComponent<Joint>();
			_collider ??= GetComponent<Collider>();
			_rigidbody ??= GetComponent<Rigidbody>();
		}

		public void Enable()
		{
			if (_joint)
			{
				_joint.enableCollision = true;
			}

			_collider.isTrigger = false;
			_rigidbody.useGravity = true;
			_rigidbody.isKinematic = false;
			_rigidbody.detectCollisions = true;
			_rigidbody.velocity = Vector3.zero;
		}

		public void Disable()
		{
			if (_joint)
			{
				_joint.enableCollision = false;
			}

			_rigidbody.useGravity = false;
			_rigidbody.isKinematic = true;
			_rigidbody.detectCollisions = false;
		}
	}
}