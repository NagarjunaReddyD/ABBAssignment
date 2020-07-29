using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfaceBookStore;
using ModelBookStore;
namespace DLBookStore
{
   public class DLLogin : ILogin
    {
        TwinkleStoreEntities TBSEntities;
        public DLLogin()
        {
            TBSEntities = new TwinkleStoreEntities();
        }

        public bool LoginUser(string UserName, string Password)
        {
            var list = (from objLoginUsers in TBSEntities.Logins
                        where objLoginUsers.UserId== UserName && objLoginUsers.Password== Password
                        select objLoginUsers).ToList();
           if(list == null || list.Count==0)
            {
                return false;
            }
           
            return true;
        }

        //public void Register(ModelBookStore.Login objModellog)
        //{
        //    //Login objDLlogin = new Login()
        //    //{

        //    //   UserId=objModellog.UserId,
        //    //   Password=objModellog.Password


        //    //};
        //    UserDetail objUserDetail = new UserDetail()
        //    {
        //       // UserId= objModellog.UserDetails[0].UserId,
        //        FirstName = objModellog.UserDetails[0].FirstName,
        //        LastName = objModellog.UserDetails[0].LastName,

        //        EmailId = objModellog.UserDetails[0].EmailId,
        //        PhoneNumber = objModellog.UserDetails[0].PhoneNumber,
        //        DOB=objModellog.UserDetails[0].DOB,
        //        Address=objModellog.UserDetails[0].Address,
        //        state=objModellog.UserDetails[0].state,
        //        city=objModellog.UserDetails[0].city,
        //        Login= new Login { UserId= objModellog.UserId, Password= objModellog.Password }


        //    };
        //    //TBSEntities.Logins.Add(objDLlogin);
        //    //TBSEntities.SaveChanges();
        //    TBSEntities.UserDetails.Add(objUserDetail);
        //    TBSEntities.SaveChanges();
        //}


        public void Register(ModelBookStore.Login objModellog)
        {
          if(  objModellog.UserDetails==null)
            { 
            Login objDLlogin = new Login()
            {

                UserId = objModellog.UserId,
                Password = objModellog.Password


            };
                TBSEntities.Logins.Add(objDLlogin);
                TBSEntities.SaveChanges();
            }
            if (objModellog.UserDetails != null)
            { 
                UserDetail objUserDetail = new UserDetail()
            {
               
                FirstName = objModellog.UserDetails[0].FirstName,
                LastName = objModellog.UserDetails[0].LastName,

                EmailId = objModellog.UserDetails[0].EmailId,
                PhoneNumber = objModellog.UserDetails[0].PhoneNumber,
                DOB = objModellog.UserDetails[0].DOB,
                Address = objModellog.UserDetails[0].Address,
                state = objModellog.UserDetails[0].state,
                city = objModellog.UserDetails[0].city
                //Login = new Login { UserId = objModellog.UserId, Password = objModellog.Password }


            };

            
            TBSEntities.UserDetails.Add(objUserDetail);
            TBSEntities.SaveChanges();
            }
        }
        //public List<ModelBookStore.LoginUserRoles> Search(string UserName, string Password)
        //{
        //    var Loginlist = (from objLgoin in TBSEntities.Logins
        //                     join objUserDetails in TBSEntities.UserDetails on objLgoin.id equals objUserDetails.id
        //                     join objUserRole in TBSEntities.UserRoles on objLgoin.id equals objUserRole.UserId
        //                     join objRole in TBSEntities.Roles on objUserRole.RoleId equals objRole.id
        //                    where objLgoin.UserId == UserName && objLgoin.Password == Password
        //                     select new
        //                     {
        //                         LogId= objLgoin.id,
        //                         UserId=objLgoin.UserId,
        //                         FirstName=objUserDetails.FirstName,
        //                         LastName=objUserDetails.LastName,
        //                         RoleId=objRole.id,
        //                         RoleName=objRole.Name
                                
        //                     }).ToList();
        //   // select objLgoin.).ToList();

        //    ModelBookStore.LoginUserRoles ModleLoginObj;
        //    //= new ModelBookStore.Role();
        //    List<ModelBookStore.LoginUserRoles> objlist = new List<ModelBookStore.LoginUserRoles>();
        //    foreach (var item in Loginlist)
        //    {
        //        ModleLoginObj = new ModelBookStore.LoginUserRoles();
        //        ModleLoginObj.LogId = item.LogId;
        //        ModleLoginObj.UserId = item.UserId;
        //        ModleLoginObj.FirstName = item.FirstName;
        //        ModleLoginObj.LastName = item.LastName;
        //        ModleLoginObj.RoleId = item.RoleId;
        //        ModleLoginObj.RoleName = item.RoleName;


        //        objlist.Add(ModleLoginObj);

        //    }
        //    return objlist;
        //}
        public List<ModelBookStore.LoginUserRoles> Search(string UserName, string Password)
        {
            var Loginlist = (from objLgoin in TBSEntities.Logins
                            
                             join objUserRole in TBSEntities.UserRoles on objLgoin.id equals objUserRole.UserId into LogRoles

                             from LR in LogRoles.DefaultIfEmpty()

                             join objRole in TBSEntities.Roles on LR.RoleId equals objRole.id into LogUserRoles
                             //into LogRoleNames
                             from LUR in LogUserRoles.DefaultIfEmpty()

                             where objLgoin.UserId == UserName && objLgoin.Password == Password
                             select new
                             {
                                 LogId = objLgoin.id,
                                 UserId = objLgoin.UserId,


                                 RoleId = LUR.id.ToString() ,
                                 RoleName = LUR.Name

                             }).ToList();
           

            ModelBookStore.LoginUserRoles ModleLoginObj;
           
            List<ModelBookStore.LoginUserRoles> objlist = new List<ModelBookStore.LoginUserRoles>();
            foreach (var item in Loginlist)
            {
                ModleLoginObj = new ModelBookStore.LoginUserRoles();
                ModleLoginObj.LogId = item.LogId;
                ModleLoginObj.UserId = item.UserId;
                if(!String.IsNullOrEmpty(item.RoleId))
                {
                    ModleLoginObj.RoleId = Convert.ToInt32(item.RoleId);
                }
                
                ModleLoginObj.RoleName = item.RoleName;


                objlist.Add(ModleLoginObj);

            }
            return objlist;
        }

        public void Update(ModelBookStore.UserDetail objModelUserDetail)
        {
            UserDetail _SelectUserrow = TBSEntities.UserDetails.Where(x => x.id == objModelUserDetail.id).Select(x => x).FirstOrDefault();



            _SelectUserrow.FirstName = objModelUserDetail.FirstName;
            _SelectUserrow.LastName = objModelUserDetail.LastName;
            _SelectUserrow.PhoneNumber = objModelUserDetail.PhoneNumber;
            _SelectUserrow.EmailId = objModelUserDetail.EmailId;
            _SelectUserrow.Address = objModelUserDetail.Address;
            _SelectUserrow.DOB = objModelUserDetail.DOB;
            _SelectUserrow.city = objModelUserDetail.city;
            _SelectUserrow.state = objModelUserDetail.state;
            _SelectUserrow.IsMembership = objModelUserDetail.IsMembership;

            TBSEntities.SaveChanges();
            
        }
        public void Add(ModelBookStore.UserDetail objModelUserDetail)
        {
            //  UserDetail _SelectUserrow = TBSEntities.UserDetails.Where(x => x.id == objModelUserDetail.id).Select(x => x).FirstOrDefault();


            UserDetail objUserDetail = new UserDetail()
            {

                FirstName = objModelUserDetail.FirstName,
                LastName = objModelUserDetail.LastName,
                PhoneNumber = objModelUserDetail.PhoneNumber,
                EmailId = objModelUserDetail.EmailId,
                Address = objModelUserDetail.Address,
                DOB = objModelUserDetail.DOB,
                city = objModelUserDetail.city,
                state = objModelUserDetail.state,
                IsMembership = objModelUserDetail.IsMembership
            };
            TBSEntities.UserDetails.Add(objUserDetail);
            TBSEntities.SaveChanges();

        }
        public void Delete(ModelBookStore.UserDetail objModelUserDetail)
        {
            UserDetail _SelectRoleToDeleteRow = TBSEntities.UserDetails.Where(x => x.id == objModelUserDetail.id).Select(x => x).FirstOrDefault();

            TBSEntities.UserDetails.Remove(_SelectRoleToDeleteRow);
            TBSEntities.SaveChanges();
        }
        public List<ModelBookStore.UserDetail> Load()
        {
            var UserDetaillist = (from objUserDetail in TBSEntities.UserDetails

                                select objUserDetail
                         //select new Role { id = objItems.id, UserId = objItems.Name }
                         ).ToList();

            ModelBookStore.UserDetail ModlelUserDetailObj;
            List<ModelBookStore.UserDetail> objlist = new List<ModelBookStore.UserDetail>();
            foreach (var Useritem in UserDetaillist)
            {
                ModlelUserDetailObj = new ModelBookStore.UserDetail();
                ModlelUserDetailObj.id = Useritem.id;
                ModlelUserDetailObj.FirstName = Useritem.FirstName;
                ModlelUserDetailObj.LastName = Useritem.LastName;
                ModlelUserDetailObj.DOB = Convert.ToDateTime(Useritem.DOB);
                ModlelUserDetailObj.PhoneNumber = Useritem.PhoneNumber;
                ModlelUserDetailObj.EmailId = Useritem.EmailId;
                ModlelUserDetailObj.Address = Useritem.Address;
                ModlelUserDetailObj.city = Useritem.city;
                ModlelUserDetailObj.state = Useritem.state;
                ModlelUserDetailObj.IsMembership = Useritem.IsMembership;


                objlist.Add(ModlelUserDetailObj);
            }

            return objlist;
        }

        public List<ModelBookStore.UserDetail> SearchCustomer()
        {
          
          
                var CustomerList = (from objItems in TBSEntities.UserDetails
                                
                                select objItems
                            //select new Role { id = objItems.id, UserId = objItems.Name }
                            ).ToList();
            

            
           

            ModelBookStore.UserDetail ModelCustomerObj;

            List<ModelBookStore.UserDetail> objlist = new List<ModelBookStore.UserDetail>();
            foreach (var item in CustomerList)
            {
                ModelCustomerObj = new ModelBookStore.UserDetail();
                ModelCustomerObj.id = item.id;
                ModelCustomerObj.UserId =  Convert.ToInt32( item.UserId);
                ModelCustomerObj.FirstName = item.FirstName;
                ModelCustomerObj.LastName = item.LastName;
                ModelCustomerObj.DOB = item.DOB;
                ModelCustomerObj.PhoneNumber = item.PhoneNumber;
                ModelCustomerObj.EmailId = item.EmailId;
                ModelCustomerObj.Address = item.Address;
                ModelCustomerObj.city = item.city;
                ModelCustomerObj.state = item.state;
                ModelCustomerObj.IsMembership = item.IsMembership;

                objlist.Add(ModelCustomerObj);

            }
            return objlist;
        }
        public List<ModelBookStore.UserDetail> LoadCustBDay()
        {
           

            var UserDetaillist = TBSEntities.usp_UpCmgBdayCust();

            ModelBookStore.UserDetail ModlelUserDetailObj;
            List<ModelBookStore.UserDetail> objlist = new List<ModelBookStore.UserDetail>();
            foreach (var Useritem in UserDetaillist)
            {
                ModlelUserDetailObj = new ModelBookStore.UserDetail();
                //ModlelUserDetailObj.id = Useritem.id;
                ModlelUserDetailObj.FirstName = Useritem.FirstName;
                ModlelUserDetailObj.LastName = Useritem.LastName;
                ModlelUserDetailObj.DOB = Convert.ToDateTime(Useritem.DOB);
                ModlelUserDetailObj.PhoneNumber = Useritem.PhoneNumber;
                ModlelUserDetailObj.EmailId = Useritem.EmailId;
                ModlelUserDetailObj.Address = Useritem.Address;
                ModlelUserDetailObj.city = Useritem.city;
                ModlelUserDetailObj.state = Useritem.state;
               // ModlelUserDetailObj.IsMembership = Useritem.IsMembership;


                objlist.Add(ModlelUserDetailObj);
            }

            return objlist;
        }
        public List<ModelBookStore.UserDetail> LoadAnnualBilling()
        {


            var UserDetaillist = TBSEntities.usp_AnualCustBilling();

            ModelBookStore.UserDetail ModlelUserDetailObj;
            List<ModelBookStore.UserDetail> objlist = new List<ModelBookStore.UserDetail>();
            foreach (var Useritem in UserDetaillist)
            {
                ModlelUserDetailObj = new ModelBookStore.UserDetail();
                //ModlelUserDetailObj.id = Useritem.id;
                ModlelUserDetailObj.FirstName = Useritem.FirstName;
                ModlelUserDetailObj.LastName = Useritem.LastName;
                ModlelUserDetailObj.DOB = Convert.ToDateTime(Useritem.DOB);
                ModlelUserDetailObj.PhoneNumber = Useritem.PhoneNumber;
                ModlelUserDetailObj.EmailId = Useritem.EmailId;
                ModlelUserDetailObj.state = Convert.ToString(Useritem.TotalAmount);


                objlist.Add(ModlelUserDetailObj);
            }

            return objlist;
        }
    }
}
