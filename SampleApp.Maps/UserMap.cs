using FluentNHibernate.Mapping;
using SampleApp.Models;

namespace SampleApp.Maps
{
    public class UserMap : ClassMap<User>
    {
        public UserMap()
        {
            Schema("dbo");
            //Table("User");
            DynamicInsert();
            Id(x => x.Id).Column("UserId");
            Map(x => x.Name).Not.Nullable();
            Map(x => x.EmailAddress).Not.Nullable();
            Map(x => x.AddressLine1).Not.Nullable();
            Map(x => x.AddressLine2).Not.Nullable();
            Map(x => x.PostCode).Not.Nullable();
            Map(x => x.CreatedDate).Not.Nullable().Default("getdate()").Generated.Insert();
        }
    }
}
