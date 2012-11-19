namespace MvcEasyOrderSystem.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MvcEasyOrderSystem.Models.EOSystemContex>
    {
        public Configuration()
        {
            //��۰ʧ�s��Ʈw���}�C�p�G�W�[��Model�b��Ʈw������Table�w�g�s�b�|�X�{���D�A
            //�o�ɭ԰O�o���� Add-Migration �M����ح���UP()�MDown()�M��
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(MvcEasyOrderSystem.Models.EOSystemContex context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
