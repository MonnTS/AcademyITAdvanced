namespace Caffe.Models;

public class Burger
{
    public int Id { get; set; }
    public string name { get; set; }
    public double price { get; set; }
    
    public Order Order { get; set; }
}