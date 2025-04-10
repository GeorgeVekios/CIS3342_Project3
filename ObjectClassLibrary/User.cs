using System;

namespace ObjectClassLibrary
{
	public class User
	{
		private int userID;
		private string userType;
		private string firstName;
		private string lastName;
		private string username;
		private string password;
		private string email;
		private string phoneNum;
		private DateTime createdAt;
		private bool isVerified;
		private int securityRecord1;
		private int securityRecord2;
		private int securityRecord3;


		public int UserID
		{
			get { return userID; }
			set { userID = value; }
		}

		public string UserType
		{
			get { return userType; }
			set { userType = value; }
		}

		public string FirstName
		{
			get { return firstName; }
			set { firstName = value; }
		}

		public string LastName
		{
			get { return lastName; }
			set { lastName = value; }
		}

		public string Username
		{
			get { return username; }
			set { username = value; }
		}

		public string Password
		{
			get { return password; }
			set { password = value; }
		}

		public string Email
		{
			get { return email; }
			set { email = value; }
		}

		public string PhoneNum
		{
			get { return phoneNum; }
			set { phoneNum = value; }
		}

		public DateTime CreatedAt
		{
			get { return createdAt; }
			set { createdAt = value; }
		}

		public bool IsVerified
		{
			get { return isVerified; }
			set { isVerified = value; }
		}

		public int SecurityRecord1
		{
			get { return securityRecord1; }
			set { securityRecord1 = value; }
		}

        public int SecurityRecord2
        {
            get { return securityRecord2; }
            set { securityRecord2 = value; }
        }

        public int SecurityRecord3
        {
            get { return securityRecord3; }
            set { securityRecord3 = value; }
        }

        public User()
		{

		}

		public User(int userID, string userType, string firstName, string lastName, string password, string email, string phoneNum, DateTime createdAt, bool isVerified, int securityRecord1, int securityRecord2, int securityRecord3)
		{
			this.userID = userID;
			this.userType = userType;
			this.firstName = firstName;
			this.lastName = lastName;
			this.password = password;
			this.email = email;
			this.phoneNum = phoneNum;
			this.createdAt = createdAt;
			this.isVerified = isVerified;
			this.securityRecord1 = securityRecord1;
			this.securityRecord2 = securityRecord2;
			this.securityRecord3 = securityRecord3;
		}

		public User(string userType, string firstName, string lastName, string passwordHash, string email, string phoneNum, DateTime createdAt, bool isVerified, int securityRecord1, int securityRecord2, int securityRecord3)
		{
			this.userType = userType;
			this.firstName = firstName;
			this.lastName = lastName;
			this.passwordHash = passwordHash;
			this.email = email;
			this.phoneNum = phoneNum;
            this.createdAt = createdAt;
            this.isVerified = isVerified;
            this.securityRecord1 = securityRecord1;
            this.securityRecord2 = securityRecord2;
            this.securityRecord3 = securityRecord3;
        }
	}
}
