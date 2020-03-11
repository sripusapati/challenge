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
    
    public partial class MatchBet
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MatchBet()
        {
            this.MatchChallenges = new HashSet<MatchChallenge>();
        }
    
        public int Id { get; set; }
        public int MatchId { get; set; }
        public int PlayerId { get; set; }
        public int BetId { get; set; }
        public int BetDetailsId { get; set; }
        public int MemberId { get; set; }
        public bool IsPrivate { get; set; }
        public int Amount { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public System.DateTime ModifiedDate { get; set; }
    
        public virtual BetDetail BetDetail { get; set; }
        public virtual BetType BetType { get; set; }
        public virtual Match Match { get; set; }
        public virtual Member Member { get; set; }
        public virtual Player Player { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MatchChallenge> MatchChallenges { get; set; }
    }
}