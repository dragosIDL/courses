
using GoingDeclarative;
using GoingDeclarative.ResultType.Example.Domain;

using System.Collections.Generic;
using System.Linq;

namespace GoingDeclarative.ResultType.Example.Interactions;

public class MatchInteractions
{
    public static string GetUserName(int userId)
    {
        Result<User> userResult = Repository.GetUser(userId);

        return userResult.Match(
            ok: user => user.Name,
            err: ex => "Invalid username");
    }

    public static List<string> GetFriendsUserNames(int userId)
    {
        Result<User> userResult = Repository.GetUser(userId);
        return userResult.Match(
            ok: user =>
            {
                Result<List<Friend>> friendsResult = Repository
                    .GetUserFriends(user);
                return friendsResult.Match(
                    ok: friends => friends.Select(friend => friend.Name).ToList(),
                    err: ex => new List<string>());
            },
            err: ex => new List<string>());
    }

    public static bool MarkAsFriends(int userId, int secondUserId)
    {
        return Repository.GetUser(userId).Match(
            ok: user => Repository.GetUser(secondUserId).Match(
                ok: otherUser => Repository.MarkAsFriends(user, otherUser).Match(
                    ok: result => result,
                    err: ex => false),
                err: ex => false),
            err: ex => false);
    }

    public static bool Mark3AsFriends(int userId, int secondUserId, int thirdUserId)
    {
        return Repository.GetUser(userId).Match(
            ok: user => Repository.GetUser(secondUserId).Match(
               ok: second => Repository.GetUser(thirdUserId).Match(
                    ok: third => Repository.MarkAsFriends(user, second, third).Match(
                        ok: result => result,
                        err: ex => false),
                    err: ex => false),
                err: ex => false),
            err: ex => false);
    }
}
