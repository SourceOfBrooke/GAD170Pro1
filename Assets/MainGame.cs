using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MainGame : MonoBehaviour
{
    bool bossfight = false;
    public int playerhealth = 100;
    int room = 0;
    bool infight = false;
    bool roomsearched = true;
    int coins = 0;
    bool haskey = false;
    int bossHealth = 500;
    bool gameStarted = false;

    // Start is called before the first frame update
    void Start()
    {     

        Debug.Log("Welcome to Dungeon Crawl The Game tm \n [2] To Start playing [i] For inventory");
    }

    // Update is called once per frame
    void Update()
    {   // Kills player when health reaches 0
       if (playerhealth == 0) 
        {
            YouDied();
        }
        // Shows how many coins the player has
        if (Input.GetKeyDown(KeyCode.I)) 
        {
            Debug.Log("You Have " + coins + " coins");
            if (haskey == true) 
            {
                Debug.Log("you have a rusty key");
            }
        }
        // Press 2 to move to the next room
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
           if (infight == false)
            {
                NextRoom();
            }
           if (infight == true && bossfight == true)
            {
                BossFight();
            }

        }
        // Press 1 to search a room 
        if (Input.GetKeyDown(KeyCode.Alpha1)) 
        {
           if (gameStarted == true) 
            {
                if (infight == false && bossfight == false)
                {
                    Searchroom();
                }  
                if (bossfight == true) 
                {
                    Debug.Log("You give up");
                    YouDied();
                }
                
            }

            
        }
    }


    // Function for seaching rooms
    // gives an amount for loot and rolls a chance for random encounters
    void Searchroom() 
    {
        int loot = Random.Range(0, 101);

        if (infight == false) 
        {
            if(roomsearched == false) 
            {
                Debug.Log("You found " + loot + " coins");
                if (room == 4)
                {
                    haskey = true;
                    Debug.Log("You look around the room \n you look under some rubble and find a rusty key");
                }
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
    

    void BossFight() 
    {
        Debug.Log("Your fight begins");
        Debug.Log("The Gardian approaches");

    }
    //  Boss battle keeps track of turns health and rolls for damage dealt by and to the player 



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
       // Contains all text for dialouge when moving between rooms
       // Also changes room number to keep trrack of the players location
       // Also also marks the room as unsearched
        
        

            room = room + 1;
            roomsearched = false;
            if (room == 1)
            {
                gameStarted = true;
                Debug.Log("You awaken in a dark and empty room");

                Debug.Log("You get to your feet and think about what to do next ");

                Debug.Log("What should you do next \n [1] Look around the room [2] Go to the next room");

            }
            if (room == 2)
            {
                Debug.Log("You walk into a corridor that leads straight");
                Debug.Log("You hear wispers ahead");
                Debug.Log("What should you do next \n [1] Look around the room [2] Go to the next room");
            }
            if (room == 3)
            {
                Debug.Log("You enter a dingy room");
                Debug.Log("You're surrounded by cobwebs and bones ");
                Debug.Log("What should you do next \n [1] Look around the room [2] Go to the next room");
            }
            if (room == 4) 
            {
                Debug.Log("You enter large room lit by candles");
                Debug.Log("The exit door seems locked ");
                Debug.Log("What should you do next \n [1] Look around the room [2] Go to the next room");
            }
            if (room == 5)
            {
                if (haskey == false) 
                {
                    room = room - 1;
                    Debug.Log("You try to open the door but it doesnt budge");
                }
                else 
                {
                    Debug.Log("You use the rusty key on the door");
                    Debug.Log("The door creaks open into a long corridor ");
                    Debug.Log("What should you do next \n [1] Look around the room [2] Go to the next room");
                }
            }
            if (room == 6) 
            {
                bossfight = true;
                Debug.Log("You walk through the hallway and enter a large room");
                Debug.Log("As you enter candles all around the room ignite");
                Debug.Log("Standing before you is the dungeons guardian");
                Debug.Log("What should you do next \n [1] Give up [2] Fight!");

            }
            if (room == 7) 
            {
                infight = true;
                Debug.Log("You choose to fight");
                Debug.Log("Get ready, this fight wont be easy");
                Debug.Log("[2] To continue");
            }

        
    }

    public void YouDied()
    // runs when the player dies
    {
        Debug.Log("You Died \n [1] Last checkpoint    [2] Start over");
    }


}
