using UnityEngine;
using System.Collections;

public class GroundGenerator : MonoBehaviour {

    public GameObject GroundPrefab;
    public string GroundTag;

    private SpriteRenderer insRend, otherRend;

	void OnTriggerExit2D(Collider2D other)
    {
        if ((other.transform.tag == "Ground" || other.transform.tag ==  GroundTag) && transform.tag != "GroundDestroyer")
        {
            GameObject instantiatedGround = Instantiate(GroundPrefab, transform.position, Quaternion.identity) as GameObject;

            insRend = instantiatedGround.GetComponent<SpriteRenderer>();
            otherRend = other.gameObject.GetComponent<SpriteRenderer>();

            instantiatedGround.transform.position = new Vector2(otherRend.bounds.max.x + insRend.bounds.extents.x, transform.position.y);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if ((other.transform.tag == "Ground" || other.transform.tag == GroundTag) && transform.tag == "GroundDestroyer")
        {
            Destroy(other.gameObject);
        }
    }
}
