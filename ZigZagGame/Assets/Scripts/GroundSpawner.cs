using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{

    [SerializeField] GameObject sonZemin;

    

    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            ZeminOlustur();
        }
    }

    
    public void ZeminOlustur()
    {

        Vector3 yon;
        if(Random.Range(0,2) == 0)
        {
            yon = Vector3.left;
        }
        else
        {
            yon = Vector3.back;
        }
        sonZemin = Instantiate(sonZemin, sonZemin.transform.position + yon, sonZemin.transform.rotation);
    }
}
