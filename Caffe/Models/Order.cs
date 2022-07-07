using System.Collections.Generic;

namespace Caffe.Models;

public class Order
{
    public int Id { get; set; }
    public string description { get; set; }
    public List<Burger> Burgers { get; }
}