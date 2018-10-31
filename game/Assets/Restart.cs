using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Restart : MonoBehaviour {

	// Use this for initialization
	        void Start () {
		
	        }

            public bool Esc
            {
                        get
                        {
                                    return Input.GetKeyDown(KeyCode.Escape);
                        }
            }


            void restart()
            {
                        if (Esc)
                        {
                                    PlayerPrefs.DeleteAll();
                                    Application.LoadLevel("level1");
                        }
            }

                        // Update is called once per frame
            void Update () 
            {
                        restart();


            }
}
