﻿namespace Core.Entity.MusicStore
{
    public class Artist : IEntity
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }
    }
}