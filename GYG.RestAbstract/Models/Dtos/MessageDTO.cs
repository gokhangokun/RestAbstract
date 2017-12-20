﻿namespace GYG.RestAbstract.Models.DTOs
{
    public class MessageDto
    {
        public string Type { get; set; }

        public string Content { get; set; }

        public MessageDto(string content, string type)
        {
            Content = content;
            Type = type;
        }
    }
}
