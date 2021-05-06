using System;
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
                Console.WriteLine(question);
                while (true)
                {
                    var userAnswer = Console.ReadLine().Trim().ToLower();
                    if(userAnswer != answer)
                    {
                        if(letter<answer.Length-1)
                        {
                            Console.WriteLine("Не правильно... Вот подсказка:");
                            GiveHint(answer, letter);
                            Console.WriteLine(question);
                            letter++;
                        }
                        else
                        {
                            Console.WriteLine($"Никто не отгадал!\nПравильный ответ - {answer.ToUpper()}\n");
                            break;
                        }
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
        }
        static void GiveHint(string answer, int i)
        {
            Console.WriteLine($"{i + 1}-ая буква из {answer.Length} - {answer[i]}");
            var rightAnswer = answer.Substring(0, i+1).PadRight(answer.Length, '-');
            Console.WriteLine(rightAnswer);
            //Console.WriteLine(question);
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
