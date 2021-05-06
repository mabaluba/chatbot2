using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace chatbot2
{
    class Program
    {
        static void Main(string[] args)
        {
            var questionsAndAnswers = File.ReadAllLines("data.txt").Select(i => i.Split('|')).ToList();
            var score = 0;
            var questionsCount = questionsAndAnswers.Count;
            while(questionsAndAnswers.Count>0)
            {
                var questionAnswer = questionsAndAnswers[new Random().Next(questionsCount)];//QuestionAnswer(questionsAndAnswers);// вопрос-ответ
                var question = questionAnswer[0]; // попробовать сделать все методами ООП
                var answer = questionAnswer[1];
                var letter = 0;
                //var word = new string('_', answer.Length);
                while (true)
                {
                    Console.WriteLine(question);
                    var userAnswer = Console.ReadLine().Trim().ToLower();
                    if(userAnswer != answer)
                    {
                        Console.WriteLine("Не правильно... Дать подсказку? - да/нет:");
                        var hint = Console.ReadLine().Trim().ToLower();
                        if (hint != "да") continue;
                        if(letter<answer.Length-1)
                        {
                            GiveHint(answer, letter);
                            letter++;
                        }
                        else
                        {
                            Console.WriteLine($"Никто не отгадал!\nПравильный ответ - {answer.ToUpper()}\n");
                            break;
                        }
                        #region else
                        /*else
                        {
                            Console.WriteLine("Попробуешь ответить еще раз без подсказки? - да/нет:");
                            var tryAgain = Console.ReadLine().Trim().ToLower();
                            if (tryAgain != "да")
                            {
                                Console.WriteLine("Хочешь другой вопрос? - да/нет:");
                                var anotherQuestion = Console.ReadLine().Trim().ToLower();
                                if (anotherQuestion == "да") break;
                                else
                                {
                                    Console.WriteLine("Пока, до новых встречь!");
                                    Environment.Exit(0);
                                }
                            }
                        }*/
                        #endregion
                    }
                    else
                    {
                        score++;
                        Console.WriteLine($"\nПравильно!!!\nКоличество правильных ответов {score}.\nСледующий вопрос.\n");
                        break;
                    }
                }
                questionsAndAnswers.Remove(questionAnswer);
                questionsCount --;
                questionsAndAnswers.Add(questionAnswer);//добавляем удаленный вопрос в конец
                if (questionsCount <= 0)
                {
                    Console.WriteLine("Рассмотрены все вопросы викторины. Начинаем заново!\n");
                    questionsCount= questionsAndAnswers.Count;
                }
            }
            /*Console.WriteLine("Вы прошли всю векторину! Поздравляем!");
            Environment.Exit(0);*/
        }
        static void GiveHint(string answer, int i)
        {
            Console.WriteLine($"{i + 1}-ая буква из {answer.Length} - {answer[i]}");
            var rightAnswer = answer.Substring(0, i+1).PadRight(answer.Length, '-');
            Console.WriteLine(rightAnswer);
        }

        /*public static string UserAnswer()
        {
            var takeAnswer = Console.ReadLine().Trim().ToLower();
            return takeAnswer;
        }*/
        /*public static string[] QuestionAnswer(List<string[]> questionsAndAnswers)
        {
            return questionsAndAnswers[new Random().Next(questionsAndAnswers.Count)];
        }*/

/*        public static List<string[]> QuestionsAndAnswers()
        {
            return File.ReadAllLines("data.txt")
                    .Select(i => i.Split('|'))
                    .ToList();
        }*/
    }
}
