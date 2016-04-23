using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Rotator : MonoBehaviour {

	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyUp(KeyCode.A))
            {
            SceneManager.LoadScene("miniGame");
        }
         transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);



    }

    void OnMouseDown()
    {
        

        
            }
}
