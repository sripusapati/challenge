//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataLib
{
    using System;
    using System.Collections.Generic;
    
    public partial class SeriesTeamPlayer
    {
        public int id { get; set; }
        public int SeriesId { get; set; }
        public int SeriesTeamsId { get; set; }
        public int PlayerId { get; set; }
        public byte IsActive { get; set; }
    
        public virtual Player Player { get; set; }
        public virtual Series Series { get; set; }
        public virtual SeriesTeam SeriesTeam { get; set; }
    }
}
