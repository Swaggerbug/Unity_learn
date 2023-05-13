using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class testtank : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
		GameObject[] array_layer = new GameObject[10];

		for (int i = 0; i < 10; i++)
		{
			array_layer[i] = GameObject.CreatePrimitive(PrimitiveType.Cube);
			array_layer[i].transform.SetParent(this.transform);
			array_layer[i].name = $"Cube{i+1}";
			array_layer[i].transform.position = Vector3.down * i*0.5f;
			array_layer[i].transform.localScale = new Vector3(i, 0.5f, i);
		}

	}

}
