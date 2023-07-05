using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLayout.Models;

public class Note
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public User User { get; set; }
}