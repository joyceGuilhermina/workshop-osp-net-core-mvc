﻿using System;


namespace ProjetoWebMvc.Services.Exceptions
{
    public class DbConcurrencyException : ApplicationException
    {
        public DbConcurrencyException(string message) : base(message)
        {
        } 
    }
}
