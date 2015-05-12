using UnityEngine;
using System.Collections;

public class ArmRotation : MonoBehaviour {

    public Angle angle;
    public FreeRunnerCharacterController character;
    private Quaternion wantedRot;

    void Update()
    {
        Vector3 relative = character.controls.pc.mousePos - transform.position;
        float angle = Mathf.Atan2(relative.x, -relative.y) * Mathf.Rad2Deg;
        wantedRot = Quaternion.Euler(0f, 0f, angle - 90);
        if (this.angle == null)
        {
            transform.rotation = wantedRot;
        }
        else
        {
            if (wantedRot.z > this.angle.MaxAngle)
            {
                transform.rotation = new Quaternion(0, 0, this.angle.MaxAngle, transform.rotation.w);
            }
            else
            {
                if (wantedRot.z < this.angle.MinAngle)
                {
                    transform.rotation = new Quaternion(0, 0, this.angle.MinAngle, transform.rotation.w);
                }
                else
                {
                    transform.rotation = wantedRot;
                }
            }
        }
    }
}
