using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject sonZemin;
    // Start is called before the first frame update
    void ZeminOlustur()
    {
        sonZemin = Instantiate(sonZemin, sonZemin.transform.position + Vector3.back, sonZemin.transform.rotation);
    }
    private void Start()
    {
        for (int i = 1; i < 10; i++)
        {
            ZeminOlustur();
        }
    }

}
