
using GoingDeclarative;

using System;
using System.Collections.Generic;
using System.Linq;

namespace GoingDeclarative.ResultType.Example.Domain;

public class ExceptionThrowingRepository
{
    public static Friend GetFriend(int id, bool found = true)
    {
        return found
            ? new Friend(id, "Friend")
            : throw new MissingFriend();
    }

    public static User GetUser(int id, bool found = true)
    {
        return found
            ? new User(id, "User")
            : throw new MissingUser();
    }

    public static List<Friend> GetUserFriends(User user, bool found = true)
    {
        var friends = Enumerable.Range(0, 3).Select(i => GetFriend(i, found));
        return friends?.ToList() ?? new List<Friend>();
    }

    public static bool MarkAsFriends(User user, User other)
    {
        return true;
    }

    public static bool MarkAsFriends(User user, User second, User third)
    {
        return true;
    }
}


