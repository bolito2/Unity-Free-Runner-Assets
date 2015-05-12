using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    public float bulletSpeed;
    public string[] otherTags;
    public bool destroyAtGroundHit;

	void Update () {
        transform.Translate(1 * bulletSpeed, 0, 0);
	}

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.tag == "BulletDestroyer" || (other.transform.tag == "Ground" && destroyAtGroundHit))
            Destroy(gameObject);

        foreach(string tag in otherTags)
        {
            if (other.transform.tag == tag)
                Destroy(gameObject);
        }
    }
}
