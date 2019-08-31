/* Created by Luna.Ticode */

using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.InputSystem;

#if UNITY_EDITOR
using UnityEditor;
#endif

using TMPro;

public class Checkpoint : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D collision)
	{
		Character character = collision.GetComponent<Character>();

		if (character != null)
		{
			character.Checkpoint = this;
		}
	}

#if UNITY_EDITOR
	//protected override void OnDrawGizmos()
	//{
	//}
#endif
}

#if UNITY_EDITOR
[CustomEditor(typeof(Checkpoint))]
[CanEditMultipleObjects]
public class CheckpointEditor : Editor
{
#pragma warning disable 0219, 414
	private Checkpoint _sCheckpoint;
#pragma warning restore 0219, 414

	private void OnEnable()
	{
		this._sCheckpoint = this.target as Checkpoint;
	}

	public override void OnInspectorGUI()
	{
		this.DrawDefaultInspector();
	}
}
#endif