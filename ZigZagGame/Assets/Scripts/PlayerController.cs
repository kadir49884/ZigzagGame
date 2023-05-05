using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    Vector3 yon = Vector3.left;
    [SerializeField] float speed;

    public GroundSpawner groundSpawner;

    public static bool isDead = false;


    public float hizlanmaZorlugu;

    // Start is called before the first frame update
    void Update()
    {
        if ( isDead)
        {
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            if(yon.x == 0)
            {
                yon = Vector3.left;
            }
            else
            {
                yon = Vector3.back;
            }
        }

        if(transform.position.y < 0.1f)
        {
            isDead = true;
            Destroy(gameObject, 3);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if ( isDead)
        {
            return;
        }

        Vector3 hareket = yon * speed * Time.deltaTime;
        transform.position = Vector3.Lerp(transform.position, transform.position + hareket, 0.7f);
        speed += Time.deltaTime * hizlanmaZorlugu;
        //transform.position += hareket;
    }


    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.CompareTag("Zemin"))
        {
            groundSpawner.ZeminOlustur();
            StartCoroutine(YokEt(collision.gameObject));
        }
    }

    IEnumerator YokEt(GameObject zemin)
    {
        yield return new WaitForSeconds(0.3f);
        if(!zemin.GetComponent<Rigidbody>())
        {
            zemin.AddComponent<Rigidbody>();
        }
        yield return new WaitForSeconds(1f);
        Destroy(zemin);
    }
}
