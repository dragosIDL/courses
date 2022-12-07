
using GoingDeclarative;
using GoingDeclarative.ResultType.Example.Domain;

using System.Collections.Generic;
using System.Linq;

namespace GoingDeclarative.ResultType.Example.Interactions;

public static class ControlFlowInteractions
{
    public static string GetUserName(int userId)
    {
        Result<User> userResult = Repository.GetUser(userId);

        if (userResult is Result<User>.Ok ok)
        {
            return ok.Value.Name;
        }
        else
        {
            return "Invalid response";
        }
    }

    public static List<string> GetFriendsUserNames(int userId)
    {
        Result<User> userResult = Repository.GetUser(userId);
        if (userResult is Result<User>.Ok ok)
        {
            User user = ok.Value;

            Result<List<Friend>> friendsResult = Repository.GetUserFriends(user);

            if (friendsResult is Result<List<Friend>>.Ok okFriends)
            {
                List<Friend> friends = okFriends.Value;
                return friends.Select(friend => friend.Name).ToList();
            }
            else
            {
                return new List<string>();
            }

        }
        else
        {
            return new List<string>();
        }
    }
}
