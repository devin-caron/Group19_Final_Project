using System;
using System.Collections.Generic;
using System.Text;

namespace ML03
{
   ///
   /// \brief <i>Class</i> <b>MySql</b>
   /// \details <b>Details</b>
   ///
   /// Characteristics that represent the requirements of the MySql.
   /// 
   /// As a Database I want to be able to itemize various information about
   /// the truck-good transport options, costs of function and possible
   /// future expansion ideas in order to help organize the requirements of the
   /// User's requests into cost-effective, efficient results.
   /// 
   /// Child derived from Parent DataLogicController class.
   ///
   class MySql : DataLogicController
   {


      int contractID
      { get; set; }
      int costChargesID
      { get; set; }
      int transportationID
      { get; set; }
      int futureOrdersID
      { get; set; }
      int operationalrulesID
      { get; set; }
      int shippingInfoID
      { get; set; }
      float accountIDBalance
      { get; set; }


      ///
      /// \brief Constructor for <b>MySql</b>
      /// \details <b>Details</b>
      /// 
      /// Creates the required object. 
      ///
      public MySql() : base()
      {

      }

      ///
      /// \brief <b>clientProfileInfo</b> function for <b>MySql</b>
      /// \details <b>Details</b>
      ///
      /// Login Profiles of Users stored in database
      ///
      /// \param None  - <b>void</b>
      ///
      /// \return  TBD  - <b>TBD</b>
      ///
      public void clientProfileInfo()
      {
         // TODO_implement
      }

      ///
      /// \brief <b>loginClientID</b> function for <b>MySql</b>
      /// \details <b>Details</b>
      ///
      /// Specific Client assigned ID for login profile matching
      ///
      /// \param None  - <b>void</b>
      ///
      /// \return  TBD  - <b>TBD</b>
      ///
      public void loginClientID()
      {
         // TODO_implement
      }

      ///
      /// \brief <b>updateclientProfile</b> function for <b>MySql</b>
      /// \details <b>Details</b>
      ///
      /// Updates made to User profile (NOTE: verify for credentials alteration 
      ///
      /// \param None  - <b>void</b>
      ///
      /// \return  TBD  - <b>TBD</b>
      ///
      public void updateclientProfile()
      {
         // TODO_implement
      }
   }
}
