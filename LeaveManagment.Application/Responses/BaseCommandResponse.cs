﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LeaveManagment.Application.Responses
{
    public class BaseCommandResponse
    {
        public int Id { get; set; }
        public bool Success { get; set; }
        public List<string> Errors { get; set; }
        public string Message { get; set; }
    }
}
