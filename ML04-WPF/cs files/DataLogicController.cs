using System;
using System.Collections.Generic;
using System.Text;

namespace ML03
{
   ///
   /// \brief <i>Class</i> <b>DataLogicController</b>
   /// \details <b>Details</b>
   ///
   /// Characteristics that represent the requirements of the DataLogicController.
   /// 
   /// As a Data Logic Controller I want to control the flow of data between the UI,
   /// Communications, MySQL.  I act as the conduit for the Users to the database.
   /// 
   /// Parent class.
   ///
   class DataLogicController
   {


      int userRoleID
      { get; set; }
      int buyerOrderID
      { get; set; }
      int plannerID
      { get; set; }
      string plannerTrips
      { get; set; }
      int passageOfTime
      { get; set; }
      float accountBalance
      { get; set; }


      ///
      /// \brief Constructor for <b>DataLogicController</b>
      /// \details <b>Details</b>
      /// 
      /// Creates the required object. 
      ///
      public DataLogicController()
      {

      }

      ///
      /// \brief <b>plannerOrderRecipt</b> function for <b>DataLogicController</b>
      /// \details <b>Details</b>
      ///
      /// Planner Receipt of Buyer's request requirements
      ///
      /// \param None  - <b>void</b>
      ///
      /// \return  TBD  - <b>TBD</b>
      ///
      public void plannerOrderRecipt()
      {
         // TODO_implement
      }

      ///
      /// \brief <b>orderTripDetails</b> function for <b>DataLogicController</b>
      /// \details <b>Details</b>
      ///
      /// Transportation Trip Info. to/from SQL database
      ///
      /// \param None  - <b>void</b>
      ///
      /// \return  TBD  - <b>TBD</b>
      ///
      public void orderTripDetails()
      {
         // TODO_implement
      }

      ///
      /// \brief <b>sqlDataFormProcess</b> function for <b>DataLogicController</b>
      /// \details <b>Details</b>
      ///
      /// Processes the database source for compelting the Planner form
      ///
      /// \param None  - <b>void</b>
      ///
      /// \return  TBD  - <b>TBD</b>
      ///
      public void sqlDataFormProcess()
      {
         // TODO_implement
      }

      ///
      /// \brief <b>updateUserProfile</b> function for <b>DataLogicController</b>
      /// \details <b>Details</b>
      ///
      /// Alters/updates Profile Info. to/from SQL database (NOTE:  key ID remains)
      ///
      /// \param None  - <b>void</b>
      ///
      /// \return  TBD  - <b>TBD</b>
      ///
      public void updateUserProfile()
      {
         // TODO_implement
      }
   }
}
