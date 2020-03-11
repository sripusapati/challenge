using ModelLib;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLib
{
    public class MemberDataModel
    {
        ChallengeEntities challengeEntities = new ChallengeEntities();

        public MemberModel AddMember(MemberModel member)
        {
            MemberModel memberModel = new MemberModel();

            using (ChallengeEntities challengeEntities = new ChallengeEntities())
            {
                var memberModelData = JsonConvert.DeserializeObject<Member>(JsonConvert.SerializeObject(member));
                challengeEntities.Members.Add(memberModelData);
                challengeEntities.SaveChanges();
                memberModel = JsonConvert.DeserializeObject<MemberModel>(JsonConvert.SerializeObject(memberModelData));
            }

            return memberModel;
        }
    }
}
