﻿using UnityEngine;
using System.Collections;

#if UNITY_EDITOR
using UnityEditor;
#endif

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class ProceduralRope : MonoBehaviour {

	public int curveVerticesNumber = 50;
	public int heightVerticesNumber = 3;
	public float radius = 1f;
	public float cylinderHeight = 3f;

	// Use this for initialization
	void Start () {
		Generate();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Generate()
	{
		MeshBuilder meshBuilder = new MeshBuilder();

		meshBuilder = new CylinderGeneration()
		{
			curveVerticesNumber = curveVerticesNumber,
			heightVerticesNumber = heightVerticesNumber,
			radius = radius,
			meshFace = MeshFace.Both,
			cylinderHeight = cylinderHeight,
			cylinderOrigin = transform.position
		}
		.AddToMeshBuilder(meshBuilder);

		GetComponent<MeshFilter>().mesh = meshBuilder.CreateMesh();
	}

}

#if UNITY_EDITOR
[CustomEditor(typeof(ProceduralRope))]
public class ProceduralRopeEditor : Editor
{
	public override void OnInspectorGUI()
	{
		base.OnInspectorGUI();

		ProceduralRope proceduralRope = (ProceduralRope) target;

		if (target != null) {

			if (GUILayout.Button("Generate"))
			{
				proceduralRope.Generate();
			}
		}
	}
}
#endif

