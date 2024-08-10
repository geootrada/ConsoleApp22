using System;

namespace ConsoleApp22
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();

            const string CommandAttack = "1";
            const string CommandFireBall = "2";
            const string CommandBlast = "3";
            const string CommandHealing = "4";

            bool isFireBallExecuted = false;
            bool isHealingExecuted = true;

            int challengerHealth = random.Next(500, 1000);
            int challengerMana = random.Next(500, 1001);
            int challengerAttack = random.Next(50, 100);
            int challengerFireBall = 100;
            int challengerExposition = 250;
            int bossHealth = random.Next(1000, 1500);
            int bossAttack = random.Next(100, 150);
            int startChallengerHealth = challengerHealth;
            int startChallengerMana = challengerMana;

            Console.WriteLine($"Вы - претендент на место Босса, но его нужно победить в честном бою! \n" +
                $"Босс изначально сильнее, но у вас кроме обычной атаки есть три магических инструмента: \n" +
                $"{CommandAttack} - атака, определяется рандомно.\n" +
                $"{CommandFireBall} - Огненный шар, который тратит ману. Урон противнику {challengerFireBall} HP.\n" +
                $"{CommandBlast} - Взрыв,применяется только если был использован огненный шар. Урон противнику {challengerExposition} HP.\n" +
                $"{CommandHealing} - Исцеление. Восстанавливает здоровье и ману, но не больше их максимального значения. Используется только один раз.\n" +
                $"Не совершайте ошибок, иначе ход перейдет к Боссу. После вашего удара сразу идет атака противника");

            Console.WriteLine($"Бой с Боссом");
            Console.WriteLine($"Начальные значения: Босс - {bossHealth}HP, претендент - {challengerHealth}HP, {challengerMana}MP");

            while (challengerHealth > 0 && bossHealth > 0)
            {
                Console.WriteLine($"Выбирайте вариант своего хода");

                switch (Console.ReadLine())
                {
                    case CommandAttack:
                        bossHealth -= challengerAttack;
                        challengerHealth -= bossAttack;
                        break;

                    case CommandFireBall:
                        bossHealth -= challengerFireBall;
                        challengerHealth -= bossAttack;
                        challengerMana -= challengerFireBall;
                        isFireBallExecuted = true;
                        break;

                    case CommandBlast:
                        if (isFireBallExecuted == true)
                        {
                            bossHealth -= challengerExposition;
                            challengerHealth -= bossAttack;
                            isFireBallExecuted = false;
                        }
                        else
                        {
                            Console.WriteLine("Вы неправильно использовали заклинание, урона противнику нет, Босс нпносит ответный удар.");
                            challengerHealth -= bossAttack;
                        }
                        break;

                    case CommandHealing:
                        if (isHealingExecuted == true)
                        {
                            challengerHealth = startChallengerHealth;
                            challengerMana = startChallengerMana;
                            isHealingExecuted = false;
                        }
                        else
                        {
                            Console.WriteLine("Вы не можете больше использовать это заклинание, Боссс наносит ответный удар.");
                            challengerHealth -= bossAttack;
                        }
                        break;

                    default:
                        Console.WriteLine("Недопустимая команда, урона противнику нет, Босс нпносит ответный удар.");
                        challengerHealth -= bossAttack;
                        break;
                }

                Console.WriteLine($"Итоги раунда: Босс: {bossHealth}HP, претендент: {challengerHealth}HP, {challengerMana}MP");
            }

            Console.WriteLine("Итоги боя:");

            if (bossHealth <= 0)
            {
                Console.WriteLine("Вы победили!!! Вы теперь новый Босс!!!");
            }
            else if (challengerHealth <= 0)
            {
                Console.WriteLine("Вы проиграли, Босс остается на троне!");
            }
            else
            {
                Console.WriteLine("Ничья!!! Вы оба погибли!!");
            }

            Console.WriteLine("Бой окончен");
        }
    }
}
