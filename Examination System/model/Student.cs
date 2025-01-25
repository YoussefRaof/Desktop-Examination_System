using Examination_System.model;
using System;

namespace Examination_System.Model
{
    public enum Gender
    {
        Male,
        Female
    }

    internal class Student : User
    {



        private string fname;
        private string lname;
        private string phone;
        private string address;
        private Gender gender;
        private string birthDate;
        private int trackId;
        private int adminId;
        private int ssn;

    



        public Student( ) { }

        public int SSN
        {
            get { return ssn; }
            set { ssn = value; }
        }
        public string FName
        {
            get { return fname; }
            set { fname = value; }
        }

        public string LName
        {
            get { return lname; }
            set { lname = value; }
        }
        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }

        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        public Gender Gender
        {
            get { return gender; }
            set { gender = value; }
        }

        public string BirthDate
        {
            get { return birthDate; }
            set { birthDate = value; }
        }

        public int TrackId
        {
            get { return trackId; }
            set { trackId = value; }
        }

        public int AdminId
        {
            get { return adminId; }
            set { adminId = value; }
        }
    }

}
