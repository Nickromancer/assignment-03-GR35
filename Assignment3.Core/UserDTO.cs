namespace Assignment3.Core;

public record UserDTO(int Id, string Name, string Email);

public record UserCreateDTO([StringLength(100)]string Name, [EmailAddress, StringLength(100)]string Email);

public record UserUpdateDTO(int Id, [StringLength(100)]string Name, [EmailAddress, StringLength(100)]string Email);
