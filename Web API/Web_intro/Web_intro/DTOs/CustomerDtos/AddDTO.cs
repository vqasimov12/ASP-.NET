namespace Web_intro.DTOs.CustomerDtos;

public record struct AddDTO
{
    public string CustomerId { get; set;}
    public string CustomerName { get; set;}
}