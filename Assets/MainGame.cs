using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class MainGame : MonoBehaviour
{
    bool playersturn = true;
    bool bossfight = false;
    public int playerhealth = 200;
    int room = 0;
    bool infight = false;
    bool roomsearched = true;
    int coins = 0;
    bool haskey = false;
    int bossHealth = 500;
    bool gameStarted = false;
    bool isplayerdead = false;
    int healthPotion = 2;
    int atckTurn = 0;


    // Start is called before the first frame update
    void Start()
    {     

        Debug.Log("Welcome to Dungeon Crawl The Game tm \n [2] To Start playing [i] For inventory [3] to heal");
    }

    // Update is called once per frame
    void Update()
    {   // Kills player when health reaches 0
       if (isplayerdead == false) 
        {
            if (playerhealth <= 0)
            {
                isplayerdead = true;
                YouDied();
            }
        }
       // when its not the players turn the boss can and will attack
       if (playersturn == false) 
        {
            int bossatk = Random.Range(30, 43);
            playersturn = true;
            Debug.Log("The Gardian strike you and deals "+ bossatk +" Damage");
            playerhealth = playerhealth - bossatk;
            Debug.Log("Player has " + playerhealth + " Health left");
            Debug.Log("It's your turn to attack");
            Debug.Log("[1] to attack [3] to heal");
        }
        // Shows what the player has picked up
        if (Input.GetKeyDown(KeyCode.I)) 
        {
            Debug.Log("You Have " + coins + " coins");
            if (haskey == true) 
            {
                Debug.Log("you have a rusty key");
            }
        }
        // press 3 at anytime to heal
        if (Input.GetKeyDown(KeyCode.Alpha3)) 
        {
            if (healthPotion >= 1) 
            {
                Debug.Log("You used a potion and restored 50 health points");
                playerhealth = playerhealth + 50;
                Debug.Log("Player now has " + playerhealth + " health");
            }
            else
            {
                Debug.Log("You dont have any potions to use");
            }
        }
        // Press 2 for other actions
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            // if not in fight move freely
            if (infight == false)
            {
                NextRoom();
            }
            // if reached the boss you can choose to fight
           if (infight == true && bossfight == true)
            {
                BossFight();
            }
           if (isplayerdead == true) 
            {
                
                NextRoom();
            }
           

        }
        
        if (Input.GetKeyDown(KeyCode.Alpha1)) 
        {   // Press 1 for differnt actions
           if (gameStarted == true) 
            {
                if (infight == false && bossfight == false)
                {   // if not fighting anyone you can seearch the room
                    Searchroom();
                }  
                if (bossfight == true && infight == false) 
                {   // if you have reached to boss and you choose to give up you die
                    Debug.Log("You give up");
                    YouDied();
                }
                if (bossfight == true && infight == true) 
                {   // if you choose to fight then you fight wow
                    if (playersturn == true) 
                    {
                        playersturn = false;
                        int plyratk = Random.Range(44, 89);
                        Debug.Log("You swing your sword and deal "+  plyratk + " damage");
                        bossHealth = bossHealth - plyratk;
                        Debug.Log("The Gardian has " + bossHealth + " health left");
                    }
                }
                
            }

           // Checks Bosses Health player wins when boss is deaded
           if (bossHealth <= 0) 
            {
                Youwin();
            }

            

        }
    }


    // Function for seaching rooms
    // gives an amount for loot and rolls a chance for random encounters
    void Searchroom() 
    {
        int loot = Random.Range(1, 101);
        int potionloot = Random.Range(0, 3);

        if (infight == false) 
        {
            if(roomsearched == false) 
            {
                Debug.Log("You found " + loot + " coins");
                Debug.Log("You also found " + potionloot + " health potions");
                if (room == 4)
                {
                    haskey = true;
                    Debug.Log("You look around the room \n you look under some rubble and find a rusty key");
                }
                roomsearched = true;
                coins = coins + loot;
                healthPotion = healthPotion + potionloot;
                Debug.Log("What should you do next \n [1] Look around the room [2] Exit the room");
            }
            
            else 
            { Debug.Log("You already searched this room");
                Debug.Log("What should you do next \n [1] Look around the room [2] Exit the room");
            }
        }
    }

    //  Boss battle keeps track of turns health and rolls for damage dealt by and to the play
    void BossFight() 
    {
        
        
        if (atckTurn == 0) 
        {
            atckTurn = 1;
            Debug.Log("Your fight begins");
            Debug.Log("The Gardian approaches");
            Debug.Log("[1] to attack [3] to heal");
        }
        

    }

    void Youwin() 
    {
        Debug.Log("The gardian falls before you");
        Debug.Log("YOU WIN YIPPEE");
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
        Debug.Log("You Died [2] Start over");
        
        playersturn = true;
        bossfight = false;
        playerhealth = 200;
        room = 0;
        infight = false;
        roomsearched = true;
        coins = 0;
        haskey = false;
        bossHealth = 500;
        gameStarted = false;
        isplayerdead = false;
        healthPotion = 2;
        atckTurn = 0;
        
    }


}
