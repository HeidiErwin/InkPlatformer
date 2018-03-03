using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
 
// controls switching levels and restarting levels; give this script to the 
// object (e.g. flag) with which the player collides to progress to the next level
public class LevelControl : MonoBehaviour
{
    //keeps track of the index of the current level
    private int levelIndex;

    //switching levels when goal reached
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // layer 8 is player; if this object contacts the player then go to the next level
        if (collision.gameObject.layer == 8)
        {
            SceneManager.LoadScene(levelIndex + 1);
            levelIndex++;
        }
    }

}

// NOTE: To assign indeces to levels:
// File > Build Settings > (add the scenes which correspond to levels), look at the right 
// for build indeces / level indeces
