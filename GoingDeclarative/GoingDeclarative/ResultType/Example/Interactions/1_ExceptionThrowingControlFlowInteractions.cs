
using GoingDeclarative;
using GoingDeclarative.ResultType.Example.Domain;

using System;
using System.Collections.Generic;
using System.Linq;

namespace GoingDeclarative.ResultType.Example.Interactions;

public static class ExceptionThrowingControlFlowInteractions
{
    public static string GetUserName(int userId)
    {
        try
        {
            User user = ExceptionThrowingRepository.GetUser(userId);
            return user.Name;
        }
        catch (MissingUser)
        {
            return "Invalid response";
        }
    }

    public static List<string> GetFriendsUserNames(int userId)
    {
        try
        {
            User user = ExceptionThrowingRepository.GetUser(userId);

            var friends = ExceptionThrowingRepository.GetUserFriends(user);
            return friends.Select(friend => friend.Name).ToList();
        }
        catch (MissingFriend)
        {
            return new List<string>();
        }
        catch (MissingUser)
        {
            return new List<string>();
        }
    }

    public static bool MarkAsFriends(int userId, int secondUserId)
    {
        try
        {
            User user = ExceptionThrowingRepository.GetUser(userId);

            try
            {
                User secondUser = ExceptionThrowingRepository.GetUser(secondUserId);
                
                // might throw another exception that is handled at a different level.
                return ExceptionThrowingRepository.MarkAsFriends(user, secondUser);
            }
            catch (MissingUser)
            {
                return false;
            }
        }
        catch (MissingUser)
        {
            return false;
        }
    }
}
