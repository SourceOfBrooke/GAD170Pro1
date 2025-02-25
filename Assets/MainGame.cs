using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGame : MonoBehaviour
{

    public int playerhealth = 100;
    int playerlives = 3;
    int room = 0;
    bool infight = false;
    bool roomsearched = false;
    int coins = 0;

    // Start is called before the first frame update
    void Start()
    {
       
        Debug.Log("You awaken in a dark and empty room");
        
        Debug.Log("You get to your feet and think about what to do next ");
        
        Debug.Log("What should you do next \n [1] Look around the room [2] Exit the room");
    }

    // Update is called once per frame
    void Update()
    {   // Affects players health and lives 
        if (playerlives == 0) 
        {
            YouDied();
        }
        if (playerhealth == 0) 
        {
            playerlives = playerlives - 1;
            playerhealth = 100;
        }
        // Shows how many coins the player has
        if (Input.GetKeyDown(KeyCode.I)) 
        {
            Debug.Log("You Have " + coins + " coins");
        }
        // Press 2 to search a room 
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Searchroom();
        }
        // Press 1 to search a room 
        if (Input.GetKeyDown(KeyCode.Alpha1)) 
        {
            Searchroom();
        }
    }

    void Searchroom() 
    {
        int loot = Random.Range(0, 101);

        if (infight == false) 
        {
            if(roomsearched == false) 
            {
                Debug.Log("You found " + loot + " coins");
                roomsearched = true;
                coins = coins + loot;
                Debug.Log("What should you do next \n [1] Look around the room [2] Exit the room");
            }
            else 
            { Debug.Log("You already searched this room");
                Debug.Log("What should you do next \n [1] Look around the room [2] Exit the room");
            }
        }
    }


    void RandomEncounter() 
        // Rolls for random encounter every movement and chooses the enemy type 
    {
        int roll = Random.Range(0, 11);
        string creature = "goblin";
        int creatureroll = Random.Range(0, 11);

        if (creatureroll <= 4) 
        {
            creature = "Goblin";
        }
        if (creatureroll == 5) 
        {
            creature = "Mimic";
        }
        if (creatureroll >= 6)
        {
            creature = "Troll";
        }

        if (roll >= 7) 
        {
            infight = true;
            Debug.Log("What the- A " + creature + " stands before you");
            
        }

        


    }

   void NextRoom() 
    {
        
    }

    public void YouDied()
    // runs when the player dies
    {
        Debug.Log("You Died \n [1] Last checkpoint    [2] Start over");
    }


}
