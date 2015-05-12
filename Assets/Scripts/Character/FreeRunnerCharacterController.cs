using UnityEngine;
using System.Collections;
using System;


public enum Platform
{
    Android,
    PC
}




[Serializable]
public class FreeRunnerCharacterController : MonoBehaviour {


    void Start()
    {
       if (!RunAtStart && !RunAtClickOrKey)
            RunAtStart = true;

        if (RunAtStart)
        {
            StartGame();
        }

    }

    public bool RunAtStart;
    public bool RunAtClickOrKey;
    public FireScript fireScript;

    public Controls controls;
    public Physics physics;

    [Serializable]
    public class Physics
    {
            public Transform GroundChecker;
            public bool isGrounded;
            public LayerMask groundMask = -1;
            public float JumpHeight = 10, Speed = 15;      
    }


    [Serializable]
    public class Controls
    {

        public Platform platform;

        public PC pc;
 
        [Serializable]
        public class PC
        {
            public bool mouseToJump;
            public KeyCode keyToJump;
            public bool mouseToShoot;
            public KeyCode keyToShoot;
            [HideInInspector]public Vector3 mousePos;
        }
    }

    private Rigidbody2D rigidbody;

    public void StartGame()
    {
        rigidbody.velocity = new Vector2(physics.Speed, rigidbody.velocity.y);
    }

    void Awake()
    {
        if(RunAtClickOrKey && RunAtStart)
        {
            Debug.LogError("Free Runner Character : Run At Click Or Key and Run At Start are both checked. Uncheck one of them");
        }

        if (GetComponent<Rigidbody2D>() != null)
        {
            rigidbody = GetComponent<Rigidbody2D>();
        }
        else Debug.LogError(string.Format("Free Runner Character : RigidBody2D is not attached to {0}. Add one RigidBody2D to {0}", gameObject.ToString()));

        if (physics.JumpHeight == 0)
            physics.JumpHeight = 10;

        if (physics.Speed == 0)
            physics.Speed = 15;
    }

    void Update()
    {
        //Detect Jump
        {
            if (controls.pc.keyToJump != KeyCode.None)
            {
                if (Input.GetKey(controls.pc.keyToJump) && physics.isGrounded)
                {
                    Jump();
                }
            }
            else
            {
                if (controls.pc.mouseToJump)
                {
                    if (Input.GetMouseButton(0))
                    {
                        Jump();
                    }
                }
                else if (Input.GetKey(KeyCode.Space) && physics.isGrounded)
                {
                    Jump();
                }
            }
        }

        //Detect Shoot
        if(fireScript == null)
        {
            if (GetComponent<FireScript>())
            {
                fireScript = GetComponent<FireScript>();
            }
        }
        if (fireScript != null)
        {
            if (controls.pc.keyToShoot != KeyCode.None)
            {
                if (Input.GetKey(controls.pc.keyToShoot) && physics.isGrounded)
                {
                    fireScript.Shoot();
                }
            }
            else
            {
                if (controls.pc.mouseToShoot)
                {
                    if (Input.GetMouseButton(0))
                    {
                        fireScript.Shoot();
                    }
                }
                else if (Input.GetKey(KeyCode.Space) && physics.isGrounded)
                {
                    fireScript.Shoot();
                }
            }
        }
    }

    void FixedUpdate()
    {
        if (controls.platform == Platform.PC)
        {
            //Detect the mouse
            controls.pc.mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            //Detect the jump
            if (physics.GroundChecker != null)
            {
                if (physics.GroundChecker.gameObject.GetComponent<CircleCollider2D>() != null)
                {
                    if (physics.groundMask != -1)
                        physics.isGrounded = Physics2D.OverlapCircle(physics.GroundChecker.position, physics.GroundChecker.GetComponent<CircleCollider2D>().radius, physics.groundMask);
                    else physics.isGrounded = Physics2D.OverlapCircle(physics.GroundChecker.position, physics.GroundChecker.GetComponent<CircleCollider2D>().radius);

                }
                else physics.isGrounded = true;
            }
            else physics.isGrounded = true;
        }

    }

    void Jump()
    {
        rigidbody.velocity = new Vector2(rigidbody.velocity.x, physics.JumpHeight);
    }

}
