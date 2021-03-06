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
    
    public partial class Match
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Match()
        {
            this.Match_bets = new HashSet<Match_bets>();
            this.MatchBets = new HashSet<MatchBet>();
        }
    
        public int id { get; set; }
        public int SeriesId { get; set; }
        public int SeriesTeamId { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string GroundName { get; set; }
        public System.DateTime StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public byte IsActive { get; set; }
    
        public virtual Series Series { get; set; }
        public virtual SeriesTeam SeriesTeam { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Match_bets> Match_bets { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MatchBet> MatchBets { get; set; }
    }
}
