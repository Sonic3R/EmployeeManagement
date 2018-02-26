namespace EmployeeManagement.Data.Entities
{
    public class Personna : GenericData
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Mobile { get; set; }

        public string Email { get; set; }

        public int PhoneExt { get; set; }

        public string Info { get; set; }

        public string Password { get; set; }

        public bool IsAdmin { get; set; }

        public Departments Department { get; set; }

        public Positions Position { get; set; }

        public WebUser User { get; set; }
    }
}
