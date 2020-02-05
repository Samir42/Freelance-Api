namespace Freelancer.Domain.Entities {
    public class Client {
        public int Id { get; set; }
        public int UserForeignKey { get; set; }
        public string CompanyName { get; set; }
        public User User { get; set; }
    }
}
