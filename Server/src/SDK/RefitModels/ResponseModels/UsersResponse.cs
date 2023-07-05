using System;
using System.Collections.Generic;
using System.Text;
using Models;
using Models.DTOs;

namespace SDK.RefitModels.ResponseModels;

public class UsersResponse
{
    public List<UserDTO> Users { get; set; }
}