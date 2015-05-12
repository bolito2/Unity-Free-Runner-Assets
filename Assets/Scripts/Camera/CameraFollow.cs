using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

    public Transform Character;
    public float separation;

	void FixedUpdate()
    {
        transform.position = new Vector3(Character.position.x + separation, transform.position.y, transform.position.z);
    }
}
