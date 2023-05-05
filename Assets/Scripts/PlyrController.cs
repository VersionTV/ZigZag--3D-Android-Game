using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlyrController : MonoBehaviour
{
    Vector3 yon=Vector3.left;
    [SerializeField]
    float speed;
    public static bool IsDead=false;
    public GroundSpawner groundspawner;
    public float speedDificulty;
    float artisMiktari = 1f;
    float score = 0f;
    int BestScore = 0;
    

    [SerializeField]
    Text ScoreText,bestScoreText;
    private void Update()
    {
        if(IsDead)
        {
            return;
        }
        if (Input.GetMouseButtonDown(0))
        {
            if (yon.x == 0)
            {
                yon = Vector3.left;
            }
            else
            {
                yon = Vector3.back;
            }
        }
        if (transform.position.y < 0.1f)
        {
            IsDead = true;
            if (BestScore<score)
            {
                BestScore =(int) score;
                PlayerPrefs.SetInt("BestScore", BestScore);
            }
            Destroy(this.gameObject, 3f);
        }
    }
    private void FixedUpdate()
    {
        if (IsDead)
        {
            return;
        }
        Vector3 hareket = yon * speed * Time.deltaTime;
        speed += Time.deltaTime * speedDificulty;
        transform.position += hareket;

        score += speed * artisMiktari * Time.deltaTime;
        
        ScoreText.text ="Score: "+((int) score).ToString();
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Zemin"))
        {
            StartCoroutine(YokEt(collision.gameObject));
            groundspawner.ZeminOlustur();
        }
    }
    IEnumerator YokEt(GameObject zemin)
    {
        yield return new WaitForSeconds(0.2f);
        zemin.AddComponent<Rigidbody>();
        yield return new WaitForSeconds(0.5f);Destroy(zemin);
    }
    private void Start()
    {
        BestScore = PlayerPrefs.GetInt("BestScore");
        bestScoreText.text = "Best: "+ BestScore.ToString();
    }
}//class
