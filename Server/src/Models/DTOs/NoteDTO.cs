using System;
using System.Collections.Generic;
using System.Text;

namespace Models.DTOs;

public class NoteDTO
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
}