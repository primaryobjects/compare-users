using System.Text.Json.Serialization;

namespace CompareUsers.Types
{
    public class User
    {
        [JsonPropertyName("_id")]
        public string Id { get; set; } = string.Empty;
        public int Index { get; set; }
        public bool IsActive { get; set; }
        public string Balance { get; set; } = string.Empty;
        public int Age { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        public string Company { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;

        public User()
        {
            Id = Guid.NewGuid().ToString();
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Name, Email);
        }

        public override bool Equals(object? obj)
        {
            if (obj is User otherUser)
            {
                return Id == otherUser.Id &&
                       Index == otherUser.Index &&
                       IsActive == otherUser.IsActive &&
                       Balance == otherUser.Balance &&
                       Age == otherUser.Age &&
                       Name == otherUser.Name &&
                       Gender == otherUser.Gender &&
                       Company == otherUser.Company &&
                       Email == otherUser.Email &&
                       Phone == otherUser.Phone &&
                       Address == otherUser.Address;
            }

            return false;
        }
    }
}