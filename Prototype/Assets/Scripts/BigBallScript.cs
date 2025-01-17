﻿using UnityEngine;
using System.Collections;

public class BigBallScript : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		ReverseMeshofBigBall ();
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}


	void ReverseMeshofBigBall ()
	{
		/*
		2015.9.16
		Xiangyu Li

		Reverse the normal of mesh collider.
		*/
		MeshFilter filter = GetComponent(typeof (MeshFilter)) as MeshFilter;
		if (filter != null)
		{
			Mesh mesh = filter.mesh;
			
			Vector3[] normals = mesh.normals;
			for (int i=0;i<normals.Length;i++)
				normals[i] = -normals[i];
			mesh.normals = normals;
			
			for (int m=0;m<mesh.subMeshCount;m++)
			{
				int[] triangles = mesh.GetTriangles(m);
				for (int i=0;i<triangles.Length;i+=3)
				{
					int temp = triangles[i + 0];
					triangles[i + 0] = triangles[i + 1];
					triangles[i + 1] = temp;
				}
				mesh.SetTriangles(triangles, m);
			}
		}        
		this.GetComponent<MeshCollider>().sharedMesh = filter.mesh;

	}
}
