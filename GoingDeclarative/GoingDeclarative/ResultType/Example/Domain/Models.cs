using System;

namespace GoingDeclarative.ResultType.Example.Domain;

public record User(int Id, string Name);
public record Friend(int Id, string Name);


public class MissingUser : Exception { }
public class MissingFriend : Exception { }