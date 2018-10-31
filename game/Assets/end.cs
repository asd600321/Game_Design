using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class end : MonoBehaviour {

            private bool over = false;
            // Use this for initialization
            void Start () {
                        Debug.Log("123");
            }
            /*void OnCollisionEnter()
            {
                        over = true;
            }*/
            //Debug.Log("");
            void OnTriggerEnter2D(Collider2D other)
            {
                        Debug.Log(other.gameObject.name + " : " + gameObject.name + " : " + Time.time);
                        if(other.gameObject.tag == "end")
                                    over = true;      
            }

            void OnTriggerExit2D(Collider2D other)
            {
                        Debug.Log(other.gameObject.name + " : " + gameObject.name + " : " + Time.time);
                        if (other.gameObject.tag == "end")
                                    over = true;
            }

            void OnTriggerStay2D(Collider2D other)
            {
                        Debug.Log(other.gameObject.name + " : " + gameObject.name + " : " + Time.time);
                        if (other.gameObject.tag == "end")
                                    over = true;
            }
            
    // Update is called once per frame
            void Update () 
            {
                        if(over)
                        {
                                    PlayerPrefs.DeleteAll();
                                    Application.LoadLevel("level1");
                        }
		
	        }
}
