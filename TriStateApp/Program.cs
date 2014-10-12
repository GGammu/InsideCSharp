using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace TriStateApp
{
    class TriState
    {
        public enum TriStateValue
        {
            Null = -1,
            False = 0,
            True = 1
        }

        protected TriStateValue value;

        public TriState(TriStateValue value)
        {
            this.value = value;
        }

        public static implicit operator TriState(bool value)
        {
            if (true == value)
            {
                return new TriState(TriStateValue.True);
            }
            else
            {
                return new TriState(TriStateValue.False);
            }
        }

        public override string ToString()
        {
            String value;

            switch (this.value)
            {
                case TriStateValue.Null:
                    value = "[No Value]";
                    break;
                case TriStateValue.False:
                    value = "No";
                    break;
                case TriStateValue.True:
                    value = "Yes";
                    break;
                default:
                    throw new Exception("Invalid Value");
            }

            return value;
        }
    }

    class FormQuestion
    {
        String question;
        public String Question
        {
            get
            {
                return question;
            }
        }

        TriState answer;

        public TriState Answer
        {
            get
            {
                return answer;
            }
            set
            {
                answer = value;
            }
        }

        public FormQuestion(String question)
        {
            this.question = question;
            this.answer = new TriState(TriState.TriStateValue.Null);
        }
    }

    class Form
    {
        private ArrayList formQuestions;

        public Form()
        {
            formQuestions = new ArrayList();
            formQuestions.Add(new FormQuestion("Are you sick?"));
            formQuestions.Add(new FormQuestion("How old are you?"));
            formQuestions.Add(new FormQuestion("Are you tired of these questions?"));
        }

        public void AskQuestions()
        {
            Console.WriteLine("\n*** QUESTIONNAIRE ***");
            foreach (FormQuestion question in formQuestions)
            {
                Console.Write("{0}", question.Question);
                question.Answer = GetResponse();
            }
        }

        static public TriState GetResponse()
        {
            TriState response = new TriState(TriState.TriStateValue.Null);

            String valueEntered = Console.ReadLine();

            if (1 == valueEntered.Length)
            {
                valueEntered = valueEntered.ToUpper();
                Char ch = Convert.ToChar(valueEntered.Substring(0, 1));

                if ('Y' == ch)
                {
                    response = true;
                }
                else
                {
                    response = false;
                }
            }

            return response;
        }

        public void DisplayAnswers()
        {
            Console.WriteLine("\n*** ANSWERS ***");
            foreach (FormQuestion question in formQuestions)
            {
                Console.WriteLine("{0} {1}", question.Question, question.Answer);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Form form = new Form();
            form.AskQuestions();
            form.DisplayAnswers();
            Console.ReadLine();
        }
    }
}
