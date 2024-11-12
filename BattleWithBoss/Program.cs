using System;

namespace BattleWithBoss
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string CommandBaseAttack = "1";
            const string CommandFireBall = "2";
            const string CommandExplosion = "3";
            const string CommandRegeneration = "4";
            const string CommandSurrender = "5";

            bool isWork = true;
            bool explosionCharge = false;
            string userCommand;
            string playerName;
            string enemyName = "Boss";
            Random random = new Random();
            int playerBaseAttack;
            int playerMinBaseAttack = 15;
            int playerMaxBaseAttack = 25;
            int fireBallAttack = 50;
            int fireBallMana = 50;
            int explosionAttack = 85;
            int regerationCount = 1;

            int enemyBaseAttack;
            int enemyMinBaseAttack = 10;
            int enemyMaxBaseAttack = 20;
            int playerMaxHP = 100;
            int playerHP = 100;
            int playerMaxMana = 100;
            int playerMana = 100;
            int enemyHP = 250;
            

            Console.Write("Input player name: ");
            playerName = Console.ReadLine();

            while (isWork)
            {
                Console.Clear();
                Console.SetCursorPosition(0,0); // 0 - right, 1 - down
                Console.WriteLine(playerName);
                Console.SetCursorPosition(0, 1);
                Console.WriteLine($"{playerHP} HP | {playerMana} Mana");

                Console.SetCursorPosition(70, 0);
                Console.WriteLine(enemyName);
                Console.SetCursorPosition(70, 1);
                Console.WriteLine($"{enemyHP} HP");

                Console.SetCursorPosition(35, 2);
                Console.WriteLine($"Base attack - {CommandBaseAttack}");
                Console.SetCursorPosition(35, 3);
                Console.WriteLine($"Fire ball - {CommandFireBall}");
                Console.SetCursorPosition(35, 4);
                
                if(explosionCharge == true)
                {
                    Console.WriteLine($"Explosion - {CommandExplosion} |CHARGED!|");
                }
                else
                {
                    Console.WriteLine($"Explosion - {CommandExplosion} |UNCHARGED!|");
                }
                Console.SetCursorPosition(35, 5);
                Console.WriteLine($"Regeneration HP and mana - {CommandRegeneration} |{regerationCount} charges|");
                Console.SetCursorPosition(35, 6);
                Console.WriteLine($"Surrender - {CommandSurrender}");

                if(playerHP <= 0 && enemyHP <= 0)
                {
                    Console.WriteLine("DRAW");
                    Console.ReadKey();
                    isWork = false;
                    break;
                }
                else if (playerHP <= 0)
                {
                    Console.WriteLine($"{playerName} died\nGAME OVER");
                    Console.ReadKey();
                    isWork = false;
                    break;
                }
                else if (enemyHP <= 0)
                {
                    Console.WriteLine($"{enemyName} died\n{playerName} WIN!!!");
                    Console.ReadKey();
                    isWork = false;
                    break;
                }

                Console.Write("Input command: ");
                userCommand = Convert.ToString(Console.ReadLine());

                switch(userCommand)
                {
                    case CommandBaseAttack:
                        playerBaseAttack = random.Next(playerMinBaseAttack,playerMaxBaseAttack);
                        enemyHP -= playerBaseAttack;
                        Console.WriteLine($"{playerName} use base attack, {enemyName} get -{playerBaseAttack}HP");

                        enemyBaseAttack = random.Next(enemyMinBaseAttack, enemyMaxBaseAttack);
                        playerHP -= enemyBaseAttack;
                        Console.WriteLine($"{enemyName} use base attack, {playerName} get -{enemyBaseAttack}HP");
                        Console.ReadKey();
                        break;

                    case CommandFireBall:
                        if (playerMana >= fireBallMana)
                        {
                            enemyHP -= fireBallAttack;
                            playerMana -= fireBallMana;
                            Console.WriteLine($"{playerName} use fire ball, {enemyName} get -{fireBallAttack}HP");

                            enemyBaseAttack = random.Next(enemyMinBaseAttack, enemyMaxBaseAttack);
                            playerHP -= enemyBaseAttack;
                            Console.WriteLine($"{enemyName} use base attack, {playerName} get -{enemyBaseAttack}HP");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("Not enough mana");

                            enemyBaseAttack = random.Next(enemyMinBaseAttack, enemyMaxBaseAttack);
                            playerHP -= enemyBaseAttack;
                            Console.WriteLine($"{enemyName} use base attack, {playerName} get -{enemyBaseAttack}HP");
                            Console.ReadKey();
                        }
                        explosionCharge = true;
                        break;

                    case CommandExplosion:
                        if(explosionCharge == true)
                        {
                            enemyHP -= explosionAttack;
                            explosionCharge = false;
                            Console.WriteLine($"{playerName} use explosion!, {enemyName} get -{explosionAttack}HP");

                            enemyBaseAttack = random.Next(enemyMinBaseAttack, enemyMaxBaseAttack);
                            playerHP -= enemyBaseAttack;
                            Console.WriteLine($"{enemyName} use base attack, {playerName} get -{enemyBaseAttack}HP");
                            
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine($"{playerName} use explosion!, but is not charged. No effects.");

                            enemyBaseAttack = random.Next(enemyMinBaseAttack, enemyMaxBaseAttack);
                            playerHP -= enemyBaseAttack;
                            Console.WriteLine($"{enemyName} use base attack, {playerName} get -{enemyBaseAttack}HP");

                            Console.ReadKey();
                        }
                        break;

                    case CommandRegeneration:
                        if(regerationCount > 0)
                        {
                            playerHP = playerMaxHP;
                            playerMana = playerMaxMana;
                            regerationCount--;
                            Console.WriteLine($"{playerName} use regeneration!, HP and mana has been restored");

                            enemyBaseAttack = random.Next(enemyMinBaseAttack, enemyMaxBaseAttack);
                            playerHP -= enemyBaseAttack;
                            Console.WriteLine($"{enemyName} use base attack, {playerName} get -{enemyBaseAttack}HP");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine($"{playerName} use regeneration!, no effects.");

                            enemyBaseAttack = random.Next(enemyMinBaseAttack, enemyMaxBaseAttack);
                            playerHP -= enemyBaseAttack;
                            Console.WriteLine($"{enemyName} use base attack, {playerName} get -{enemyBaseAttack}HP");
                            Console.ReadKey();
                        }
                        
                        break;

                    case CommandSurrender:
                        Console.WriteLine("You surrender!\nGAME OVER");
                        Console.ReadKey();
                        isWork = false;
                        break;

                    default:
                        Console.WriteLine("The command was not found");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}
