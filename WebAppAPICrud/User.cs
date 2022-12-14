namespace WebAppAPICrud
{
    public class User
    {
        public int Id { get; set; }
        public string FullName { get; set; } 
        public string UserName { get; set; } 
        public string Email { get; set; }
        public string? City { get; set; } 
        public string Number { get; set; } 
        public int Age { get; set; }
        public string Gender { get; set; }
        public DateTime DataRegistration { get; set; } /*= DateTime.Now.ToString("MM/dd/yyyy");*/
    }
}
