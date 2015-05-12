using UnityEngine;
using System.Collections;
[ExecuteInEditMode]
public class Angle : MonoBehaviour {
    
    [Range(-10, 0)] [SerializeField] private float minAngle;
    [Range(0, 10)] [SerializeField] private float maxAngle;

    public float MinAngle
        {
        get
        {
            return minAngle / 10;
        }
        set
        {
            minAngle = value * 10;
        }
        }

    public float MaxAngle
    {
        get
        {
            return maxAngle / 10;
        }
        set
        {
            maxAngle = value * 10;
        }
    }

    public bool ShowAngle;
    public Transform Arm;

    public RectTransform Min, Max;

    void Update()
    {
        if (ShowAngle)
        {
            Min.localScale = new Vector3(4, 1, 1);
            Min.position = Camera.main.WorldToScreenPoint(Arm.position);
            Min.rotation = new Quaternion(0, 0, MinAngle, transform.rotation.w);

            Max.localScale = new Vector3(4, 1, 1);
            Max.position = Camera.main.WorldToScreenPoint(Arm.position);
            Max.rotation = new Quaternion(0, 0, MaxAngle, transform.rotation.w);
        }
        else
        {
            Max.localScale = Vector3.zero;
            Min.localScale = Vector3.zero;
        }
    }
	
}
