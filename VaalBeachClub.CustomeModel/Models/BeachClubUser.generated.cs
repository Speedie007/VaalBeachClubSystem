//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
//
//     Produced by Entity Framework Visual Editor
//     https://github.com/msawczyn/EFDesigner
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;

namespace VaalBeachClub.Web.Data.Identity
{
   public partial class BeachClubUser : IdentityUser<int>, IBaseEntity
   {
      partial void Init();

      /// <summary>
      /// Default constructor. Protected due to required properties, but present because EF needs it.
      /// </summary>
      protected BeachClubUser()
      {
         Claims = new System.Collections.ObjectModel.Collection<VaalBeachClub.Web.Data.Identity.BeachClubUserClaim>();
         Logins = new System.Collections.ObjectModel.Collection<VaalBeachClub.Web.Data.Identity.BeachClubUserLogin>();
         Tokens = new System.Collections.ObjectModel.Collection<VaalBeachClub.Web.Data.Identity.BeachClubUserToken>();
         UserRoles = new System.Collections.ObjectModel.Collection<VaalBeachClub.Web.Data.Identity.BeachClubUserRole>();

         Init();
      }

      /// <summary>
      /// Public constructor with required data
      /// </summary>
      /// <param name="firstname"></param>
      /// <param name="lastname"></param>
      /// <param name="_beachclubuserrole0"></param>
      /// <param name="_beachclubuserclaim1"></param>
      /// <param name="_beachclubuserlogin2"></param>
      /// <param name="_beachclubusertoken3"></param>
      public BeachClubUser(string firstname, string lastname, VaalBeachClub.Web.Data.Identity.BeachClubUserRole _beachclubuserrole0, VaalBeachClub.Web.Data.Identity.BeachClubUserClaim _beachclubuserclaim1, VaalBeachClub.Web.Data.Identity.BeachClubUserLogin _beachclubuserlogin2, VaalBeachClub.Web.Data.Identity.BeachClubUserToken _beachclubusertoken3)
      {
         if (string.IsNullOrEmpty(firstname)) throw new ArgumentNullException(nameof(firstname));
         FirstName = firstname;
         if (string.IsNullOrEmpty(lastname)) throw new ArgumentNullException(nameof(lastname));
         LastName = lastname;
         if (_beachclubuserrole0 == null) throw new ArgumentNullException(nameof(_beachclubuserrole0));
         _beachclubuserrole0.User = this;

         if (_beachclubuserclaim1 == null) throw new ArgumentNullException(nameof(_beachclubuserclaim1));
         _beachclubuserclaim1.User = this;

         if (_beachclubuserlogin2 == null) throw new ArgumentNullException(nameof(_beachclubuserlogin2));
         _beachclubuserlogin2.User = this;

         if (_beachclubusertoken3 == null) throw new ArgumentNullException(nameof(_beachclubusertoken3));
         _beachclubusertoken3.User = this;

         Claims = new System.Collections.ObjectModel.Collection<VaalBeachClub.Web.Data.Identity.BeachClubUserClaim>();
         Logins = new System.Collections.ObjectModel.Collection<VaalBeachClub.Web.Data.Identity.BeachClubUserLogin>();
         Tokens = new System.Collections.ObjectModel.Collection<VaalBeachClub.Web.Data.Identity.BeachClubUserToken>();
         UserRoles = new System.Collections.ObjectModel.Collection<VaalBeachClub.Web.Data.Identity.BeachClubUserRole>();
         Init();
      }

      /// <summary>
      /// Static create function (for use in LINQ queries, etc.)
      /// </summary>
      /// <param name="firstname"></param>
      /// <param name="lastname"></param>
      /// <param name="_beachclubuserrole0"></param>
      /// <param name="_beachclubuserclaim1"></param>
      /// <param name="_beachclubuserlogin2"></param>
      /// <param name="_beachclubusertoken3"></param>
      public static BeachClubUser Create(string firstname, string lastname, VaalBeachClub.Web.Data.Identity.BeachClubUserRole _beachclubuserrole0, VaalBeachClub.Web.Data.Identity.BeachClubUserClaim _beachclubuserclaim1, VaalBeachClub.Web.Data.Identity.BeachClubUserLogin _beachclubuserlogin2, VaalBeachClub.Web.Data.Identity.BeachClubUserToken _beachclubusertoken3)
      {
         return new BeachClubUser(firstname, lastname, _beachclubuserrole0, _beachclubuserclaim1, _beachclubuserlogin2, _beachclubusertoken3);
      }

      /*************************************************************************
       * Persistent properties
       *************************************************************************/

      /// <summary>
      /// Required
      /// </summary>
      [Required]
      public string FirstName { get; set; }

      /// <summary>
      /// Required
      /// </summary>
      [Required]
      public string LastName { get; set; }

      /// <summary>
      /// Identity, Required, Indexed
      /// </summary>
      [Key]
      [Required]
      public int Id { get; set; }

      /*************************************************************************
       * Persistent navigation properties
       *************************************************************************/

      public virtual ICollection<VaalBeachClub.Web.Data.Identity.BeachClubUserClaim> Claims { get; set; }

      public virtual ICollection<VaalBeachClub.Web.Data.Identity.BeachClubUserLogin> Logins { get; set; }

      public virtual ICollection<VaalBeachClub.Web.Data.Identity.BeachClubUserToken> Tokens { get; set; }

      public virtual ICollection<VaalBeachClub.Web.Data.Identity.BeachClubUserRole> UserRoles { get; set; }

   }
}
