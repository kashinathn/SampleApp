using FluentNHibernate.Mapping;
using SampleApp.Models;

namespace SampleApp.Maps
{
    public class UserMap : ClassMap<User>
    {
        public UserMap()
        {
            //Schema("dbo");
            //Table("User");
            DynamicInsert();
            Id(x => x.Id).Column("UserId");
            Map(x => x.Name);
            Map(x => x.EmailAddress);
            Map(x => x.AddressLine1);
            Map(x => x.AddressLine2);
            Map(x => x.PostCode);
            Map(x => x.CreatedDate);
        }
    }
}
