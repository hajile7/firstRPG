//Welcome & getting user's character's name
Console.WriteLine("Welcome to the RPG battler");
Console.WriteLine("Please enter your character's name");
string name = Console.ReadLine().Trim();

//character starting attributes
int damageCounter = 0;
int charDamage = getRandom();
int charHealth = 100;
int charGold = 0;

//enemy attributes
int enemyHealth = 20;
int enemyAttack = getRandomEnemy();
int enemyLevel = 0;

//battle loop
Console.WriteLine("The battle begins!");
while (charHealth > 0)
{
    //damage upgrades here. This seems inefficient but is all I could come up with for now
    if (damageCounter == 0)
    {
        charDamage = getRandom();
    }
    else if (damageCounter == 1)
    {
        charDamage = getRandom1();
    }
    else if (damageCounter == 2)
    {
        charDamage = getRandom2();
    }
    else if (damageCounter == 3)
    {
        charDamage = getRandom3();
    }
    else if (damageCounter == 4)
    {
        charDamage = getRandom4();
    }
    //same deal for enemy damage
    if (enemyLevel == 0)
    {
        enemyAttack = getRandomEnemy();
    }
    else if (enemyLevel == 1) 
    {
        enemyAttack = getRandomEnemy1();
    }
    else if (enemyLevel == 2)
    {
        enemyAttack = getRandomEnemy2();
    }
    else if (enemyLevel == 3) 
    { 
        enemyAttack = getRandomEnemy3();
    }
    else if (enemyLevel == 4)
    {
        enemyAttack = getRandomEnemy4();
    }
    //regular turn
    //character crit check
    int crit = getRandomCrit();
    Console.ForegroundColor = ConsoleColor.Green;
    if (crit == 10)
    {
        Console.WriteLine($"{name} attacked the enemy for {charDamage * 2} damage. It was a critical hit!");
        enemyHealth -= (charDamage * 2);
    } 
    else
    {
        Console.WriteLine($"{name} attacked the enemy for {charDamage} damage.");
        enemyHealth -= charDamage;
    }
    Console.ResetColor();
    if (enemyHealth <= 0) //if enemy was defeated
    {
        Console.ResetColor();
        charGold += 5; 
        enemyLevel++;
        Console.WriteLine("Enemy's health: 0");
        Console.WriteLine($"You've defeated the enemy. Enemies have grown stronger. You now have {charGold} gold. Would you like to enter the store? y/n"); //victory message + shop prompt
        string shopChoice = Console.ReadLine().ToLower().Trim();
        if (shopChoice == "y")
        { //shop information
            Console.WriteLine("Item Shop");
            Console.WriteLine("=========");
            Console.WriteLine("Healing Potion (5 Gold): Restores 10 health");
            Console.WriteLine("Damage Upgrade (10 Gold): Attack +3");
            Console.WriteLine("Type 'healing' to purchase a healing potion or 'damage' to purcahse a damage upgrade. To continue without purchasing anything, type 'exit'.");
            string shopPurhase = Console.ReadLine().ToLower().Trim();
            //shop choices
            if (shopPurhase == "exit")
            {
                Console.WriteLine($"Exiting shop. You still have {charGold} gold.");
            }
            else if (shopPurhase == "healing")
            {
                charGold -= 5;
                charHealth += 15;
                Console.WriteLine($"You have restored 15 health! You now have {charHealth} health left. Gold left: {charGold}");
            }
            else if (shopPurhase == "damage")
            {
                charGold -= 10;
                damageCounter++;
                Console.WriteLine($"You've increased your averge damage by 3! Gold left: {charGold}");
            }
        }
        if (enemyLevel == 1) //enemy health reset which gets progressively more difficult
        {
            enemyHealth = 25;
        }
        else if (enemyLevel == 2)
        {
            enemyHealth = 35;
        }
        else if (enemyLevel == 3)
        {
            enemyHealth = 50;
        }
        else if (enemyLevel == 4)
        {
            enemyHealth = 70;
        }
    }
    Console.WriteLine($"Enemy health: {enemyHealth}"); //if enemy was not defeated ("regular" turn continues)
    crit = getRandomCrit();
    Console.ForegroundColor = ConsoleColor.Red;
    if (crit == 10) //enemy crit check
    {
        Console.WriteLine($"The enemy struck you for {enemyAttack * 2} damage. It was a critical hit!");
        charHealth -= (enemyAttack * 2);
    }
    else
    {
        Console.WriteLine($"The enemy struck you for {enemyAttack} damage.");
        charHealth -= enemyAttack;
    }
    Console.ResetColor();
    Console.WriteLine($"Your health: {charHealth}");
        if (charHealth <= 0) //if character was defeated
        {
            Console.WriteLine("You died.");
            break;
        }

}

// starting methods for initial character and enemy damage
static int getRandom()
{
    Random random = new Random();
    return random.Next(10, 20);
}
static int getRandomEnemy()
{
    Random random = new Random();
    return random.Next(5, 15);
}

//Method for deciding crits
static int getRandomCrit()
{
    Random random = new Random();
    return random.Next(1, 11);
}

//scaling damage for character
static int getRandom1()
{
    Random random = new Random();
    return random.Next(13, 23);
}
static int getRandom2()
{
    Random random = new Random();
    return random.Next(16, 26);
}
static int getRandom3()
{
    Random random = new Random();
    return random.Next(19, 29);
}
static int getRandom4()
{
    Random random = new Random();
    return random.Next(22, 32);
}

//scaling damage for enemy
static int getRandomEnemy1()
{
    Random random = new Random();
    return random.Next(7, 17);
}
static int getRandomEnemy2()
{
    Random random = new Random();
    return random.Next(9, 19);
}
static int getRandomEnemy3()
{
    Random random = new Random();
    return random.Next(11, 21);
}
static int getRandomEnemy4()
{
    Random random = new Random();
    return random.Next(13, 23);
}
