using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using CompareUsers.Types;

namespace CompareUsers.Managers
{
    public static class UserManager
    {
        private static JsonSerializerOptions _jsonSerializerOptions = new()
        {
            PropertyNameCaseInsensitive = true,
            Converters =
            {
                new JsonStringEnumConverter(JsonNamingPolicy.CamelCase)
            }
        };

        public static IEnumerable<User> GetUsers(string json)
        {
            return JsonSerializer.Deserialize<IEnumerable<User>>(json, _jsonSerializerOptions) ?? [];
        }

        public static Tuple<List<User>, List<User>> GetInsertedUpdatedUsers(IEnumerable<User> existingUsers, IEnumerable<User> modifiedUsers)
        {
            // If a modified user id is 0, it is a new user.
            // Otherwise, compare all fields in the modified user against the matching existing user to check for a change.
            // Return a tuple of new and updated users.
            List<User> newUsers = [];
            List<User> updatedUsers = [];

            foreach (User user in modifiedUsers)
            {
                if (user.Id == "0")
                {
                    newUsers.Add(user);
                }
                else
                {
                    var existingUser = existingUsers.FirstOrDefault(u => u.Id == user.Id);
                    if (existingUser != null && !existingUser.Equals(user))
                    {
                        updatedUsers.Add(user);
                    }
                }
            }

            return new Tuple<List<User>, List<User>>(newUsers, updatedUsers);
        }

        private static bool AreUsersEqualByProperties(User user1, User user2)
        {
            if (user1 == null || user2 == null)
                return false;

            var properties = typeof(User).GetProperties();
            foreach (var property in properties)
            {
                var value1 = property.GetValue(user1);
                var value2 = property.GetValue(user2);

                if (!Equals(value1, value2))
                {
                    return false;
                }
            }

            return true;
        }
    }
}