namespace StoryTeller.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Theme
    {
        public int ThemeID { get; set; }
        public Nullable<int> PirateID { get; set; }
        public Nullable<int> PrincessID { get; set; }
        public Nullable<int> AnimalID { get; set; }
    
        public virtual Animal Animal { get; set; }
        public virtual Pirate Pirate { get; set; }
        public virtual Princesse Princesse { get; set; }
    }
}
