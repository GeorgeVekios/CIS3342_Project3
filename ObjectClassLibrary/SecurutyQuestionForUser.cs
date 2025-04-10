using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectClassLibrary
{
    public  class SecurutyQuestionForUser
    {
        private int securityRecordID;
        private int userID;
        private int securityQuestionID;
        private string hashedAnswer;

        public int SecurityRecordID
        {
            get { return securityRecordID; }
            set { securityRecordID = value; }
        }

        public int UserID
        {
            get { return userID; }
            set { userID = value; }
        }

        public int SecurityQuestionID
        {
            get { return securityQuestionID; }
            set { securityQuestionID = value; }
        }

        public string HashedAnswer
        {
            get { return hashedAnswer; }
            set { hashedAnswer = value; }
        }

        public SecurutyQuestionForUser()
        {

        }

        public SecurutyQuestionForUser(int userID, int securityQuestionID, string hashedAnswer)
        {
            UserID = userID;
            SecurityQuestionID = securityQuestionID;
            HashedAnswer = hashedAnswer;
        }

        public SecurutyQuestionForUser(int securityRecordID, int userID, int securityQuestionID, string hashedAnswer)
        {
            SecurityRecordID = securityRecordID;
            UserID = userID;
            SecurityQuestionID = securityQuestionID;
            HashedAnswer = hashedAnswer;
        }
    }
}
