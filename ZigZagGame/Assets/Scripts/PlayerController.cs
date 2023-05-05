using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    Vector3 yon = Vector3.left;
    [SerializeField] float speed;

    public GroundSpawner groundSpawner;

    // Start is called before the first frame update
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
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
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 hareket = yon * speed * Time.deltaTime;
        transform.position += hareket;
    }

    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.CompareTag("Zemin"))
        {
            Debug.Log("Zeminden cikti");
            groundSpawner.ZeminOlustur();
            YokEt(collision.gameObject);
        }
    }

    void YokEt(GameObject zemin)
    {
        Destroy(zemin);
    }
}
