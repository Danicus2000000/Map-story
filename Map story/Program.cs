using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Map_story
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Declared Variables
            //Declaring variables
            Random hp_set= new Random();//creates a random generator to set the players max hp
            int max_hp = hp_set.Next(16,34); //sets the players maximum hp
            int hp = max_hp; //make an enemy random chance for emeies tospawn during tile cross
            int kills = 0;//tracks number of kills the player has
            int result_roll = 0;//stores result of random enem_chance
            int result_choice = 0;//stores rsult of enem_choice
            int health_potions = 2; //stores the number of  potions you own that heal 10 hp
            int max_hp_potions = 0; //stores the number of max hp potions that restore all health
            int level_up_potions = 0; //stores level up poitons that when used level you up restoring your health and increasing it and your damage
            bool potion_used = false;// value=true when potion used false if not used during battle phase
            int gold = 0; //overall storage of gold
            int gold_earned = 0;//gold earned from battle
            string choice = null; //stores the choices you make throughout the game
            bool run = false; //works out whether running occured correctly
            int enemy_hp = 0;//stores the Hp of the current enemy being fought
            int enemy_max_hp_result = 0;//stores result of the random generation of enemy_max hp bound by an array that limmits it based on the individual class
            //int enemy_max_hp = 10;//enemy hp maximum starts at 10
            //int enemy_attack = 2; //enemy attack begins at 2 dph
            Random enem_chance = new Random();//Stores the random generator for the chance of an enemy popping up
            Random enem_damage = new Random();//stores the random generator for enemy damage
            int enem_attack = 0;//stores the result of how much damage an enemy does on his turn
            int enem_level = 1;//add enemy level to their damage and hp
            Random player_damage = new Random();//gets random amount of player damage
            int player_attack = 0;//stores the random amount of damage a player does on his turn
            int player_level = 1;//add player_level to the damage and hp
            //result_roll = roll.Next(1, 4); how to roll for enemy
            int mapspace = 13;//stores current position on the map
            int tries = 0;//stores number of attempts you've had at enetering your name
            string name = null;//stores your name
            string confirm = null;//stores your confirmation of name
            string potion_choice = null;//stores wether or not you used a potion on your turn
            string go_to = null;//stores where you want to go to on your movement phase
            bool north = true;//stores whether you can move north
            bool south = true;//stores whether you can move south
            bool east = true;//stores whether you can move east
            bool west = false;//stores whether you can move west
            Random run_fail = new Random();//stores the random generator to see if running fails
            int run_fail_result = 0;//stores the result of the 1/8 chance of running failing
            #endregion

            #region Map Parts
            String[] map_parts;//prepaires array for map destination descriptions
            map_parts = new String[25];//Allocates size to array
            map_parts[0] = "A massive Graveyard filled with the living dead, they stalk and prey on the living, pity you are unprepared";
            map_parts[1] = "A barren wasteland stripped away by poverty and years of abandoned hope, the children of this town starve. And yet nobody can help them.";
            map_parts[2] = "This is a ferm and it made your favorite foods pertaters!!!!!!!!!!!!!!!!!!!!!!!!!!!!";
            map_parts[3] = "Another empty wasteland. This one seems to have a faint glow to it, is that the sunrise? or... oh.";
            map_parts[4] = "A valley leading down into the earth, how many fathoms deep.. nobody knows.";
            map_parts[5] = "The centre of the Earth! The core burns hot here. Despite the ash that flies through the air, I love it!";
            map_parts[6] = "A withered and supposedly haunted old mansion... Ivy chokes the walls, and there is more dust than there is brick and mortar.";
            map_parts[7] = "A Rocky Plateau, many believe this is home to the dreaded Dragons and Wyverns";
            map_parts[8] = "The shopkeeper Stares deep into your eyes, i hope he is just keen to sell his potions...";
            map_parts[9] = "An empty farmer's field, containing nothing but some cows... as far as you can see..";
            map_parts[10] = "A long, winding road, leading into the misty unknown.";
            map_parts[11] = "The screams from the unknown land echo through your skull.";
            map_parts[12] = "Your beautiful homeland! A blissful town, that is perfect in every way. I hope every town is like this...";
            map_parts[13] = "This area is inhabited by vampires, many of whom seem a little quirky.  Most of them live in homes built scattered across the land.  Many among them seem a little preoccupied with an old curse and having parties is a common pastime here.  The surrounding countryside is mostly broken and spotted with huge bluish stones.";
            map_parts[14] = "This area is inhabited by tall humanlike people, many of whom seem a little quirky.  Most of them live in old-fashioned-looking towns.  Many among them seem quite preoccupied with the end of the world and having parties is a common pastime here.  The surrounding countryside is mostly mountainous and abounding with various plants.  It's lead by a princess, whom the people feel is fairly useless.";
            map_parts[15] = "Standing at the base of what appears to be a mountain, the fog clears and the peaks loom above you.";
            map_parts[16] = "It's a huge, ostentatious temple dedicated to an incarnate deity.";
            map_parts[17] = "It's an abandoned house located out in the woods.  It was built in 1964.  A researcher who went to visit it vanished for months, only to turn up hundreds of miles away confused and bewildered.";
            map_parts[18] = "This spacefaring civilization was famous for its music, sports, and art.  It was abandoned when rising water levels began to overtake it.";
            map_parts[19] = "This civilization much like our own was famous for its art, music, and technology.  It declined as pollution and unsustainable farming practices rendered the land barren and toxic.";
            map_parts[20] = "It's a three-rowed star-shaped arrangement of stones that stands about 9 feet high at the tallest. Many of the stones are carved with holy symbols.  It's said that a deity resides here.";
            map_parts[21] = "This enormous multi-story museum of ancient artifacts has a quaint atmosphere.  The interior is done in nautical colors.  Also, rumor has it that a group of thieves used the building as a meeting place.";
            map_parts[22] = "This large park has a quaint atmosphere.  It boasts outdoor chessboards, several sculptures, and many trees.";
            map_parts[23] = "This realm is inhabited by dinosaur people, most of whom seem quite serious.  Most of them live in homes built in the trees.  The surrounding countryside is mostly hilly and covered with gigantic greenish rocks.  It also hosts many streams.  It's lead by a president, whom the people feel is terrible.";
            map_parts[24] = "This moderately-sized house has a retro look to it and is in good condition.  The interior is done in colors that remind you of a thunderstorm.  The yard is large and is overgrown with wild plants.  Also, it has been empty for a long time.";
            Console.WriteLine("Welcome to the magical land of Thorainsphorpe! Here all is calm... or is it?");
            Console.WriteLine("Venture fair hero and find all that is wrong in this land and end it!");
            #endregion

            #region Enemy Names
            string[] enemy_names;//stores all the enemies names
            enemy_names = new string[27];
            enemy_names[0] = "Pawn";
            enemy_names[1] = "Bishop of the darker church";
            enemy_names[2] = "Underling gremlin";
            enemy_names[3] = "Aura of the Night";
            enemy_names[4] = "Targon";
            enemy_names[5] = "PWNhammer";
            enemy_names[6] = "Slime";
            enemy_names[7] = "Gabe";
            enemy_names[8] = "Thief";
            enemy_names[9] = "Goblin Scout";
            enemy_names[10] = "Bandit Chief";
            enemy_names[11] = "Wolf";
            enemy_names[12] = "Orc Scout";
            enemy_names[13] = "Hunter";
            enemy_names[14] = "Goblin Mercenary";
            enemy_names[15] = "Orc Footsoldier";
            enemy_names[16] = "Wizard Apprentice";
            enemy_names[17] = "Vampire";
            enemy_names[18] = "Goblin King";
            enemy_names[19] = "Corrupt Wizard";
            enemy_names[20] = "Orc Warrior";
            enemy_names[21] = "Giant Eagle";
            enemy_names[22] = "Ancient Wyvern";
            enemy_names[23] = "Grand Master Wizard";
            enemy_names[24] = "Orc King";
            enemy_names[25] = "Master Vampire";
            enemy_names[26] = "Horseless Headless Horseman";
            #endregion

            #region Enemy Descriptions
            string[] enemy_descriptions;//stores all enemy descriptions
            enemy_descriptions = new string[27];
            enemy_descriptions[0] = "The weakest piece. Often sacrificed, it plays a major part in the overall plan for your demise.";//description for the pawn
            enemy_descriptions[1] = "The bishop has devoted his life to the satanic arts of darkness, now he wants another sacrifice... You!";//description for bishop of the darker church
            enemy_descriptions[2] = "The servant to everyone. Don't let him kill you... He's the weakest one here!";//description for the underling gremlin
            enemy_descriptions[3] = "The floating remanants of dark and decietful doings, looking to inhabit another body!";//description for the aura of the night
            enemy_descriptions[4] = "The Dragon Lord, Overlord of all creatures!";//description for Targon
            enemy_descriptions[5] = "Terraria is back, with a vengeance for blood.";//description for PWNhammer
            enemy_descriptions[6] = "Your average slime is walkin here!";//description for Slime
            enemy_descriptions[7] = "Is it a doge or is it the leader of a corporate company? i can't tell.";//description for Gabe
            enemy_descriptions[8] = "I'm a thief see? Imma rob ya see?";//description for thief
            enemy_descriptions[9] = "His binoculars are broken.";//description of Goblin Scout
            enemy_descriptions[10] = "WarHammer. Just WarHammer";//description for bandit chief
            enemy_descriptions[11] = "It's gone feral! Kill it, it could be infected!";//description for wolf
            enemy_descriptions[12] = "His scimitar is rusty.";//description for Orc Scout
            enemy_descriptions[13] = "He heard nature calling... So he killed it.";//description for the hunter
            enemy_descriptions[14] = "Mercenary = Money";//description for the Goblin Mercenary
            enemy_descriptions[15] = "His Master will see him no more";//description for Orc Footsoldier
            enemy_descriptions[16] = " “MAGIC!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!";//Description for wizzards apprentice
            enemy_descriptions[17] = "Give me vampirism please!!";//Description for vampire
            enemy_descriptions[18] = "King of all goblins.. Pretty cool not gonna lie.";//Description of Goblin King
            enemy_descriptions[19] = "Dark forces controlled this wizzard, he is finally at peace now.";//Description of Corrupt Wizzard
            enemy_descriptions[20] = "Born and modified to kill, these monsters will stop at nothing to end your life.";//Description of Orc Warrior
            enemy_descriptions[21] = "Not just a regular eagle. Its a GIANT eagle.";//Description for Giant Eagle
            enemy_descriptions[22] = "As old as time itself, it has waited for centuries knowing you would pass this spot at this time and fall victim to its massive jaws.";//Description for ancient wyvern
            enemy_descriptions[23] = "MAGIC!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!";//Description for Grand Master Wizzard
            enemy_descriptions[24] = "Sits on a throne of bones, and now he's got one to pick with you.";//Description for Orc king
            enemy_descriptions[25] = "Can be killed by a lvl 4 with a broken war axe and ahhhhhhhhhhhhhh i've got vampirism!";//Description for master vampire
            enemy_descriptions[26] = "He lost his horse.. and his head.. and his life. He wants replacements.";//Description of Horseless Headless HorseMan
            #endregion

            #region Enemy Max HP
            int[] enemy_max_hp;
            enemy_max_hp = new int[27];
            enemy_max_hp[0] = 10;//pawn's max hp
            enemy_max_hp[1] = 10;//Bishop's max hp
            enemy_max_hp[2] = 8;//underling gremlin's max hp
            enemy_max_hp[3] = 12;//Aura of the night's max hp
            enemy_max_hp[4] = 34;//targons max hp
            enemy_max_hp[5] = 7;//PWNhammer's max hp
            enemy_max_hp[6] = 9;//slime's max hp
            enemy_max_hp[7] = 16;//Gabe's max hp
            enemy_max_hp[8] = 12;//thief's max hp
            enemy_max_hp[9] = 6;//goblin scout's max hp
            enemy_max_hp[10] = 20;//bandit chief's max hp
            enemy_max_hp[11] = 6;//wolf's max hp
            enemy_max_hp[12] = 8;//orc scout's max hp
            enemy_max_hp[13] = 14;//hunter's max hp
            enemy_max_hp[14] = 12;//Goblin mercanarie's max hp
            enemy_max_hp[15] = 13;//orc footsoldier's max hp
            enemy_max_hp[16] = 14;//Wizard apprentice's max hp
            enemy_max_hp[17] = 16;//Vampire's max hp
            enemy_max_hp[18] = 24;//goblin king's max hp
            enemy_max_hp[19] = 14;//Corupt wizzard's max hp
            enemy_max_hp[20] = 15;//Orc Warrior's max hp
            enemy_max_hp[21] = 18;//giant eagle's max hp
            enemy_max_hp[22] = 28;//Ancient Wyvern's max hp
            enemy_max_hp[23] = 26;//Grand Master Wizzard's max hp
            enemy_max_hp[24] = 27;//Orc King's Max hp
            enemy_max_hp[25] = 28;//Master Vampire's max hp
            enemy_max_hp[26] = 250;//HorseLess HeadLess HorseMan's Max hp
            #endregion

            #region Enemy Max Damage
            int[] enemy_max_damage;
            enemy_max_damage = new int[27];
            enemy_max_damage[0] = 3;//pawn's max attack
            enemy_max_damage[1] = 5;//Bishop's max attack
            enemy_max_damage[2] = 3;//underling gremlin's max attack
            enemy_max_damage[3] = 5;//Aura of the night's max attack
            enemy_max_damage[4] = 16;//targons max attack
            enemy_max_damage[5] = 4;//PWNhammer's max attack
            enemy_max_damage[6] = 4;//slime's max attack
            enemy_max_damage[7] = 6;//Gabe's max attack
            enemy_max_damage[8] = 6;//thief's max attack
            enemy_max_damage[9] = 4;//goblin scout's max attack
            enemy_max_damage[10] = 10;//bandit chief's max attack
            enemy_max_damage[11] = 4;//wolf's max attack
            enemy_max_damage[12] = 6;//orc scout's max attack
            enemy_max_damage[13] = 7;//hunter's max attack
            enemy_max_damage[14] = 7;//Goblin mercanarie's max attack
            enemy_max_damage[15] = 6;//orc footsoldier's max attack
            enemy_max_damage[16] = 4;//Wizard apprentice's max attack
            enemy_max_damage[17] = 5;//Vampire's max attack
            enemy_max_damage[18] = 12;//goblin king's max attack
            enemy_max_damage[19] = 8;//Corupt wizzard's max attack
            enemy_max_damage[20] = 7;//Orc Warrior's max attack
            enemy_max_damage[21] = 11;//giant eagle's max attack
            enemy_max_damage[22] = 13;//Ancient Wyvern's max attack
            enemy_max_damage[23] = 13;//Grand Master Wizzard's max attack
            enemy_max_damage[24] = 12;//Orc King's max attack
            enemy_max_damage[25] = 14;//Master Vampire's max attack
            enemy_max_damage[26] = 125;//Horseless HeadLess HorseMan's max attack
            #endregion

            while (true)//name confimation loop
                {
                    Console.WriteLine("Hello brave adventurer what be your name?");
                    name = Console.ReadLine();
                    Console.WriteLine("Ah are you definitely called {0}?", name);
                    confirm = Console.ReadLine().ToUpper();
                    if ((confirm == "YES") || (confirm == "YA") || (confirm == "YE") || (confirm=="YEET"))
                    {
                        Console.Clear();
                        break;
                    }
                    else if (tries >= 10)
                    {
                        Console.WriteLine("Are you okay Buddy??");
                        Console.WriteLine("I think you need some help...");
                    }

                    else
                    {
                        Console.WriteLine("Okay then...");
                        tries++;
                    
                    }
                }
                while (true)//Game begins
                {
                run = false;//sets run to false to ensure your escape can occur
                run_fail_result = 0;//resets run_fail_result so you can escape
                #region Shop Logic
                if (mapspace == 9)
                {
                    tries = 0;
                    while (true)
                    {
                        Console.WriteLine("The Sign here says the shop is owned by a Mrs Trek");
                        Console.WriteLine("The shopkeeper stares at you longingly hoping you'll buy something!");
                        if (tries == 0)
                        {
                            Console.WriteLine("Would you like to Make a purchase from the shop?");
                        }
                        else
                        {
                            Console.WriteLine("Would you like to make another purchase?");
                        }
                        choice = Console.ReadLine().ToUpper();
                        if ((choice == "YES") || (choice == "YE") || (choice == "YEET") || (choice == "YEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE"))
                        {
                            while (true)
                            {
                                Console.WriteLine("1)Health Potions: 35 Gold");
                                Console.WriteLine("2)Max Health Potions: 50 Gold");
                                Console.WriteLine("3)Level Up potions: 75 Gold");
                                Console.WriteLine("Your have {0} gold", gold);
                                Console.WriteLine("Please Select a Potion or type quit or q to quit:");
                                choice = Console.ReadLine().ToUpper();
                                if ((choice == "H") || (choice == "HEALTH POTION") || (choice == "HEALTH POTIONS") || (choice == "1"))
                                {
                                    if (gold >= 35)
                                    {
                                        gold -= 35;
                                        health_potions++;
                                        tries++;
                                        Console.WriteLine("You purchase a Health Potion!");
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("You Cannot afford this item!!");
                                    }
                                }
                                else if ((choice == "M") || (choice == "MAX HEALTH POTION") || (choice == "MAX HEALTH POTIONS") || (choice == "2"))
                                {
                                    if (gold >= 50)
                                    {
                                        gold -= 50;
                                        max_hp_potions++;
                                        tries++;
                                        Console.WriteLine("You purchased a max hp potion!");
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("You cannot afford this item!!");
                                    }
                                }
                                else if ((choice == "L") || (choice == "LEVEL UP POTION") || (choice == "LEVEL UP POTIONS") || (choice == "3"))
                                {
                                    if (gold >= 100)
                                    {
                                        gold -= 100;
                                        level_up_potions++;
                                        tries++;
                                        Console.WriteLine("You purchased a Level up potion!");
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("You cannot afford this item!");
                                    }

                                }
                                else if ((choice == "Q") || (choice == "QUIT"))
                                {
                                    Console.WriteLine("Leaving you are!");
                                    break;
                                }


                                else
                                {
                                    Console.WriteLine("What are you on about {0}!", name);
                                    break;
                                }
                                Console.WriteLine("Press Enter to return!");
                                Console.ReadLine();
                                Console.Clear();
                            }
                        }
                        else if ((choice == "Q") || (choice == "QUIT") || (choice == "NO") || (choice == "NAH") || (choice == "NA") || (choice == "NO THANKS") || (choice == "NOPE"))
                        {
                            Console.WriteLine("Thank you for passing by the shop!");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("The shop keeper looks on extremly confused at your babbling!");
                        }

                    }
                }
                #endregion
                Console.WriteLine("Press Enter to continue {0}!", name);
                Console.ReadLine();
                Console.Clear();
                Console.WriteLine(map_parts[mapspace-1]); //gets description for the current tile
                while (true)
                {
                    if ((mapspace == 1) || (mapspace == 2) || (mapspace == 3) || (mapspace==4) || (mapspace==5))//Fetches the possibilities of movement in the 3x3 grid
                    {
                        north = false;
                    }
                    else
                    {
                        north = true;
                    }
                    if ((mapspace == 5) || (mapspace == 10) || (mapspace == 15) || (mapspace==20) || (mapspace==25))
                    {
                        east = false;
                    }
                    else
                    {
                        east = true;
                    }
                    if ((mapspace == 1) || (mapspace == 6) || (mapspace == 11) || (mapspace== 16) || (mapspace==21))
                    {
                        west = false;
                    }
                    else
                    {
                        west = true;
                    }
                    if ((mapspace == 21) || (mapspace == 22) || (mapspace == 23) || (mapspace==24) || (mapspace==25))
                    {
                        south = false;
                    }
                    else
                    {
                        south = true;
                    }
        
                    Console.WriteLine("Where would you like to go, oh awesome Adventurer? (north, south, east and west (or I for inventory))!");//gets the players desired move
                    go_to=Console.ReadLine().ToUpper();
                    Console.Clear();
                    result_roll = enem_chance.Next(1, 4);//rolls to see if an enemy shows up
                    run_fail_result = 0;//resets run_fail_result
                    if (result_roll == 2 && go_to!="I" && go_to !="INVENTORY" && go_to!="Q" && go_to!="QUIT" && (go_to=="NORTH" || go_to=="N" || go_to=="SOUTH" || go_to=="S" || go_to=="EAST" || go_to=="E" || go_to=="WEST" || go_to=="W")) //ensures that an enemy is nessasary for instance if an invalid input occurs an enemy isn't needed
                    {
                        result_choice = enem_chance.Next(0,enemy_names.Length-1);//rolls for a random enemy from the list of possible enemies
                        enemy_max_hp_result = enem_damage.Next(enemy_max_hp[result_choice] - 4+(enem_level-1), enemy_max_hp[result_choice]+(enem_level-1)); //gets the maximum helath of this enemy using the defined maximum with some random variation
                        enemy_hp = enemy_max_hp_result;//sets hp to equal result
                        Console.WriteLine("A {0} appeared leader {1} let us defeat it in glorious battle!",enemy_names[result_choice],name); //displays enemies appearence
                        Console.WriteLine("Press enter to Issue your command {0}!", name);//gives the player time to read :)
                        Console.ReadLine();
                        while (true)
                        {
                            while (true)
                            {
                                Console.Clear();
                                Console.WriteLine("{0}'s Hp: {1}/{2}", name, hp, max_hp);
                                Console.WriteLine("{0}'s Hp {1}/{2}", enemy_names[result_choice], enemy_hp, enemy_max_hp_result);
                                Console.WriteLine("1)Fight");
                                Console.WriteLine("2)Bag");
                                Console.WriteLine("3)Run");
                                choice = Console.ReadLine().ToUpper();
                                if ((choice == "RUN") || (choice == "FIGHT") || (choice=="BAG") || (choice=="R") ||(choice=="F") || (choice=="B") || (choice=="1") || (choice=="2") || (choice=="3"))
                                {
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("What are you on about {0} give us a command!", name);
                                    Console.WriteLine("Press Enter to reissue your command!");
                                    Console.ReadLine();
                                }
                            }
                            if ((choice == "RUN") || (choice == "R") || (choice=="3") && (run_fail_result != 7) )
                            {
                                run_fail_result = run_fail.Next(1, 8);
                                if (run_fail_result == 7)
                                {
                                    Console.WriteLine("You try to run but {0} pulls you back!", enemy_names[result_choice]);
                                    Console.WriteLine("Press Enter to stand and Fight again!");
                                    Console.ReadLine();
                                }
                                else
                                {
                                    Console.WriteLine("{0}, you and your team run from the monstor like cowards back to the previous tile", name);
                                    run = true;
                                    break;
                                }
                            }
                            else if ((choice == "RUN") || (choice == "R") || (choice=="3") && (run_fail_result == 7))
                            {
                                Console.WriteLine("{0} the monster has us Cornered we can't escape now!", name);
                                Console.WriteLine("Press Enter to stand your ground!");
                                Console.ReadLine();
                            }
                            else if ((choice == "BAG") || (choice == "B") || (choice=="2"))
                            {
                                while (true)
                                {
                                    potion_used = false;
                                    Console.Clear();
                                    Console.WriteLine("Inventory");
                                    Console.WriteLine(")-------(");
                                    if (health_potions >= 1)
                                    {
                                        Console.WriteLine("1)Health potions: {0} (Restore 10 HP)", health_potions);
                                    }
                                    if (max_hp_potions >= 1)
                                    {
                                        Console.WriteLine("2)Max Hp Potions: {0} (Restores all health)", max_hp_potions);
                                    }
                                    if (level_up_potions >= 1)
                                    {
                                        Console.WriteLine("3)Level up potions: {0} (You Know wha they do!)", level_up_potions);
                                    }
                                    if (level_up_potions==0 && max_hp_potions==0 && health_potions == 0)
                                    {
                                        Console.WriteLine("Your Inventory is Empty Press Enter to return to battle!");
                                        Console.ReadLine();
                                        break;
                                    }
                                    Console.WriteLine("Press enter to Go back or Select a potion to use.");
                                    potion_choice = Console.ReadLine().ToUpper();
                                    if ((potion_choice == "H") || (potion_choice == "HEALTH POTION") || (potion_choice=="HEALTH POTIONS") || (potion_choice=="1"))
                                    {
                                        if (max_hp == hp)
                                        {
                                            Console.WriteLine("You Already Have Max Hp you idiot!");
                                            Console.WriteLine("Press enter to continue my glorious leader!");
                                            Console.ReadLine();
                                        }
                                        else if (health_potions >= 1)
                                        {
                                            Console.WriteLine("You use a Health potion and Restore 10 HP!");
                                            health_potions--;
                                            if (hp + 10 > max_hp)
                                            {
                                                hp = max_hp;
               
                                            }
                                            else
                                            {
                                                hp += 10;
                                            }
                                            Console.WriteLine("Press enter to continue my glorious leader!");
                                            Console.ReadLine();
                                            potion_used = true;
                                            break;
                                        }
                                        else
                                        {
                                            Console.WriteLine("You don't have any health potions left!");
                                            Console.WriteLine("Press enter to continue my glorious leader!");
                                            Console.ReadLine();
                                        }
                                    }
                                    else if ((potion_choice == "M") || (potion_choice == "MAX HP POTION") || (potion_choice=="MAX HP POTIONS") || (potion_choice=="2"))
                                    {
                                        if (max_hp == hp)
                                        {
                                            Console.WriteLine("You Already Have max health you idiot!");
                                            Console.WriteLine("Press enter to continue my glorious leader!");
                                            Console.ReadLine();
                                        }
                                        else if (max_hp_potions >= 1)
                                        {
                                            Console.WriteLine("You use a Max HP potion and Restore all HP");
                                            hp = max_hp;
                                            max_hp_potions--;
                                            Console.WriteLine("Press enter to continue my glorious leader!");
                                            Console.ReadLine();
                                            potion_used = true;
                                            break;
                                        }
                                        else
                                        {
                                            Console.WriteLine("You don't have any Max hp potions!");
                                            Console.WriteLine("Press enter to continue my glorious leader!");
                                            Console.ReadLine();
                                        }
                                    }
                                    else if ((potion_choice == "L") || (potion_choice == "LEVEL UP POTION") || (potion_choice=="LEVEL UP POTIONS") || (potion_choice=="3"))
                                    {
                                        if (level_up_potions >= 1)
                                        {
                                            player_level++;
                                            Console.WriteLine("{0} Level Up to Level {1} and recieve max HP", name, player_level);
                                            level_up_potions--;
                                            hp = max_hp;
                                            Console.WriteLine("Press enter to continue my glorious leader!");
                                            Console.ReadLine();
                                            potion_used = true;
                                            break;
                                        }
                                        else
                                        {
                                            Console.WriteLine("You don't have any Level up potions!");
                                            Console.WriteLine("Press enter to continue my glorious leader!");
                                            Console.ReadLine();
                                        }
                                    }
                                    else if ((potion_choice=="Q") || potion_choice == "QUIT" || potion_choice=="" || potion_choice==null)
                                    {
                                        Console.WriteLine("Press Enter to return!");
                                        Console.ReadLine();
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("What are you on about {0} Press enter and give me a proper command",name);
                                        Console.ReadLine();
                                    }
                                }
                            }
                            else if ((choice == "FIGHT") || (choice == "F") || run_fail_result==7 || potion_used==true || choice=="1")
                            {
                                if ((potion_used != true) || (choice=="FIGHT") || (choice=="F") || (run_fail_result!=7) || (choice=="1"))
                                {


                                    player_attack = player_damage.Next(0 + player_level, 5 + player_level);
                                    enemy_hp -= player_attack;
                                    Console.WriteLine("You attack the {0} and do {1} dammage {2}", enemy_names[result_choice], player_attack, name);
                                    if (player_attack == 4 + player_level)
                                    {
                                        Console.WriteLine("Critical Hit!!!!!!!!!!!!!!!!!!!!");
                                    }
                                    if (enemy_hp <= 0)
                                    {
                                        Console.WriteLine("{0} has defeated {1} well done!", name, enemy_names[result_choice]);
                                        gold_earned = enem_damage.Next(5, 20);
                                        gold += gold_earned;
                                        Console.WriteLine("You also found {0} Gold on the body making your total gold {1}", gold_earned, gold);
                                        Console.WriteLine("You Add this enemy to your killist its description Reads as follows\n{0}", enemy_descriptions[result_choice]);
                                        kills++;
                                        if (kills % 3 == 0)
                                        {
                                            Console.WriteLine("Congratulations {0} You have leveled up to level {1} you attack and hp has increased plus your hp has been restored!", name, player_level);
                                            player_level++;
                                            max_hp += 2;
                                            hp = max_hp;
                                            if (kills % 6 == 0)
                                            {
                                                Console.WriteLine("In Fear of you the Monsters have grown stronger!");
                                                enem_level++;
                                                Console.WriteLine("Press Enter to venture forth into the danger!");
                                                Console.ReadLine();
                                            }
                                        }
                                        Console.WriteLine("Press Enter to continue");
                                        Console.ReadLine();
                                        Console.Clear();
                                        break;

                                    }
                                    Console.WriteLine("Press Enter To continue");
                                    Console.ReadLine();
                                }
                            }
                            enem_attack = enem_damage.Next(0 + enem_level, enemy_max_damage[result_choice] + enem_level);
                            Console.WriteLine("{0} is prepairing to attack!", enemy_names[result_choice]);
                            Console.WriteLine("{0} attacks dealing {1} damage to you", enemy_names[result_choice], enem_attack);
                            hp -= enem_attack;
                            if (hp <= 0)
                            {
                                Console.WriteLine("You died in battle!");
                                break;
                            }
                            Console.WriteLine("Press Enter to Continue");
                            Console.ReadLine();
                        }
                    }
                    if ((go_to == "QUIT") || (go_to=="Q") || (hp == 0) || (run == true))//Checks if you wanna quit
                    {
                        break;
                    }
                    else if (go_to=="INVENTORY" || go_to == "I")
                    {
                        Console.WriteLine("Inventory");
                        Console.WriteLine(")-------(");
                        if (health_potions >= 1)
                        {
                            Console.WriteLine("Health potions: {0} (Restore 10 HP)", health_potions);
                        }
                        if (max_hp_potions >= 1)
                        {
                            Console.WriteLine("Max Hp Potions: {0} (Restores all health)", max_hp_potions);
                        }
                        if (level_up_potions >= 1)
                        {
                            Console.WriteLine("Level up potions: {0} (You Know wha they do!)", level_up_potions);
                        }
                        if (gold >= 1)
                        {
                            Console.WriteLine("Gold: {0} (Money!!!!!!!)", gold);
                        }
                        if (level_up_potions == 0 && max_hp_potions == 0 && health_potions == 0)
                        {
                            Console.WriteLine("Your Inventory is Empty!");
                        }
                        Console.WriteLine();
                    }
                    else if (((go_to == "NORTH") ||(go_to=="N")) && (north == true))//checks if you can move north 
                    {
                        mapspace -= 5;
                        Console.WriteLine("{0} Heads North", name);
                        break;
                    }
                    else if (((go_to == "SOUTH") ||(go_to=="S")) && (south == true))//checks if you can move south
                    {
                        mapspace += 5;
                        Console.WriteLine("{0} Heads South!", name);
                        break;
                    }
                    else if (((go_to == "EAST") || (go_to=="E")) && (east == true))//checks if you can move east
                    {
                        mapspace++;
                        Console.WriteLine("{0} Heads East!", name);
                        break;
                    }
                    else if (((go_to == "WEST") || (go_to=="W"))  && (west == true))//checks if you can move west
                    {
                        mapspace--;
                        Console.WriteLine("{0} Heads West!", name);
                        break;
                    }
                    else if ((go_to != "NORTH") && (go_to != "EAST") && (go_to != "SOUTH") && (go_to != "WEST") && (go_to!="N") && (go_to!="E") && (go_to!="S") && (go_to!="W"))//Checks if your talking rubbish
                    {
                        Console.WriteLine("{0} what the Hell are you on about tell your team where to go!", name);
                    }
                    else//if its not valid move
                    {
                        Console.WriteLine("{0}!!! That goes into the unmapped mystic lands! We can't breathe there, the air is too thick! We must stick in the mapped zone!", name);
                    }



                }
                if ((go_to == "QUIT") || (go_to=="Q") || (hp<=0))//if you pressed quit display leaving message
                {
                    Console.WriteLine("Goodbye {0} you were a truely amazing hero!",name);
                    if (hp <= 0)
                    {
                        Console.WriteLine("It is a shame you died however!");
                        Console.WriteLine("You Died however you took {0} enemies with you", kills);
                    }
                    else
                    {
                        Console.WriteLine("You bail out of your quest with {0} Monsters Defeated", kills);
                    }
                    Console.WriteLine("Press Enter to quit");
                    Console.ReadLine();
                    break;
                }

            }
            }
        }
    }
