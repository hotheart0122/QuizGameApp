using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizLibrary
{
    public class QuizRepository
    {
        private List<QuizQuestion> _questionList = new List<QuizQuestion>();
        private static Random _randy = new Random();
        private static int nextId = 0;

        public List<QuizQuestion> GetQuestions()
        {
            return _questionList;
        }

        public List<QuizQuestion> GetQuestions(int maxNumberOfQuestions)
        {
            if (_questionList.Count == 0)
            {
                return _questionList;
            }

            //create a new list that will contain the number of questions
            //requested. THIS is the one we'll return. NOT the whole list!

            List<QuizQuestion> returnList = new List<QuizQuestion>();
                      
            for (int i = 0; i < maxNumberOfQuestions; i++)
            {
                //Idea1: Get the question at the random index in the list
                int myRandomNumber = _randy.Next(0, _questionList.Count);

                //Get the question from the whole list at the index
                //of the random number we just generated
                //Add that question to the returnList.
                returnList.Add(_questionList[myRandomNumber]);
            }
            return returnList; //The temporary list we created
        }

        public QuizQuestion GetQuestionById(int id)
        {
            return _questionList.Find(question => question.Id == id);
        }

        public void UpdateQuestion(QuizQuestion updateQuestion)
        {
            _questionList.RemoveAll(question => question.Id == updateQuestion.Id);
            _questionList.Add(updateQuestion);
        }

        public QuizQuestion GetQuestion()
        {
            return GetQuestions(1)[0];
        }

        public void AddQuestion(QuizQuestion newQuestion)
        {
            newQuestion.Id = nextId++;
            _questionList.Add(newQuestion);
        }

        public void DeleteQuestion(int id)
        {
            _questionList.RemoveAll(question => question.Id == id);
        }

        public void LoadSampleQuestions()
        {
            QuizQuestion q1 = new QuizQuestion
            {
                Category = "Test Question",
                QuestionType = "Multiple Choice",
                Content = "What color is the sky?",
                Answers = new List<QuizAnswer>
                {
                    new QuizAnswer
                    {
                        Id = 0,
                        Content = "Red",
                        IsCorrect = false
                    },
                    new QuizAnswer
                    {
                        Id = 1,
                        Content = "Blue",
                        IsCorrect = true
                    },
                    new QuizAnswer
                    {
                        Id = 2,
                        Content = "Purple",
                        IsCorrect = false
                    },
                    new QuizAnswer
                    {
                        Id = 3,
                        Content = "Green",
                        IsCorrect = false
                    }
                }
            };

            AddQuestion(q1);
        }
    }
}
