using System;
using System.Collections;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace IEnumerableDemo
{
    class Exam:IEnumerable
    {
        public string Title { get; set; }
        public string Date { get; set; }
        public Question[] Questions { get; set; }

        public IEnumerator GetEnumerator()
        {
            //return this.Questions.GetEnumerator();
            return new ExamEnumerator(this.Questions);
        }
    }

    class ExamEnumerator : IEnumerator
    {  
        private Question[] questions { get; set; }
        private Question currentQuestion;
        private int currentindex;

        public ExamEnumerator(Question[] _questions)
        {
            this.questions = _questions;
            currentindex = -1;
        }
        public object Current { get
            {
                return currentQuestion;  } }

        public bool MoveNext()
        {
            //    if (++currentindex >= questions.Length) //All Record
            //        return false;
            //    else
            //        currentQuestion = questions[currentindex];
            //    return true;
            if (++currentindex >= questions.Length)
                return false;
            else
                if(currentindex%2==0) //Even Record Only
                 currentQuestion = questions[++currentindex];
            return true;


            //throw new NotImplementedException();
        }

        public void Reset()
        {
            currentindex = -1;
        }
    }
}
