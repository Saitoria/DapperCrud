namespace DapperCrud.Models
{
    public class Teacher
    {
        public int TeacherId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public char Gender {  get; set; }    
        public DateTime Date {  get; set; } 
        public string ContactNumber { get; set; }
        public string Email {  get; set; }
        public string Country { get; set; }
    }
}
