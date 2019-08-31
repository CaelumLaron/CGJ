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

public class GameEdge : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D collision)
	{
		Character character = collision.GetComponent<Character>();

		if (character != null)
		{
			character.Die();
		}
	}

#if UNITY_EDITOR
	//protected override void OnDrawGizmos()
	//{
	//}
#endif
}

#if UNITY_EDITOR
[CustomEditor(typeof(GameEdge))]
[CanEditMultipleObjects]
public class GameEdgeEditor : Editor
{
#pragma warning disable 0219, 414
	private GameEdge _sGameEdge;
#pragma warning restore 0219, 414

	private void OnEnable()
	{
		this._sGameEdge = this.target as GameEdge;
	}

	public override void OnInspectorGUI()
	{
		this.DrawDefaultInspector();
	}
}
#endif