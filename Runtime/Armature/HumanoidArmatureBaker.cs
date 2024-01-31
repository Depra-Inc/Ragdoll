using System.Collections.Generic;
using System.Linq;
using Depra.Ragdoll.Bones;
using UnityEngine;

namespace Depra.Ragdoll.Armature
{
	[DisallowMultipleComponent]
	public sealed class HumanoidArmatureBaker : RagdollArmatureBaker
	{
		[SerializeField] private RagdollBone _hips;
		[SerializeField] private RagdollBone[] _head;
		[SerializeField] private RagdollBone[] _bodies;
		[SerializeField] private RagdollBone[] _hands;
		[SerializeField] private RagdollBone[] _legs;

		public override RagdollArmature Bake()
		{
			var allBones = new List<RagdollBone>();
			allBones.AddRange(_head.ToList());
			allBones.AddRange(_hands.ToList());
			allBones.AddRange(_bodies.ToList());
			allBones.AddRange(_legs.ToList());

			return new RagdollArmature(allBones);
		}

		public void Analyze() { }
	}
}