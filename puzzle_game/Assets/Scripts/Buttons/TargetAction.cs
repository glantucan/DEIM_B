using UnityEngine;
using System.Collections;

public class TargetAction : MonoBehaviour, ITarget {

	[SerializeField] private Animation anim;
	[SerializeField] private AnimationClip showAnimation;
	[SerializeField] private AnimationClip hideAnimation;

	public void DoAction() {
		anim.clip = showAnimation;
		anim.Play();
	}

	public void UndoAction(){
		anim.clip = hideAnimation;
		anim.Play();
	}
}
