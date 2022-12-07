
using GoingDeclarative;

using System.Collections.Generic;
using System.Linq;

namespace GoingDeclarative.ResultType.Example.Domain;

public class Repository
{
    public static Result<Friend> GetFriend(int id, bool found = true)
    {
        return found
            ? Result.Ok(new Friend(id, "Friend"))
            : Result.Err<Friend>(new MissingFriend());
    }

    public static Result<User> GetUser(int id, bool found = true)
    {
        return found
            ? Result.Ok(new User(id, "User"))
            : Result.Err<User>(new MissingUser());
    }

    public static Result<List<Friend>> GetUserFriends(
        User user, bool found = true)
    {
        var friendResults = Enumerable
            .Range(0, 3)
            .Select(i => GetFriend(i, found));
        return friendResults.Traverse().Map(friends => friends.ToList());
    }

    public static Result<bool> MarkAsFriends(User user, User other)
    {
        return Result.Ok(true);
    }

    public static Result<bool> MarkAsFriends(User user, User second, User third)
    {
        return Result.Ok(true);
    }
}
