using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {
    private Rigidbody rb;
    public float speed;
    public Text winText;
    private int count;
    public AudioSource[] sounds;
    public Text countText;
    //public AudioSource noise1;
    //public AudioSource noise2;
    public DeactivatePath path1;
    void Start()
    {
        
        rb = GetComponent<Rigidbody>();
        
        count = 0;
        if(Application.loadedLevelName=="oldGame")
        countText.text = "COUNT: " + count.ToString();
        winText.text = "";        
    }	

    void FixedUpdate()
    {

         Vector3 m_Movement = new Vector3(Input.acceleration.x, 0, -Input.acceleration.z);
         transform.Translate(m_Movement * 10 * Time.deltaTime);

        
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
            rb.AddForce(movement * speed);

        }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick up"))
        {

            PlaySounds(0);
            other.gameObject.SetActive(false);
            count = count + 1;

            if (Application.loadedLevelName == "oldGame")
            {

                countText.text = "COUNT: " + count.ToString();
                if(count == 10)
                {
                    YouWin();

                    Application.LoadLevel("miniGame");
                    return;
                }
            }
            // string str = "YOU WIN..!";
            if (count==14 && Application.loadedLevelName == "miniGame")
            {
                

                
               
                
                    YouWin();
                    
                    Application.LoadLevel("Level 3");
                    return;
                
                
                
              //  SceneManager.LoadScene("Scene2");

            }

            if (Application.loadedLevelName == "Level 3" && count == 14)
            {
                GameObject go = GameObject.Find("Path1Right");
                go.SetActive(false);
            }


            if (count == 20 && Application.loadedLevelName == "Level 3")
            {
                YouWin();
            }
        }
    }

    void YouWin()
    {
        PlaySounds(1);
        winText.text = "YOU WIN...!";
    }
    void PlaySounds(int index)
    {
        sounds = GetComponents<AudioSource>();
        sounds[index].Play();
       
    }

    void setCount()
    {
        count = count + 1;

    }
	
}
