﻿namespace CleanTemplate.Application.Core;

    public class BadRequestException : ApplicationException
    {
        public BadRequestException(string message) : base(message)
        {
        }
    }
