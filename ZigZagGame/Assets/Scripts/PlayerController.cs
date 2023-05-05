using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    Vector3 yon = Vector3.left;
    [SerializeField] float speed;

    public GroundSpawner groundSpawner;

    private bool isGameStart;
    public static bool isDead = false;

    private void Start()
    {
        StartCoroutine(WaitForStart());
    }

    // Start is called before the first frame update
    void Update()
    {
        if (!isGameStart || isDead)
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
        if (!isGameStart || isDead)
        {
            return;
        }

        Vector3 hareket = yon * speed * Time.deltaTime;
        transform.position = Vector3.Lerp(transform.position, transform.position + hareket, 0.7f);
        //transform.position += hareket;
    }

    IEnumerator WaitForStart()
    {
        yield return new WaitForEndOfFrame();
        isGameStart = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.CompareTag("Zemin"))
        {
            Debug.Log("Zeminden cikti");
            groundSpawner.ZeminOlustur();
            StartCoroutine(YokEt(collision.gameObject));
        }
    }

    IEnumerator YokEt(GameObject zemin)
    {
        yield return new WaitForSeconds(0.3f);
        zemin.AddComponent<Rigidbody>();
        yield return new WaitForSeconds(1f);
        Destroy(zemin);
    }
}
