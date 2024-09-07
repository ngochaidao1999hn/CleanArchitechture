namespace CleanArchitechture.Domain.Entities
{
    public class User : Entity
    {
        public User()
        {
            
        }
        private protected User(
            int id,
            string name,
            string bod,
            string userName,
            string password,
            DateTime createdDate,
            DateTime updatedDate
            )
        {
            Id = id;
            Name = name;
            BirthOfDate = bod;
            UserName = userName;
            Password = password;
            CreateDate = createdDate;
            UpdateDate = updatedDate;
        }
        public string Name { get; private set; }
        public string BirthOfDate { get; private set; }
        public string UserName { get; private set; }
        public string Password { get; private set; }

        public User Create(
            string name,
            string bod,
            string userName,
            string password)
        {
            var createdDate = DateTime.UtcNow;
            var updatedDate = DateTime.UtcNow;
            var user = new User(0,name, bod, userName, password, createdDate, updatedDate);
            return user;
        }

        public User Update(
            int id,
            string name,
            string bod,
            string userName,
            string password
            )
        {
            var updatedDate = DateTime.UtcNow;
            return new User(id, name, bod, userName, password, CreateDate, updatedDate);
        }
    }
}
