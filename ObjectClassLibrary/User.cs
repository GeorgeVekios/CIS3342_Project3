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

		public User()
		{

		}

		public User(int userID, string userType, string firstName, string lastName, string password, string email)
		{
			this.userID = userID;
			this.userType = userType;
			this.firstName = firstName;
			this.lastName = lastName;
			this.password = password;
			this.email = email;
			this.phoneNum = phoneNum;
		}

		public User(string userType, string firstName, string lastName, string password, string email)
		{
			this.userType = userType;
			this.firstName = firstName;
			this.lastName = lastName;
			this.password = password;
			this.email = email;
			this.phoneNum = phoneNum;
		}
	}
}
