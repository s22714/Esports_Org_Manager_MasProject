using Esports_Org_Manager.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTests
{
    public class BagTest
    {
        [Fact]
        public void CreateSuccessfullyTest()
        {
            Team t1 = new Team("wadawd","valo",DateTime.Now.AddDays(-20),null,12,"NA",6);
            Team t2 = new Team("gfg", "valo", DateTime.Now.AddDays(-14), null, 16, "NA", 6);
            Employee p1 = new Employee("adam", "ka","coc","email",new Adress("city","street",2),2332,AvailabilityStatus.available,null,null,null,null,20);
            Employee p2 = new Employee("henry", "pro", "kaka", "email2", new Adress("citds", "sttg", 3), 344, AvailabilityStatus.available, null, null, null, null, 23);

            Assert.Throws<ArgumentNullException>(() =>
            {
                new Membership(DateTime.Now.AddDays(-2),DateTime.Now.AddDays(3), null, p1);
                new Membership(DateTime.Now.AddDays(-2), DateTime.Now.AddDays(3), t1, null);

                new Employee(null, "ka", "coc", "email", new Adress("city", "street", 2), 2332, AvailabilityStatus.available, null, null, null, null, 20);
                new Employee("adam", null, "coc", "email", new Adress("city", "street", 2), 2332, AvailabilityStatus.available, null, null, null, null, 20);
                new Employee("adam", "ka", null, "email", new Adress("city", "street", 2), 2332, AvailabilityStatus.available, null, null, null, null, 20);
                new Employee("adam", "ka", "coc", null, new Adress("city", "street", 2), 2332, AvailabilityStatus.available, null, null, null, null, 20);
                new Employee("adam", "ka", "coc", "email", new Adress(null, "street", 2), 2332, AvailabilityStatus.available, null, null, null, null, 20);
                new Employee("adam", "ka", "coc", "email", new Adress("city", null, 2), 2332, AvailabilityStatus.available, null, null, null, null, 20);

                new Team(null, "valo", DateTime.Now.AddDays(-14), null, 16, "NA", 6);
                new Team("gfg", null, DateTime.Now.AddDays(-14), null, 16, "NA", 6);
                new Team("gfg", "valo", DateTime.Now.AddDays(-14), null, 16, null, 6);
            });
            Assert.Throws<ArgumentException>(() =>
            {
                new Employee("", "ka", "coc", "email", new Adress("city", "street", 2), 2332, AvailabilityStatus.available, null, null, null, null, 20);
                new Employee("adam", "", "coc", "email", new Adress("city", "street", 2), 2332, AvailabilityStatus.available, null, null, null, null, 20);
                new Employee("adam", "ka", "", "email", new Adress("city", "street", 2), 2332, AvailabilityStatus.available, null, null, null, null, 20);
                new Employee("adam", "ka", "coc", "", new Adress("city", "street", 2), 2332, AvailabilityStatus.available, null, null, null, null, 20);
                new Employee("adam", "ka", "coc", "email", new Adress("", "street", 2), 2332, AvailabilityStatus.available, null, null, null, null, 20);
                new Employee("adam", "ka", "coc", "email", new Adress("city", "", 2), 2332, AvailabilityStatus.available, null, null, null, null, 20);

                new Team("", "valo", DateTime.Now.AddDays(-14), null, 16, "NA", 6);
                new Team("gfg", "", DateTime.Now.AddDays(-14), null, 16, "NA", 6);
                new Team("gfg", "valo", DateTime.Now.AddDays(-14), null, 16, "", 6);
            });

            Membership m1 = new Membership(DateTime.Now.AddDays(-2), DateTime.Now.AddDays(3), t1, p1);

            Assert.Equal(p1, m1.employee);
            Assert.Equal(t1, m1.team);
            Assert.Contains(m1, p1.memberships);
            Assert.Contains(m1, t1.memberships);

            p1.RemoveMembership(m1);

            Assert.Null(m1.employee);
            Assert.Null(m1.team);
            Assert.DoesNotContain(m1, p1.memberships);
            Assert.DoesNotContain(m1, t1.memberships);

            Membership m2 = new Membership(DateTime.Now.AddDays(-2), DateTime.Now.AddDays(3), t1, p1);

            Assert.Equal(p1, m2.employee);
            Assert.Equal(t1, m2.team);
            Assert.Contains(m2, p1.memberships);
            Assert.Contains(m2, t1.memberships);
        }
    }
}
