using System;

namespace SmmEvaApi.Models.User
{
  public class User
  {
    public Guid UserId { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
  }
}