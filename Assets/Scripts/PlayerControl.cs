using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float salto = 0.4f;
    private Vector3 posicionInicial;
    private Vector3 posicionAnterior;


    // Start is called before the first frame update
    void Start()
    {
        posicionInicial = transform.position;
        posicionAnterior = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown("up") || Input.GetKeyDown("down") || Input.GetKeyDown("right") || Input.GetKeyDown("left"))
        {
            posicionAnterior = transform.position;
        }
        if (Input.GetKeyDown("up"))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + salto, transform.position.z);
        }

        if (Input.GetKeyDown("down"))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - salto , transform.position.z);
        }

        if (Input.GetKeyDown("right"))
        {
            transform.position = new Vector3(transform.position.x + salto , transform.position.y, transform.position.z);
            gameObject.GetComponent<Animator>().SetBool("moving", true);
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }

        if (Input.GetKeyDown("left"))
        {
            transform.position = new Vector3(transform.position.x - salto, transform.position.y, transform.position.z);
            gameObject.GetComponent<Animator>().SetBool("moving", true);
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }

        if(!Input.GetKey("left") && !Input.GetKey("right"))
        {
            gameObject.GetComponent<Animator>().SetBool("moving", false);
        }
       
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "paredes")
        {
            transform.position = posicionInicial;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "block")
        {
            transform.position = posicionAnterior;
        }

        if(collision.gameObject.tag == "desblock")
        {
            GameObject.Destroy(GameObject.FindWithTag("block"));
        }
    }
}
