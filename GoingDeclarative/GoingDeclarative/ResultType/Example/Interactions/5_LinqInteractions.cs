using GoingDeclarative;
using GoingDeclarative.ResultType.Example.Domain;

using System.Collections.Generic;
using System.Linq;

namespace GoingDeclarative.ResultType.Example.Interactions;

public class LinqInteractions
{
    public static Result<string> GetUserName(int userId)
    {
        // method invocation approach
        Result<string> _ = Repository
            .GetUser(userId)
            .Select(user => user.Name);

        // linq expression
        Result<string> userName =
            from user in Repository.GetUser(userId)
            select user.Name;

        return userName;
    }

    public static Result<List<string>> GetFriendsUserNames(int userId)
    {
        // method invocation approach
        Result<List<string>> _ = Repository.GetUser(userId)
            .SelectMany(user => Repository.GetUserFriends(user))
            .Select(friends => friends.Select(friend => friend.Name).ToList());

        // linq expression
        Result<List<string>> friendNames =
            from user in Repository.GetUser(userId)
            from friends in Repository.GetUserFriends(user)
            select friends.Select(friend => friend.Name).ToList();

        return friendNames;
    }

    public static Result<bool> MarkAsFriends(int userId, int otherUserId)
    {
        // method invocation approach
        Result<bool> _ = Repository.GetUser(userId)
            .SelectMany(user => Repository.GetUser(otherUserId)
                .SelectMany(other => Repository.MarkAsFriends(user, other))
            );

        // linq expression
        Result<bool> markedAsFriends =
            from user in Repository.GetUser(userId)
            from other in Repository.GetUser(otherUserId)
            from response in Repository.MarkAsFriends(user, other)
            select response;

        return markedAsFriends;
    }

    public static Result<bool> Mark3AsFriends(
        int userId, int secondUserId, int thirdUserId)
    {
        // method invocation approach
        Result<bool> _ = Repository.GetUser(userId)
            .Where(user => user.Id != 0)
            .SelectMany(user => Repository.GetUser(secondUserId)
                .SelectMany(secondUser => Repository.GetUser(thirdUserId)
                    .SelectMany(thirdUser => Repository.MarkAsFriends(user, secondUser, thirdUser))
                )
            );

        // linq expression
        Result<bool> markedAsFriends =
           from user in Repository.GetUser(userId)
           where user.Id != 0
           from secondUser in Repository.GetUser(secondUserId)
           from thirdUser in Repository.GetUser(thirdUserId)
           from response in Repository.MarkAsFriends(user, secondUser, thirdUser)
           select response;

        return markedAsFriends;
    }
}
