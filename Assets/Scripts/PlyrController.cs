using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlyrController : MonoBehaviour
{
    [Header("OutCompanent")]
    
    [SerializeField]
    float speed;
    public static bool IsDead=true;
    public GroundSpawner groundspawner;
    public float speedDificulty;
    public float boost;
    

    float artisMiktari = 1f;
    float score = 0f;
    int BestScore = 0;
    int coin = 0;

    Vector3 yon = Vector3.left;

    public GameObject restartGame,playGamePanel;
    [SerializeField]
    Text ScoreText,bestScoreText,coinText,bestWelcome;
    [SerializeField]
    Animator anim;
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
            restartGame.SetActive(true);
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
        ScoreIslemi();
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
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("coin"))
        {
            coin++;
            coinText.text="Coins :"+coin.ToString();
            Destroy(other.gameObject);

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
        bestWelcome.text="Best Score : "+BestScore.ToString();
        bestScoreText.text = "Best: "+ BestScore.ToString();
        if(RestartGame.isRestart)
        {
            playGamePanel.SetActive(false);
            PlyrController.IsDead = false;
        }
    }
    public void PlayGame()
    {
        IsDead = false;
        playGamePanel.SetActive(false);
    }
    void ScoreIslemi()
    {
        if (BestScore < score&& BestScore>0)
        {
            anim.SetBool("record",true);
        }
        
        
        if ((int)score%30==0 &&score>1)
        {
           
            speedDificulty += 0.01f;
        }
    }
}//class
