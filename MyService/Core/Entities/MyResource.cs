﻿using Core.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    public class MyResource : EntityBase
    {
        public int Id  { get; set; }
    
        
        public string Name { get; set; }
        
    
    }
}
