﻿using System;

namespace DomainModel
{
    public class Presentation
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string ThumbNailUrl { get; set; }
        public User Creator { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
