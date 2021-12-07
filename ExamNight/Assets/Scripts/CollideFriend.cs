using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideFriend : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject falling;
    // Start is called before the first frame update
    void Start() {
        Physics2D.IgnoreLayerCollision(7, 8);
    }
    
    private void OnCollisionEnter2D(Collision2D collision){
      if (collision.gameObject.tag.Equals("Player")){
        Vector3 contactPoint = collision.contacts[0].point;
        Vector3 center = this.GetComponent<Collider2D>().bounds.center;
        bool stepon = (contactPoint.y - center.y > this.GetComponent<BoxCollider2D>().size.y / 2 * 0.9);
        Debug.Log(contactPoint.y - center.y );
        Debug.Log(this.GetComponent<BoxCollider2D>().size.y / 2);
        if (stepon){
          Debug.Log("Destroy friend");
          Destroy(this.gameObject);
        }
        else{
          Debug.Log("reseting player");
          Vector3 new_pos = falling.transform.position;
          new_pos.z = 0;
          collision.gameObject.transform.position = new_pos;
        }
      }
    }
}
