namespace OechsleTest.WebApi.Models
{
    public class Employee
    {
        public int id { get; set; }
        public string name { get; set; }
        public string document_number { get; set; }
        public decimal salary { get; set; }
        public int age { get; set; }
        public string profile { get; set; }
        public DateTime admission_date { get; set; }
    }
}