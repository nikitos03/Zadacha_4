using System;
using System.Threading;

namespace ЕНГ_Task_04
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            int healthspider = rnd.Next(15000, 20000);
            int damagespider;
            int healthplayer = rnd.Next(15000, 15000);
            int manaplayer = rnd.Next(20000, 31000);
            bool startGame = true;
            string castspell;

            Console.WriteLine("Игра - Победи БОССА \n" +
                "Воспользуйся следующими умениями: \n" +
                "Церрандор атакует приготовьтесь к бою\n \nВыберите заклинания для атаки или лечения: \n" +
                "1. Разряд - Наносит 820 урона текущему противнику.Расходует 36 маны.\n" +
                "2. Потоки света - Востанавливает игроку  2000 здоровья, отнимает 67 единиц маны.\n" +
                "3. Луч тьмы - Удар наносит 100 урона, отнимает 50 единиц маны.\n" +
                "4. Ледяная буря - Каменный дождь  наносит 35 урона каждую секунду, отнимает 120 единиц маны.\n");

            while (startGame)
            {
                damagespider = rnd.Next(538, 761);
                Console.WriteLine($"\nСтатистика Церрандора: \n Здоровье: {healthspider} , Урон: {damagespider} \n\nСтатистика игрока: \n Здоровье: {healthplayer} , Мана: {manaplayer} \n");
                Console.Write("Введите заклинание: ");
                castspell = Console.ReadLine();
                if (manaplayer <= 15)
                {
                    startGame = false;
                    Console.WriteLine("\nИгра окончена, недостаточно маны для продолжения битвы");
                }
                else if (healthspider <= 0)
                {
                    startGame = false;
                    Console.WriteLine("\nЦеррандор погиб");
                }
                else if (healthplayer <= 0)
                {
                    startGame = false;
                    Console.WriteLine("\nИгрок погиб");
                }
                else
                {
                    switch (castspell)
                    {
                        case "Разряд":
                            if (manaplayer >= 36)
                            {
                                healthspider -= 820;
                                Console.WriteLine("\nЦеррандор потерял 820 единиц здоровья");
                                manaplayer -= 36;
                                healthplayer -= damagespider;
                                Console.Write($"\nЦеррандор атаковал, игрок потерял {damagespider} здоровья\n");
                            }
                            else
                            {
                                Console.WriteLine("\nУ вас не достаточно маны!");
                            }
                            break;
                        case "Потоки света":
                            if (manaplayer >= 67)
                            {
                                manaplayer -= 67;
                                healthplayer += 2000;
                                Console.WriteLine($"\nВаше текущее здоровье равно: {healthplayer}");
                            }
                            else if (healthplayer >= 349)
                            {
                                Console.WriteLine("\nУ вас полный запас здоровья");
                            }
                            else
                            {
                                Console.WriteLine("\nУ вас не достаточно маны!");
                            }
                            break;
                        case "Луч тьмы":
                            if (manaplayer >= 50)
                            {
                                Console.WriteLine("\nЦеррандор потерял 2500 единиц здоровья");
                                healthspider -= 2500;
                                manaplayer -= 50;
                                healthplayer -= damagespider;
                                Console.Write($"\nЦеррандор выпустил скелетов которые нанесли {damagespider} урона\n");
                            }
                            else
                            {
                                Console.WriteLine("\nУ вас не достаточно маны!");
                            }
                            break;
                        case "Ледяная буря":
                            if (manaplayer >= 120)
                            {
                                int led = 0;
                                for (int i = 1; i < 8; i++)
                                {
                                    led += 1000;
                                    Thread.Sleep(1000);
                                    healthspider -= 1000;
                                    Console.Write($"Атака каменным дождем наносит урон Церрандору {led}:  \nПродолжительность атаки {i} секунды");
                                    Console.WriteLine();
                                }
                                Console.WriteLine("\nЦеррандор потерял после атаки 5000 единиц здоровья");
                                manaplayer -= 40;
                            }
                            else
                            {
                                Console.WriteLine("\nУ вас не достаточно маны!");
                            }
                            break;
                        default:
                            Console.WriteLine($"\nВам незнакомо {castspell} это заклинание");
                            break;
                    }

                }
            }
        }
    }
}
