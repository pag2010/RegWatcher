﻿using RegWatcher.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace RegWatcher.Models.ViewModels
{
    public class TagModel
    {
        public int TagId { get; set; }
        public string Name { get; set; }

        public TagModel(Tag tag)
        {
            TagId = tag.TagId;
            Name = tag.Name;
        }
    }

}
