using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject sonZemin,coin;
    // Start is called before the first frame update
   public void ZeminOlustur()
    {
        Vector3 yon;
        if (Random.Range(0, 2)==0)
        {
            yon = Vector3.left;
        }
        else
        {
            yon = Vector3.back;
        }
        sonZemin = Instantiate(sonZemin, sonZemin.transform.position + yon, sonZemin.transform.rotation);
        
    }
    private void Start()
    {
        for (int i = 1; i < 20; i++)
        {
            ZeminOlustur();
            CoinOlustur();
        }
    }
    void CoinOlustur()
    {
        if (Random.Range(0, 3) == 0)
        {
            coin = Instantiate(coin, sonZemin.transform.position + new Vector3(0f, 0.88f, 0f), sonZemin.transform.rotation);
            StartCoroutine(YokEtCoin(coin));
        }
        IEnumerator YokEtCoin(GameObject coin)
        {
            yield return new WaitForSeconds(50f); Destroy(coin);
        }
    }
    

}
