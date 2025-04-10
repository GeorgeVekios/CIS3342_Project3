using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectClassLibrary
{
    public class SecurityQuestion
    {
        private int securityQuestionID;
        private string questionText;

        public int SecurityQuestionID
        {
            get { return securityQuestionID; }
            set { securityQuestionID = value; }
        }

        public string QuestionText
        {
            get { return questionText; }
            set { questionText = value; }
        }

        public SecurityQuestion()
        {

        }

        public SecurityQuestion(string questionText)
        {
            QuestionText = questionText;
        }

        public SecurityQuestion(int securityQuestionID, string questionText)
        {
            SecurityQuestionID = securityQuestionID;
            QuestionText = questionText;
        }
    }
}
