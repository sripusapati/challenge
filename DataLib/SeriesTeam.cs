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
    
    public partial class SeriesTeam
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SeriesTeam()
        {
            this.Matches = new HashSet<Match>();
            this.SeriesTeamPlayers = new HashSet<SeriesTeamPlayer>();
        }
    
        public int id { get; set; }
        public int SeriesId { get; set; }
        public string Name { get; set; }
        public string Logo { get; set; }
        public byte IsActive { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Match> Matches { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SeriesTeamPlayer> SeriesTeamPlayers { get; set; }
    }
}
