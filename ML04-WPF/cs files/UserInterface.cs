using System;
using System.Collections.Generic;
using System.Text;



namespace ML03
{
   ///
   /// \brief <i>Class</i> <b>UserInterface</b>
   /// \details <b>Details</b>
   ///
   /// Characteristics that represent the requirements of the UserInterface.
   /// 
   /// As a User Interface I want to be able to provide options to verify User,
   /// create Buyer orders, track active orders in order to allow the Buyer and Planner
   /// to have the information required to use the system and keep information up to date.
   /// 
   /// Child derived from Parent DataLogicController class.
   ///
   class UserInterface : DataLogicController
   {

      int invoiceID
      { get; set; }
      int buyerOrderId
      { get; set; }
      bool verifyUser
      { get; set; }
      bool activeOrders
      { get; set; }



      ///
      /// \brief Constructor for <b>UserInterface</b>
      /// \details <b>Details</b>
      /// 
      /// Creates the required object. 
      ///
      public UserInterface() : base()
      {
 
      }


      ///
      /// \brief <b>verifyUserType</b> function for <b>UserInterface</b>
      /// \details <b>Details</b>
      ///
      /// Identifies the type of User accessing the database system.
      ///
      /// \param None  - <b>void</b>
      ///
      /// \return  TBD  - <b>TBD</b>
      ///
      public void verifyUserType()
      {
         // TODO_implement
      }

      ///
      /// \brief <b>processOrder</b> function for <b>UserInterface</b>
      /// \details <b>Details</b>
      ///
      /// Processes completed Order.
      ///
      /// \param None  - <b>void</b>
      ///
      /// \return  TBD  - <b>TBD</b>
      ///
      public void processOrder()
      {
         // TODO_implement
      }

      ///
      /// \brief <b>buyerDetails</b> function for <b>UserInterface</b>
      /// \details <b>Details</b>
      ///
      /// Buyer Details entered/updated.
      ///
      /// \param None  - <b>void</b>
      ///
      /// \return  TBD  - <b>TBD</b>
      ///
      public void buyerDetails()
      {
         // TODO_implement
      }

      ///
      /// \brief <b>verifyOrderForm</b> function for <b>UserInterface</b>
      /// \details <b>Details</b>
      ///
      /// Order fill-in details verified before sent to Server. 
      ///
      /// \param None  - <b>void</b>
      ///
      /// \return  TBD  - <b>TBD</b>
      ///
      public void verifyOrderForm()
      {
         // TODO_implement
      }

      ///
      /// \brief <b>buyerOrderGeneration</b> function for <b>UserInterface</b>
      /// \details <b>Details</b>
      ///
      /// Generates the Buyer Order after checked and approved.
      ///
      /// \param None  - <b>void</b>
      ///
      /// \return  TBD  - <b>TBD</b>
      ///
      public void buyerOrderGeneration()
      {
         // TODO_implement
      }
   }
}
