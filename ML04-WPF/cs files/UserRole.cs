using System;
using System.Collections.Generic;
using System.Text;

namespace ML03
{
   ///
   /// \brief <i>Class</i> <b>UserRole</b>
   /// \details <b>Details</b>
   ///
   /// Characteristics that represent the requirements of the DataLogicController.
   /// 
   /// As a UserRole I want to be able to keep track of User ID login information,
   /// to identify the options presented to the User as they use the system.
   /// 
   /// Parent class.
   ///
   class UserRole
   {

      string userId
      { get; set; }
      string password
      { get; set; }
      string loginStatus
      { get; set; }
      DateTime registerDate
      { get; set; }



      ///
      /// \brief Constructor for <b>UserRole</b>
      /// \details <b>Details</b>
      /// 
      /// Creates the required object. 
      ///
      public UserRole()
      {

      }

      ///
      /// \brief <b>verifyLogin</b> function for <b>UserRole</b>
      /// \details <b>Details</b>
      ///
      /// Verifies by password matched with Server-side, the type of User accessing the database system.
      ///
      /// \param None  - <b>void</b>
      ///
      /// \return  bool  - <b>true</b>
      ///
      public bool verifyLogin()
      {
         return true;
      }

   }
}

// KEVIN WUZ HERE :)
