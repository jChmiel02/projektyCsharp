namespace Blog2024.Library.Models
{
    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Pseudonym { get; set; }

        public User(string firstName, string lastName, int age, string pseudonym)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Pseudonym = pseudonym;
        }

        public string GetFullName()
        {
            return $"{FirstName} {LastName}";
        }

        public string GetUserData()
        {
            return $"{FirstName} {LastName}, {Age} lat, Pseudonim: {Pseudonym}";
        }
    }
}
